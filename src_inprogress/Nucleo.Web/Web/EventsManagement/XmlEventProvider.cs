using System;
using System.Xml;
using System.IO;
using System.Web.Management;
using System.Configuration;
using System.Configuration.Provider;
using System.Web;

using Nucleo.Web.Core;


namespace Nucleo.Web.EventsManagement
{
	public class XmlEventProvider : BufferedWebEventProvider
	{
		private XmlDocument _document = null;
		private string _xmlDataFile = string.Empty;



		#region " Properties "

		public XmlDocument Document
		{
			get
			{
				if (_document == null)
				{
					_document = new XmlDocument();
					_document.Load(this.GetXmlDataFilePath());
				}

				return _document;
			}
		}

		public string XmlDataFile
		{
			get { return _xmlDataFile; }
		}

		#endregion



		#region " Methods "

		private void CreateEventElement(WebBaseEvent raisedEvent)
		{
			XmlElement element = this.Document.CreateElement("Event");
			element.AppendChild(this.Document.CreateElement("Code"));
			element.AppendChild(this.Document.CreateElement("Date"));
			element.AppendChild(this.Document.CreateElement("Source"));
			element.AppendChild(this.Document.CreateElement("Message"));

			element["Code"].InnerText = raisedEvent.EventCode.ToString();
			element["Date"].InnerText = raisedEvent.EventTime.ToString();
			element["Source"].InnerText = (raisedEvent.EventSource != null ? raisedEvent.EventSource.ToString() : string.Empty);
			element["Message"].InnerText = raisedEvent.Message;

			this.Document.DocumentElement.AppendChild(element);
		}

		private string GetXmlDataFilePath()
		{
			if (HttpContext.Current != null)
				return WebContext.GetCurrent().Server.MapPath(this.XmlDataFile);
			else
				return AppDomain.CurrentDomain.BaseDirectory + @"\" + this.XmlDataFile.Replace(@"/", @"\");
		}

		public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
		{
			if (config == null)
				throw new ArgumentNullException("config");
			if (string.IsNullOrEmpty(name))
				name = "AspNetXmlEventProvider";

			if (string.IsNullOrEmpty(config["description"]))
			{
				config.Remove("description");
				config.Add("description", "The default Xml Event Provider used for the Health Monitoring API.");
			}

			_xmlDataFile = config["xmlDataFile"];
			config.Remove("xmlDataFile");
			if (string.IsNullOrEmpty(_xmlDataFile))
				throw new ConfigurationErrorsException("The xmlDataFile property is not specified for the XmlEventProvider");

			//Make sure that the provider data file exists
			string path = this.GetXmlDataFilePath();

			if (!string.IsNullOrEmpty(path) &&  !File.Exists(path))
			{
				using (StreamWriter writer = File.CreateText(path))
					writer.Write("<Events></Events>");
			}

			base.Initialize(name, config);

			//If any configuration attributes are left, throw an exception
			if (config.Count > 0 && !string.IsNullOrEmpty(config.GetKey(0)))
				throw new ProviderException("There are too many configuration attributes specified");
		}

		public override void ProcessEventFlush(WebEventBufferFlushInfo flushInfo)
		{
			foreach (WebBaseEvent raisedEvent in flushInfo.Events)
				this.CreateEventElement(raisedEvent);
			this.Document.Save(this.GetXmlDataFilePath());
		}

		#endregion
	}
}
