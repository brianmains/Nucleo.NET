using System;
using System.IO;
using System.ComponentModel;
using System.Web.UI;


namespace Nucleo.Web.ClientSettings
{
	public class WebServiceSettings : IScriptComponent
	{
		private string _propertyName = null;
		private int _timeLimit = 0;
		private string _url = null;



		#region " Constants "

		public const string PropertyName = "webServiceSettings";

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets or sets the time limit to limit the web service call with.
		/// </summary>
		public int TimeLimit
		{
			get { return _timeLimit; }
			set { _timeLimit = value; }
		}

		/// <summary>
		/// Gets or sets the url of a web service to use.
		/// </summary>
		[
		Category("Binding"),
		Description("The URL to bind the web service to"),
		UrlProperty
		]
		public string Url
		{
			get { return _url; }
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_url = null;
					return;
				}

				string extension = Path.GetExtension(value);
				if (extension == null)
					throw new ArgumentException("The web service url doesn't have a valid extension", "value");

				extension = extension.ToLower().Substring(1);

				if (!(extension == "aspx" || extension == "asmx" || extension == "svc"))
					throw new ArgumentException("Only ASPX, ASMX and SVC files are allowed");

				_url = value;
			}
		}

		#endregion



		#region " Constructors "

		public WebServiceSettings() { }

		public WebServiceSettings(string propertyName)
		{
			_propertyName = propertyName;
		}

		#endregion



		#region " Methods "

		void IScriptComponent.RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			string propName = !string.IsNullOrEmpty(_propertyName) ? _propertyName : PropertyName;
			currentDescriptor.AddProperty(propName, this);
		}

		void IScriptComponent.RegisterAjaxReferences(IContentRegistrar registrar)
		{
			
		}

		#endregion
	}
}
