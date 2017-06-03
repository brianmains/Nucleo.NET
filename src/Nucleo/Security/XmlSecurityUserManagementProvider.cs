using System;
using System.IO;
using System.Xml;


namespace Nucleo.Security
{
	public class XmlSecurityUserManagementProvider : SecurityUserManagementProvider
	{
		private XmlDocument _dataSource = null;
		private string _xmlFile = string.Empty;



		#region " Constants "

		private const string ROLE_ID_XPATH = "./Role[ID = '{0}']";
		private const string RULE_ID_XPATH = "./Rule[ID = '{0}']";
		private const string SUBSYSTEM_ID_XPATH = "./Subsystem[ID = '{0}']";
		private const string USER_ID_XPATH = "./User[ID = '{0}']";

		#endregion



		#region " Properties "

		protected XmlDocument DataSource
		{
			get
			{
				if (string.IsNullOrEmpty(_xmlFile))
					throw new ArgumentNullException("_xmlFile");

				if (_dataSource == null)
				{
					if (!File.Exists(_xmlFile))
					{
						using (StreamWriter writer = new StreamWriter(_xmlFile))
							writer.Write("<Security><Users /><Roles /><Rules /><Subsystems /></Security>");
					}

					_dataSource = new XmlDocument();
					_dataSource.Load(_xmlFile);
				}

				return _dataSource;
			}
		}

		private XmlElement RelationshipsCollection
		{
			get { return (XmlElement)this.DataSource.DocumentElement.ChildNodes[1]; }
		}

		private XmlElement UsersCollection
		{
			get { return (XmlElement)this.DataSource.DocumentElement.ChildNodes[0]; }
		}

		#endregion



		#region " Methods "

		public override bool ChangeRolePermission(SecurityUser user, SecurityRole role, AuthorizationType authorization)
		{
			XmlElement userElement = (XmlElement)this.UsersCollection.SelectSingleNode(string.Format(USER_ID_XPATH, user.ID));
			if (userElement == null)
				throw new ArgumentException("The user does not exist in the data store", "user");
			XmlElement rolesElement = this.DetermineIfCollectionNodeExists(userElement, "RoleAssociations");
			XmlNode roleNode = rolesElement.SelectSingleNode(string.Format(ROLE_ID_XPATH, role.ID));

			if (roleNode == null && authorization == AuthorizationType.Allow)
			{
				XmlElement roleElement = this.DataSource.CreateElement("Role");
				roleElement.InnerText = role.ID.ToString();
				rolesElement.AppendChild(roleElement);
				return true;
			}
			else if (roleNode != null && authorization == AuthorizationType.Deny)
			{
				rolesElement.RemoveChild(roleNode);
				return true;
			}
			else
				return false;
		}

		public override bool ChangeRulePermission(SecurityUser user, SecurityRule rule, AuthorizationType authorization)
		{
			XmlElement userElement = (XmlElement)this.UsersCollection.SelectSingleNode(string.Format(USER_ID_XPATH, user.ID));
			if (userElement == null)
				throw new ArgumentException("The user does not exist in the data store", "user");
			XmlElement rulesElement = this.DetermineIfCollectionNodeExists(userElement, "RuleAssociations");
			XmlNode ruleNode = rulesElement.SelectSingleNode(string.Format(RULE_ID_XPATH, rule.ID));
			
			if (ruleNode == null && authorization == AuthorizationType.Allow)
			{
				XmlElement ruleElement = this.DataSource.CreateElement("Rule");
				ruleElement.InnerText = rule.ID.ToString();
				rulesElement.AppendChild(ruleElement);
				return true;
			}
			else if (ruleNode != null && authorization == AuthorizationType.Deny)
			{
				rulesElement.RemoveChild(ruleNode);
				return true;
			}
			else
				return false;
		}

		public override bool ChangeSubsystemPermission(SecurityUser user, SecuritySubsystem subsystem, AuthorizationType authorization)
		{
			XmlElement userElement = (XmlElement)this.UsersCollection.SelectSingleNode(string.Format(USER_ID_XPATH, user.ID));
			if (userElement == null)
				throw new ArgumentException("The user does not exist in the data store", "user");
			XmlElement subsystemsElement = this.DetermineIfCollectionNodeExists(userElement, "SubsystemAssociations");
			XmlNode subsystemNode = subsystemsElement.SelectSingleNode(string.Format(SUBSYSTEM_ID_XPATH, subsystem.ID));

			if (subsystemNode == null && authorization == AuthorizationType.Allow)
			{
				XmlElement subsystemElement = this.DataSource.CreateElement("Subsystem");
				subsystemElement.InnerText = subsystem.ID.ToString();
				subsystemsElement.AppendChild(subsystemElement);
				return true;
			}
			else if (subsystemNode != null && authorization == AuthorizationType.Deny)
			{
				subsystemsElement.RemoveChild(subsystemNode);
				return true;
			}
			else
				return false;
		}

		private bool ChangeUserLockedStatus(SecurityUser user, bool isLocked)
		{
			XmlNode userNode = this.UsersCollection.SelectSingleNode(string.Format(USER_ID_XPATH, user.ID));

			if (userNode == null)
				return false;
			else
			{
				userNode["IsLockedOut"].InnerText = isLocked.ToString();
				return true;
			}
		}

		public override bool ContainsUser(string userName)
		{
			return (this.DataSource.SelectSingleNode("/Security/Users//User[./Name = '" + userName + "']") != null);
		}

		public override SecurityUser CreateUser(string userName, string fullName, string email, string phoneNumber, SecurityPassword password, out SecurityObjectCreationStatusType status)
		{
			XmlElement userElement = this.DataSource.CreateElement("User");
			this.UsersCollection.AppendChild(userElement);
			userElement.AppendChild(this.DataSource.CreateElement("ID"));
			userElement.AppendChild(this.DataSource.CreateElement("Name"));
			userElement.AppendChild(this.DataSource.CreateElement("FullName"));
			userElement.AppendChild(this.DataSource.CreateElement("Email"));
			userElement.AppendChild(this.DataSource.CreateElement("PhoneNumber"));
			userElement.AppendChild(this.DataSource.CreateElement("Password"));
			userElement.AppendChild(this.DataSource.CreateElement("CreationDate"));
			userElement.AppendChild(this.DataSource.CreateElement("IsLockedOut"));

			Guid id = Guid.NewGuid();
			userElement["ID"].InnerText = id.ToString();
			userElement["Name"].InnerText = userName;
			userElement["FullName"].InnerText = fullName;
			userElement["Email"].InnerText = email;
			userElement["PhoneNumber"].InnerText = phoneNumber;
			userElement["Password"].InnerText = password.Value;
			userElement["CreationDate"].InnerText = DateTime.Now.ToString();
			userElement["IsLockedOut"].InnerText = bool.FalseString;

			status = SecurityObjectCreationStatusType.Success;
			return base.CreateUserObject(id, userName, fullName, email, phoneNumber, password);
		}

		public override bool DeleteUser(SecurityUser user)
		{
			XmlNode userNode = this.UsersCollection.SelectSingleNode(string.Format(USER_ID_XPATH, user.ID));
			if (userNode != null)
			{
				this.UsersCollection.RemoveChild(userNode);
				return true;
			}
			else
				return false;
		}

		public override bool DeleteUserAssociations(SecurityUser user)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		private XmlElement DetermineIfCollectionNodeExists(XmlElement parentElement, string collectionName)
		{
			XmlElement collectionElement = null;

			if (parentElement[collectionName] != null)
				collectionElement = parentElement[collectionName];
			else
			{
				collectionElement = this.DataSource.CreateElement(collectionName);
				parentElement.AppendChild(collectionElement);
			}

			return collectionElement;
		}

		public override SecurityUser GetUser(string userName)
		{
			XmlNode userNode = this.UsersCollection.SelectSingleNode(string.Format(".//User[Name = '{0}']", userName));
			if (userNode == null)
				return null;

			SecurityPassword password = new SecurityPassword();
			password._value = userNode["Password"].InnerText;
			
			SecurityUser user = base.CreateUserObject(
				(Guid)Convert.ChangeType(userNode["ID"].InnerText,typeof(Guid)),
				userNode["Name"].InnerText,
				userNode["FullName"].InnerText,
				userNode["Email"].InnerText,
				userNode["PhoneNumber"].InnerText,
				password);

			foreach (XmlNode roleNode in userNode["RoleAssociations"].ChildNodes)
			{
				SecurityRole role = SecurityFramework.Roles.FindByGuid((Guid)Convert.ChangeType(roleNode.InnerText, typeof(Guid)));
				if (role != null)
					user.Roles.Add(role);
			}
			foreach (XmlNode ruleNode in userNode["RuleAssociations"].ChildNodes)
			{
				SecurityRule rule = SecurityFramework.Rules.FindByGuid((Guid)Convert.ChangeType(ruleNode.InnerText, typeof(Guid)));
				if (rule != null)
					user.Rules.Add(rule);
			}
			foreach (XmlNode subsystemNode in userNode["SubsystemAssociations"].ChildNodes)
			{
				SecuritySubsystem subsystem = SecurityFramework.Subsystems.FindByGuid((Guid)Convert.ChangeType(subsystemNode.InnerText, typeof(Guid)));
				if (subsystem != null)
					user.Subsystems.Add(subsystem);
			}

			return user;
		}

		public override int GetUserCount()
		{
			return this.UsersCollection.ChildNodes.Count;
		}

		public override bool LockoutUser(SecurityUser user)
		{
			return this.ChangeUserLockedStatus(user, true);
		}

		public override void SaveUserChanges(SecurityUser user)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public override bool UnlockUser(SecurityUser user)
		{
			return this.ChangeUserLockedStatus(user, false);
		}

		#endregion
	}
}
