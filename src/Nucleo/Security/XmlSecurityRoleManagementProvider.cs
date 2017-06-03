using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;


namespace Nucleo.Security
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// This class creates an XML file with the format of:
	/// <Security>
	///		<Roles>
	///			<ID />
	///			<Name />
	///			<Description />
	///		</Roles>
	///		<Relationships>
	///			<Relationship>
	///				<Role>Guid</Role>
	///				<Rule>Guid</Rule>
	///				<Authorization>[AD]</Authorization>
	///			</Relationship>
	///		</Relationships>
	/// </Security>
	/// </remarks>
	public class XmlSecurityRoleManagementProvider : SecurityRoleManagementProvider
	{
		private XmlDocument _dataSource = null;
		private string _xmlFile = string.Empty;

		private const string ROLE_ID_XPATH = "./Role[ID = '{0}']";



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
							writer.Write("<Security><Items /><Relationships /></Security>");
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

		private XmlElement RolesCollection
		{
			get { return (XmlElement)this.DataSource.DocumentElement.ChildNodes[0]; }
		}

		#endregion



		#region " Methods "

		public override bool ChangeRulePermission(SecurityRole role, SecurityRule rule, AuthorizationType authorization)
		{
			XmlNodeList relationshipNodeList = this.RelationshipsCollection.SelectNodes(string.Format("./Relationship/Role[text() = '{0}']", role.ID));
			foreach (XmlNode relationshipNode in relationshipNodeList)
			{
				if (string.Compare(relationshipNode["Rule"].InnerText, rule.ID.ToString(), StringComparison.InvariantCultureIgnoreCase) == 0)
				{
					relationshipNode["Authorization"].InnerText = authorization.ToString().Substring(0, 1);
					return true;
				}
			}

			return false;
		}

		public override SecurityRole CreateRole(string roleName, string description, out SecurityObjectCreationStatusType status)
		{
			XmlElement roleElement = this.DataSource.CreateElement("Role");
			this.RolesCollection.AppendChild(roleElement);
			roleElement.AppendChild(this.DataSource.CreateElement("ID"));
			roleElement.AppendChild(this.DataSource.CreateElement("Name"));
			roleElement.AppendChild(this.DataSource.CreateElement("Description"));

			Guid id = Guid.NewGuid();
			roleElement["ID"].InnerText = id.ToString();
			roleElement["Name"].InnerText = roleName;
			roleElement["Description"].InnerText = description;

			status = SecurityObjectCreationStatusType.Success;
			return base.CreateRoleObject(id, roleName, description);
		}

		public override bool DeleteRole(SecurityRole role)
		{
			XmlNode roleNode = this.RolesCollection.SelectSingleNode(string.Format(ROLE_ID_XPATH, role.ID));
			if (roleNode != null)
			{
				this.RolesCollection.RemoveChild(roleNode);
				return true;
			}
			else
				return false;
		}

		public override bool DeleteRoleAssociations(SecurityRole role)
		{
			bool foundOne = false;

			foreach (XmlNode roleAssociationNode in this.RelationshipsCollection.ChildNodes)
			{
				XmlNode roleNode = roleAssociationNode.SelectSingleNode(string.Format(ROLE_ID_XPATH, role.ID));
				if (roleNode != null)
				{
					roleAssociationNode.RemoveChild(roleNode);
					foundOne = true;
				}
			}

			return foundOne;
		}

		protected internal override SecurityRoleCollection GetRoles()
		{
			SecurityRoleCollection rolesList = new SecurityRoleCollection();

			foreach (XmlElement roleElement in this.RolesCollection.ChildNodes)
			{
				List<SecurityRule> rulesList = new List<SecurityRule>();

				foreach (XmlNode ruleNode in this.RelationshipsCollection.ChildNodes)
					rulesList.Add(SecurityFramework.Rules.FindByGuid((Guid)Convert.ChangeType(ruleNode.InnerText, typeof(Guid))));

				SecurityRole role = base.CreateRoleObject(
					(Guid)Convert.ChangeType(roleElement["ID"].InnerText, typeof(Guid)),
					roleElement["Name"].InnerText,
					roleElement["Description"].InnerText);
				role.Rules.AddRange(rulesList);
				rolesList.Add(role);
			}

			return rolesList;
		}

		#endregion
	}
}
