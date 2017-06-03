using System;
using System.IO;
using System.Xml;

namespace Nucleo.Security
{
	public class XmlSecuritySubsystemManagementProvider : SecuritySubsystemManagementProvider
	{
		private XmlDocument _dataSource = null;
		private string _xmlFile = string.Empty;

		private const string SUBSYSTEM_ID_XPATH = "./Item[ID = '{0}']";


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

		private XmlElement SubsystemsCollection
		{
			get { return (XmlElement)this.DataSource.DocumentElement.ChildNodes[0]; }
		}

		#endregion

		public override SecuritySubsystem CreateSubsystem(string subsystemName, string description, out SecurityObjectCreationStatusType status)
		{
			XmlElement subsystemElement = this.DataSource.CreateElement("Item");
			this.SubsystemsCollection.AppendChild(subsystemElement);
			subsystemElement.AppendChild(this.DataSource.CreateElement("ID"));
			subsystemElement.AppendChild(this.DataSource.CreateElement("Name"));
			subsystemElement.AppendChild(this.DataSource.CreateElement("Description"));

			Guid id = Guid.NewGuid();
			subsystemElement["ID"].InnerText = id.ToString();
			subsystemElement["Name"].InnerText = subsystemName;
			subsystemElement["Description"].InnerText = description;

			status = SecurityObjectCreationStatusType.Success;
			return base.CreateSubsystemObject(id, subsystemName, description);
		}

		public override bool DeleteSubsystem(SecuritySubsystem subsystem)
		{
			XmlNode subsystemNode = this.SubsystemsCollection.SelectSingleNode(string.Format(SUBSYSTEM_ID_XPATH, subsystem.ID));
			if (subsystemNode != null)
			{
				this.SubsystemsCollection.RemoveChild(subsystemNode);
				return true;
			}
			else
				return false;
		}

		public override bool DeleteSubsystemAssociations(SecuritySubsystem subsystem)
		{
			bool foundOne = false;

			foreach (XmlNode subsystemAssociationNode in this.RelationshipsCollection.ChildNodes)
			{
				XmlNode subsystemNode = subsystemAssociationNode.SelectSingleNode(string.Format(SUBSYSTEM_ID_XPATH, subsystem.ID));
				if (subsystemNode != null)
				{
					subsystemAssociationNode.RemoveChild(subsystemNode);
					foundOne = true;
				}
			}

			return foundOne;
		}

		protected internal override SecuritySubsystemCollection GetSubsystems()
		{
			SecuritySubsystemCollection subsystemsList = new SecuritySubsystemCollection();

			foreach (XmlNode subsystemNode in this.SubsystemsCollection.ChildNodes)
			{
				subsystemsList.Add(base.CreateSubsystemObject(
					(Guid)Convert.ChangeType(subsystemNode["ID"].InnerText, typeof(Guid)),
					subsystemNode["Name"].InnerText,
					subsystemNode["Description"].InnerText));
			}

			return subsystemsList;
		}
	}
}
