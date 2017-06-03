using System;
using System.Xml;
using System.IO;

using Nucleo.IO;


namespace Nucleo.State
{
	public class XmlStateValuesProvider : StateValuesProvider
	{
		private XmlDocument _document = null;
		private static object _documentLock = new object();
		private string _xmlFolder = null;



		#region " Properties "

		protected virtual string NameElementName
		{
			get { return "Name"; }
		}

		protected virtual string ParentElementName
		{
			get { return "StateProperty"; }
		}

		protected virtual string RegionElementName
		{
			get { return "Region"; }
		}

		protected virtual string ValueElementName
		{
			get { return "Value"; }
		}

		#endregion



		#region " Methods "

		private XmlDocument GetDocument(StateUser user, StatePropertyIsolation isolation)
		{
			if (_document != null)
				return _document;
			
			string file = this.GetFilePath(user, isolation, _xmlFolder);
			//Creates the file when the file doesn't exist
			if (!File.Exists(file))
			{
				using (StreamWriter writer = new StreamWriter(File.Create(file)))
				{
					writer.Write("<StateProperties />");
				}
			}

			_document = new XmlDocument();
			_document.Load(this.GetFilePath(user, isolation, _xmlFolder));

			return _document;
		}

		private string GetFilePath(StateUser user, StatePropertyIsolation isolation, string path)
		{
			//Ensure not web paths (forward slashes)
			path = path.Replace(@"/", @"\");
			//Ensure paths that have ~ do not get passed along
			if (path.StartsWith("~"))
				path = path.Substring(1);
			if (!path.StartsWith(@"\"))
				path = @"\" + path;

			string finalPath = AppDomain.CurrentDomain.BaseDirectory + path;

			//Ensure ending slash
			if (!finalPath.EndsWith(@"\"))
				finalPath += @"\";

			if (isolation == StatePropertyIsolation.Shared)
				finalPath += "shared.xml";
			else
				finalPath += string.Format("{0}.xml", user.UserName);

			return finalPath;
		}

		public override object GetRegionValue(StateUser user, StateProperty property, string regionName)
		{
			XmlDocument document = this.GetDocument(user, property.Isolation);
			XmlElement element = (XmlElement)document.SelectSingleNode(string.Format("//{0}[@{3}='{1}']/{2}[./{3} = '{4}']", this.RegionElementName, regionName, this.ParentElementName, this.NameElementName, property.Name));

			return this.GetValueInternal(element);
		}

		public override object GetValue(StateUser user, StateProperty property)
		{
			XmlDocument document = this.GetDocument(user, property.Isolation);
			XmlElement element = (XmlElement)document.SelectSingleNode(string.Format("//{0}[./{1} = '{2}']", this.ParentElementName, this.NameElementName, property.Name));

			return this.GetValueInternal(element);
		}

		private object GetValueInternal(XmlElement element)
		{
			if (element == null)
				throw new ArgumentException("The property is not in the underlying data source", "propertyName");

			return element[this.ValueElementName].InnerText;
		}

		public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
		{
			if (string.IsNullOrEmpty(name))
				name = "XmlStateValuesProvider";

			base.Initialize(name, config);

			_xmlFolder = config["xmlFolder"];
			if (string.IsNullOrEmpty(_xmlFolder))
				throw new System.Configuration.ConfigurationErrorsException("The xml folder was not provided");
		}

		public override bool SetRegionValue(StateUser user, StateProperty property, string regionName, object propertyValue)
		{
			XmlDocument document = this.GetDocument(user, property.Isolation);
			XmlElement element = (XmlElement)document.SelectSingleNode(string.Format("//{0}[@{3}='{1}']/{2}[./{3} = '{4}']", this.RegionElementName, regionName, this.ParentElementName, this.NameElementName, property.Name));

			return this.SetValueInternal(element, propertyValue);
		}

		public override bool SetValue(StateUser user, StateProperty property, object propertyValue)
		{
			XmlDocument document = this.GetDocument(user, property.Isolation);
			XmlElement element = (XmlElement)document.SelectSingleNode(string.Format("//{0}[./{1} = '{2}']", this.ParentElementName, this.NameElementName, property.Name));

			return this.SetValueInternal(element, propertyValue);
		}

		private bool SetValueInternal(XmlElement element, object propertyValue)
		{
			if (element == null)
				throw new ArgumentException("The property is not in the underlying data source", "propertyName");

			string propertyText = (propertyValue != null) ? propertyValue.ToString() : default(string);

			if (element[this.ValueElementName].InnerText != propertyText)
			{
				element[this.ValueElementName].InnerText = propertyText;
				return true;
			}
			else
				return false;
		}

		#endregion
	}
}
