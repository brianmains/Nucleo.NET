using System;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System.Web.Security;
using System.Text.RegularExpressions;


namespace Nucleo.Security
{
	public abstract class FormsMembershipProvider : MembershipProvider
	{
		private string _applicationName;
		private bool _enablePasswordReset = true;
		private bool _enablePasswordRetrieval = false;
		private int _maxInvalidPasswordAttempts = 3;
		private int _minRequiredNonAlphanumericCharacters = 1;
		private int _minRequiredPasswordLength = 6;
		private int _passwordAttemptWindow = 0;
		private MembershipPasswordFormat _passwordFormat = MembershipPasswordFormat.Clear;
		private string _passwordStrengthRegularExpression = ".+";
		private bool _requiresQuestionAndAnswer = false;
		private bool _requiresUniqueEmail = true;



		#region " Properties "

		public override string ApplicationName
		{
			get { return _applicationName; }
			set { _applicationName = value; }
		}

		protected internal abstract string CustomDescription { get; }

		public override bool EnablePasswordReset
		{
			get { return _enablePasswordReset; }
		}

		public override bool EnablePasswordRetrieval
		{
			get { return _enablePasswordRetrieval; }
		}

		public override int MaxInvalidPasswordAttempts
		{
			get { return _maxInvalidPasswordAttempts; }
		}

		public override int MinRequiredNonAlphanumericCharacters
		{
			get { return _minRequiredNonAlphanumericCharacters; }
		}

		public override int MinRequiredPasswordLength
		{
			get { return _minRequiredPasswordLength; }
		}

		public override int PasswordAttemptWindow
		{
			get { return _passwordAttemptWindow; }
		}

		public override MembershipPasswordFormat PasswordFormat
		{
			get { return _passwordFormat; }
		}

		public override string PasswordStrengthRegularExpression
		{
			get { return _passwordStrengthRegularExpression; }
		}

		public override bool RequiresQuestionAndAnswer
		{
			get { return _requiresQuestionAndAnswer; }
		}

		public override bool RequiresUniqueEmail
		{
			get { return _requiresUniqueEmail; }
		}

		#endregion



		#region " Methods "

		protected virtual bool GetBooleanValue(NameValueCollection config, string key, bool defaultValue)
		{
			if (string.IsNullOrEmpty(config[key]))
				return defaultValue;

			bool boolValue;
			if (!bool.TryParse(config[key], out boolValue))
				throw new ProviderException("Invalid value for " + key);
			else
				return boolValue;
		}

		protected virtual int GetIntegerValue(NameValueCollection config, string key, int defaultValue)
		{
			if (string.IsNullOrEmpty(config[key]))
				return defaultValue;

			int intValue;
			if (!int.TryParse(config[key], out intValue))
				throw new ProviderException("Invalid value for " + key);
			else
				return intValue;
		}

		protected void GetPagingInformation(int pageIndex, int pageSize, int total, out int startIndex, out int maxIndex)
		{
			startIndex = (pageIndex * pageSize);
			maxIndex = startIndex + pageSize;

			if (maxIndex >= total)
				maxIndex = total - 1;
		}

		public override void Initialize(string name, NameValueCollection config)
		{
			if (config == null)
				throw new ArgumentNullException("config");
			if (string.IsNullOrEmpty(name))
				name = "SqlMembershipProvider";
			if (string.IsNullOrEmpty(config["description"]))
			{
				config.Remove("description");
				config.Add("description", this.CustomDescription);
			}
			base.Initialize(name, config);
			this._enablePasswordRetrieval = GetBooleanValue(config, "enablePasswordRetrieval", false);
			this._enablePasswordReset = GetBooleanValue(config, "enablePasswordReset", true);
			this._requiresQuestionAndAnswer = GetBooleanValue(config, "requiresQuestionAndAnswer", true);
			this._requiresUniqueEmail = GetBooleanValue(config, "requiresUniqueEmail", true);
			this._maxInvalidPasswordAttempts = GetIntegerValue(config, "maxInvalidPasswordAttempts", 5);
			this._passwordAttemptWindow = GetIntegerValue(config, "passwordAttemptWindow", 10);
			this._minRequiredPasswordLength = GetIntegerValue(config, "minRequiredPasswordLength", 7);
			this._minRequiredNonAlphanumericCharacters = GetIntegerValue(config, "minRequiredNonalphanumericCharacters", 1);
			this._passwordStrengthRegularExpression = config["passwordStrengthRegularExpression"];
			if (this._passwordStrengthRegularExpression != null)
			{
				this._passwordStrengthRegularExpression = this._passwordStrengthRegularExpression.Trim();
				if (this._passwordStrengthRegularExpression.Length > 0)
				{
					try
					{
						new Regex(this._passwordStrengthRegularExpression);
					}
					catch (ArgumentException exception1)
					{
						throw new ProviderException(exception1.Message, exception1);
					}
				}
			}
			else
				this._passwordStrengthRegularExpression = string.Empty;

			if (this._minRequiredNonAlphanumericCharacters > this._minRequiredPasswordLength)
				throw new Exception("The non-alpha numeric characters length must be less than or equal to the required password length.");

			this._applicationName = config["applicationName"];
			if (string.IsNullOrEmpty(this._applicationName))
				this._applicationName = "/";

			string passwordFormat = config["passwordFormat"];
			if (passwordFormat == null)
				passwordFormat = "Hashed";
			if (passwordFormat == "Clear")
				this._passwordFormat = MembershipPasswordFormat.Clear;
			else if (passwordFormat == "Encrypted")
				this._passwordFormat = MembershipPasswordFormat.Encrypted;
			else if (passwordFormat == "Hashed")
				this._passwordFormat = MembershipPasswordFormat.Hashed;
			else
				throw new ProviderException("The format provided is an unknown format.");

			if ((this.PasswordFormat == MembershipPasswordFormat.Hashed) && this.EnablePasswordRetrieval)
				throw new ProviderException("A hashed password cannot be retrieved");

			config.Remove("enablePasswordRetrieval");
			config.Remove("enablePasswordReset");
			config.Remove("requiresQuestionAndAnswer");
			config.Remove("applicationName");
			config.Remove("requiresUniqueEmail");
			config.Remove("maxInvalidPasswordAttempts");
			config.Remove("passwordAttemptWindow");
			config.Remove("commandTimeout");
			config.Remove("passwordFormat");
			config.Remove("name");
			config.Remove("minRequiredPasswordLength");
			config.Remove("minRequiredNonalphanumericCharacters");
			config.Remove("passwordStrengthRegularExpression");

			if (config.Count > 0)
			{
				string unknownKey = config.GetKey(0);
				if (!string.IsNullOrEmpty(unknownKey))
					throw new ProviderException("An unknown attribute has been specified:  " + unknownKey);
			}
		}

		//TODO:Finish password processing method
		protected MembershipCreateStatus ProcessPassword(string password)
		{
			if (this.MinRequiredPasswordLength > 0 && password.Length < this.MinRequiredPasswordLength)
				return MembershipCreateStatus.InvalidPassword;
			else if (this.MinRequiredNonAlphanumericCharacters > 0)
			{
				int nonAlphaCount = 0;
				foreach (char letter in password)
				{
					if (!Char.IsLetter(letter) && !Char.IsNumber(letter))
						nonAlphaCount++;
				}

				if (this.MinRequiredNonAlphanumericCharacters > nonAlphaCount)
					return MembershipCreateStatus.InvalidPassword;
			}
			else if (!string.IsNullOrEmpty(this.PasswordStrengthRegularExpression))
			{
				if (!Regex.IsMatch(password, this.PasswordStrengthRegularExpression))
					return MembershipCreateStatus.InvalidPassword;
			}

			return MembershipCreateStatus.Success;
		}

		#endregion
	}
}