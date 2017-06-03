using System;
using System.IO;
using System.Xml;

namespace Nucleo.Security
{
	public class XmlSecurityRuleManagementProvider : SecurityRuleManagementProvider
	{
		private XmlDocument _dataSource = null;
		private string _xmlFile = string.Empty;

		private const string RULE_ID_XPATH = "./Rule[ID = '{0}']";


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

		private XmlElement RulesCollection
		{
			get { return (XmlElement)this.DataSource.DocumentElement.ChildNodes[0]; }
		}

		#endregion



		public override SecurityRule CreateRule(string ruleName, string description, out SecurityObjectCreationStatusType status)
		{
			XmlElement ruleElement = this.DataSource.CreateElement("Rule");
			this.RulesCollection.AppendChild(ruleElement);
			ruleElement.AppendChild(this.DataSource.CreateElement("ID"));
			ruleElement.AppendChild(this.DataSource.CreateElement("Name"));
			ruleElement.AppendChild(this.DataSource.CreateElement("Description"));

			Guid id = Guid.NewGuid();
			ruleElement["ID"].InnerText = id.ToString();
			ruleElement["Name"].InnerText = ruleName;
			ruleElement["Description"].InnerText = description;

			status = SecurityObjectCreationStatusType.Success;
			return base.CreateRuleObject(id, ruleName, description);
		}

		public override bool DeleteRule(SecurityRule rule)
		{
			XmlNode ruleNode = this.RulesCollection.SelectSingleNode(string.Format(RULE_ID_XPATH, rule.ID));
			if (ruleNode != null)
			{
				this.RulesCollection.RemoveChild(ruleNode);
				return true;
			}
			else
				return false;
		}

		public override bool DeleteRuleAssociations(SecurityRule rule)
		{
			XmlNodeList ruleAssociationsNodes = this.DataSource.SelectNodes("//RuleAssociations");
			bool found = false;

			foreach (XmlNode ruleAssociationNode in ruleAssociationsNodes)
			{
				XmlNode ruleNode = ruleAssociationNode.SelectSingleNode(string.Format(RULE_ID_XPATH, rule.ID));
				if (ruleNode != null)
				{
					ruleAssociationNode.RemoveChild(ruleNode);
					found = true;
				}
			}

			return found;
		}

		protected internal override SecurityRuleCollection GetRules()
		{
			SecurityRuleCollection rulesList = new SecurityRuleCollection();

			foreach (XmlNode ruleNode in this.RulesCollection.ChildNodes)
			{
				rulesList.Add(base.CreateRuleObject(
					(Guid)Convert.ChangeType(ruleNode["ID"].InnerText, typeof(Guid)),
					ruleNode["Name"].InnerText,
					ruleNode["Description"].InnerText));
			}

			return rulesList;
		}
	}
}
