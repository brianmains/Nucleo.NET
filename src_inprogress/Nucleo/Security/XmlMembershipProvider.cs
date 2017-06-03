using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Xml;
using System.IO;
using System.Configuration.Provider;
using Nucleo.Caching;


namespace Nucleo.Security
{
	public class XmlMembershipProvider : FormsMembershipProvider
	{
		private readonly string _cacheKey = CacheManagement.GetSafeKey(string.Format("{0}_{1}", "XmlMembershipProvider", "Users"));
		private XmlDocument _document = null;
		private string _sourceFile = null;
		private bool _enableCaching = false;



		#region " Properties "

		protected internal override string CustomDescription
		{
			get { return "The membership provider that uses XML as its data store."; }
		}

		protected XmlDocument Document
		{
			get
			{
				if (_document == null)
				{
					if (CacheManagement.Enabled && CacheManagement.Contains(_cacheKey))
						_document = CacheManagement.Get<XmlDocument>(_cacheKey);
					else
						_document = new XmlDocument();

					string file = this.SourceFile;
					if (file.StartsWith("~/"))
						file = file.Replace("~/", AppDomain.CurrentDomain.BaseDirectory + "/");

					if (File.Exists(file))
						_document.Load(file);
					else
					{
						_document.AppendChild(Document.CreateElement("Users"));
						_document.Save(file);
					}

					if (CacheManagement.Enabled)
						CacheManagement.Add(_cacheKey, _document);
				}

				return _document;
			}
		}

		public bool EnableCaching
		{
			get { return _enableCaching; }
		}

		public string SourceFile
		{
			get { return _sourceFile; }
			set { _sourceFile = value; }
		}

		#endregion



		#region " Methods "

		public override bool ChangePassword(string userName, string oldPassword, string newPassword)
		{
			XmlElement userElement = this.Document.SelectSingleNode(@"//User[./UserName = '" + userName + "']") as XmlElement;
			if (userElement == null)
				throw new ProviderException("The user ID doesn't exist in the current system");

			//Password has to match the old password
			if (userElement["Password"].InnerText == oldPassword)
			{
				userElement["Password"].InnerText = newPassword;
				this.SaveChanges();
				return true;
			}

			return false;
		}

		public override bool ChangePasswordQuestionAndAnswer(string userName, string password, string newPasswordQuestion, string newPasswordAnswer)
		{
			XmlElement userElement = this.GetUserByName(userName);
			if (userElement == null)
				throw new ProviderException("The user ID doesn't exist in the current system");

			if (this.ValidateUser(userName, password))
			{
				userElement["PasswordQuestion"].InnerText = newPasswordQuestion;
				userElement["PasswordAnswer"].InnerText = newPasswordAnswer;
				this.SaveChanges();
				return true;
			}
			else
				return false;
		}

		public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
		{
			MembershipUser user = this.GetUser(username, true) as MembershipUser;
			if (user != null)
			{
				status = MembershipCreateStatus.DuplicateUserName;
				return null;
			}

			XmlElement userElement = this.InstantiateUserElement();
			userElement["UserName"].InnerText = username;
			userElement["Password"].InnerText = password;
			userElement["Email"].InnerText = email;
			userElement["PasswordQuestion"].InnerText = passwordQuestion;
			userElement["PasswordAnswer"].InnerText = passwordAnswer;
			userElement["IsApproved"].InnerText = isApproved.ToString();
			userElement["ProviderUserKey"].InnerText = (providerUserKey == null ? string.Empty : providerUserKey.ToString());
			userElement["CreationDate"].InnerText = DateTime.Today.ToString();
			userElement["LastLoginDate"].InnerText = DateTime.Today.ToString();
			userElement["LastActivityDate"].InnerText = DateTime.Today.ToString();
			
			this.Document.DocumentElement.AppendChild(userElement);
			this.SaveChanges();

			//Ensure that the password meets regulations
			status = this.ProcessPassword(password);
			//Only return an instantiated user if the password meets the correct requirements
			if (status != MembershipCreateStatus.Success)
				return null;
			else
				return new MembershipUser(this.Name, username, providerUserKey, email, passwordQuestion, null, isApproved, false, DateTime.Today, DateTime.Today, DateTime.Today, DateTime.MinValue, DateTime.MinValue);
		}

		public override bool DeleteUser(string username, bool deleteAllRelatedData)
		{
			XmlElement userElement = this.GetUserByName(username);
			if (userElement == null)
				throw new ProviderException("The user ID doesn't exist in the current system");

			this.Document.RemoveChild(userElement);
			this.SaveChanges();
			return true;
		}

		public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			return this.InstantiateCollection(this.Document.SelectNodes(string.Format("//User[contains(./Email,'{0}')]", emailToMatch)), pageIndex, pageSize, out totalRecords);
		}

		public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			return this.InstantiateCollection(this.Document.SelectNodes(string.Format("//User[contains(./UserName,'{0}')]", usernameToMatch)), pageIndex, pageSize, out totalRecords);
		}

		public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
		{
			return this.InstantiateCollection(this.Document.DocumentElement.ChildNodes, pageIndex, pageSize, out totalRecords);
		}

		//TODO:Figure out how to return number of users online
		public override int GetNumberOfUsersOnline()
		{
			return 0;
		}

		public override string GetPassword(string username, string answer)
		{
			XmlElement userElement = this.GetUserByName(username);
			if (userElement == null)
				throw new ProviderException("The user ID doesn't exist in the current system");
			
			if (userElement["PasswordAnswer"].InnerText == answer)
				return userElement["Password"].InnerText;
			else
				throw new ProviderException("The password answers do not match up");
		}

		public override MembershipUser GetUser(string username, bool userIsOnline)
		{
			XmlElement userElement = this.GetUserByName(username);

			if (userElement == null)
				return null;
			else
			{
				this.UpdateUserActivity(userElement);
				this.SaveChanges();
				return this.InstantiateUser(userElement);
			}
		}

		public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
		{
			XmlElement userElement = this.GetUserByKey(providerUserKey);

			if (userElement == null)
				return null;
			else
			{
				this.UpdateUserActivity(userElement);
				this.SaveChanges();
				return this.InstantiateUser(userElement);
			}
		}

		public override string GetUserNameByEmail(string email)
		{
			XmlElement userElement = this.Document.SelectSingleNode(@"//User[./Email = '" + email + "']") as XmlElement;
			if (userElement != null)
				return userElement["UserName"].InnerText;
			return null;
		}

		private XmlElement GetUserByKey(object providerUserKey)
		{
			return this.Document.SelectSingleNode(@"//User[./ProviderUserKey = '" + providerUserKey + "']") as XmlElement;
		}

		private XmlElement GetUserByName(string userName)
		{
			return this.Document.SelectSingleNode(@"//User[./UserName = '" + userName + "']") as XmlElement;
		}

		public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
		{
			if (string.IsNullOrEmpty(name))
				name = "NucleoXmlMembershipProvider";

			if (config["description"] != null)
				config.Remove("description");
			config.Add("description", "The XML membership provider that uses an XML file to do its processing");

			_sourceFile = config["sourceFile"];
			config.Remove("sourceFile");

			try
			{
				_enableCaching = base.GetBooleanValue(config, "enableCaching", false);
				config.Remove("enableCaching");
			}
			catch { }

			base.Initialize(name, config);
		}

		private MembershipUserCollection InstantiateCollection(XmlNodeList usersList, int pageIndex, int pageSize, out int totalRecords)
		{
			MembershipUserCollection users = new MembershipUserCollection();
			totalRecords = usersList.Count;
			int start, max;

			this.GetPagingInformation(pageIndex, pageSize, totalRecords, out start, out max);
			for (int i = start; i <= max; i++)
			{
				XmlElement userElement = usersList[i] as XmlElement;
				users.Add(this.InstantiateUser(userElement));
			}

			return users;
		}

		//TODO:Instantiate a user based on an element
		protected MembershipUser InstantiateUser(XmlElement userElement)
		{
			return new MembershipUser(this.Name,
				userElement["UserName"].InnerText,
				userElement["ProviderUserKey"].InnerText,
				userElement["Email"].InnerText,
				userElement["PaswordQuestion"].InnerText,
				userElement["PasswordAnswer"].InnerText,
				bool.Parse(userElement["IsApproved"].InnerText),
				bool.Parse(userElement["IsLockedOut"].InnerText),
				this.ProcessDateField(userElement["CreationDate"], DateTime.MinValue),
				this.ProcessDateField(userElement["LastLoginDate"], DateTime.MinValue),
				this.ProcessDateField(userElement["LastActivityDate"], DateTime.MinValue),
				this.ProcessDateField(userElement["LastPasswordChangedDate"], DateTime.MinValue),
				this.ProcessDateField(userElement["LastLockoutDate"], DateTime.MinValue));
		}

		private DateTime ProcessDateField(XmlElement element, DateTime defaultDate)
		{
			if (element == null || string.IsNullOrEmpty(element.InnerText))
				return defaultDate;

			DateTime dateValue;
			if (!DateTime.TryParse(element.InnerText, out dateValue))
				return defaultDate;
			else
				return dateValue;
		}

		protected XmlElement InstantiateUserElement()
		{
			XmlElement userElement = this.Document.CreateElement("User");
			userElement.AppendChild(this.Document.CreateElement("UserName"));
			userElement.AppendChild(this.Document.CreateElement("Password"));
			userElement.AppendChild(this.Document.CreateElement("PasswordQuestion"));
			userElement.AppendChild(this.Document.CreateElement("PasswordAnswer"));
			userElement.AppendChild(this.Document.CreateElement("Email"));
			userElement.AppendChild(this.Document.CreateElement("ProviderUserKey"));
			userElement.AppendChild(this.Document.CreateElement("CreationDate"));
			userElement.AppendChild(this.Document.CreateElement("LastLoginDate"));
			userElement.AppendChild(this.Document.CreateElement("LastActivityDate"));
			userElement.AppendChild(this.Document.CreateElement("LastLockoutDate"));
			userElement.AppendChild(this.Document.CreateElement("LastPasswordChangedDate"));
			userElement.AppendChild(this.Document.CreateElement("IsApproved"));
			userElement.AppendChild(this.Document.CreateElement("IsLockedOut"));
			userElement.AppendChild(this.Document.CreateElement("Comment"));

			userElement["IsApproved"].InnerText = true.ToString();
			userElement["IsLockedOut"].InnerText = false.ToString();
			return userElement;
		}

		//TODO:finish PerformAuthorizationCheck
		public virtual void PerformAuthorizationCheck(string action)
		{

		}

		public override string ResetPassword(string username, string answer)
		{
			string newPassword = "Pa$$w0rd";
			XmlElement userElement = this.GetUserByName(username);

			if (userElement == null)
				throw new ProviderException("The user ID doesn't exist in the current system");
			if (userElement["PasswordAnswer"].InnerText != answer)
				throw new ProviderException("The answer doesn't match what exists for the user");
			else
			{
				userElement["Password"].InnerText = newPassword;
				this.SaveChanges();
				return newPassword;
			}	
		}

		private void SaveChanges()
		{
			this.Document.Save(this.SourceFile);
			if (_enableCaching && CacheManagement.Enabled)
				CacheManagement.Add(_cacheKey, this.Document);
		}

		public override bool UnlockUser(string userName)
		{
			XmlElement userElement = this.GetUserByName(userName);
			if (userElement == null)
				throw new ProviderException("The user ID doesn't exist in the current system");

			userElement["IsLockedOut"].InnerText = false.ToString();
			this.SaveChanges();
			return true;
		}

		public override void UpdateUser(MembershipUser user)
		{
			XmlElement userElement = this.GetUserByName(user.UserName);
			if (userElement == null)
				throw new ProviderException("The user ID doesn't exist in the current system");

			userElement["Email"].InnerText = user.Email;
			userElement["ProviderUserKey"].InnerText = user.ProviderUserKey.ToString();
			userElement["LastLoginDate"].InnerText = user.LastLoginDate.ToString();
			userElement["LastActivityDate"].InnerText = user.LastActivityDate.ToString();
			userElement["IsApproved"].InnerText = user.IsApproved.ToString();
			userElement["Comment"].InnerText = user.Comment;
			this.SaveChanges();
		}

		private void UpdateUserActivity(XmlElement userElement)
		{
			if (userElement == null)
				return;

			userElement["LastActivityDate"].InnerText = DateTime.Today.ToString();
			this.SaveChanges();
		}

		public override bool ValidateUser(string username, string password)
		{
			return (this.Document.SelectNodes("//User[./UserName = '" + username + "' && Password='" + password + "']").Count > 0);
		}

		#endregion
	}
}