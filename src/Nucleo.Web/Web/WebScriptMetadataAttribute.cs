using System;
using System.Collections.Generic;

using Nucleo.Attributes;


namespace Nucleo.Web
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class WebScriptMetadataAttribute : Attribute, ITypeAttribute
	{
		private Type _metadataType = null;
		private string _metadataTypeName = null;



		#region " Properties "

		public Type MetadataType
		{
			get { return _metadataType; }
			set { _metadataType = value; }
		}

		public string MetadataTypeName
		{
			get { return _metadataTypeName; }
			set { _metadataTypeName = value; }
		}

		Type ITypeAttribute.Type
		{
			get { return this.MetadataType; }
			set { this.MetadataType = value; }
		}

		string ITypeAttribute.TypeName
		{
			get { return this.MetadataTypeName; }
			set { this.MetadataTypeName = value; }
		}

		#endregion



		#region " Constructors "

		public WebScriptMetadataAttribute(Type metadataType)
		{
			_metadataType = metadataType;
		}

		public WebScriptMetadataAttribute(string metadataTypeName)
		{
			_metadataTypeName = metadataTypeName;
		}

		#endregion
	}
}
