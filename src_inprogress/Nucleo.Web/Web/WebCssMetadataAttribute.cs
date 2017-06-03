using System;
using System.Collections.Generic;

using Nucleo.Attributes;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents CSS metadata that's applied using reflection, by specifying the attribute.  Works like the AJAX control toolkit, but more flexible because the <see cref="WebCssMetadata">WebCssMetadata</see> class gives you more control.
	/// </summary>
	/// <seealso cref="WebCssMetadata"/>
	/// <example>
	/// //MyCustomControlCssMetadata is a class that inherits from WebCssMetadata.
	/// [WebCssMetadata(typeof(MyCustomControlCssMetadata))]
	/// public class MyCustomControl : BaseAjaxControl
	/// </example>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class WebCssMetadataAttribute : Attribute, ITypeAttribute
	{
		private Type _metadataType = null;
		private string _metadataTypeName = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the type of CSS metadata class.  Must be of type WebCssMetadata.
		/// </summary>
		public Type MetadataType
		{
			get { return _metadataType; }
			set { _metadataType = value; }
		}

		/// <summary>
		/// Gets or sets the type name of the CSS metadata class.  Must be of type WebCssMetadata.
		/// </summary>
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

		public WebCssMetadataAttribute(Type metadataType)
		{
			_metadataType = metadataType;
		}

		public WebCssMetadataAttribute(string metadataTypeName)
		{
			_metadataTypeName = metadataTypeName;
		}

		#endregion
	}
}
