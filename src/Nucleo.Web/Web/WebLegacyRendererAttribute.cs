﻿using System;
using System.Collections.Generic;

using Nucleo.Attributes;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents an attribute to attach to controls to render using the legacy approach, which is the approach used by ASP.NET controls.  A <see cref="BaseAjaxControl">class inheriting from BaseAjaxControl</see> or <see cref="BaseAjaxExtender">BaseAjaxExtender</see> will check to see if this attribute exists, and use it for rendering purposes.
	/// </summary>
	/// <example>
	/// [WebLegacyRenderer(typeof(MyRenderer))]
	/// public class MyControl : BaseAjaxControl { }
	/// </example>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class WebLegacyRendererAttribute : Attribute, ITypeAttribute
	{
		private Type _rendererType = null;
		private string _rendererTypeName = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets a reference to the renderer, using a type instance.
		/// </summary>
		public Type RendererType
		{
			get { return _rendererType; }
			set { _rendererType = value; }
		}

		/// <summary>
		/// Gets or sets a reference to the name of the renderer, which must be type or type and assembly.
		/// </summary>
		public string RendererTypeName
		{
			get { return _rendererTypeName; }
			set { _rendererTypeName = value; }
		}

		/// <summary>
		/// Gets or sets a reference to the renderer, using a type instance.
		/// </summary>
		Type ITypeAttribute.Type
		{
			get { return this.RendererType; }
			set { this.RendererType = value; }
		}

		/// <summary>
		/// Gets or sets a reference to the name of the renderer, which must be type or type and assembly.
		/// </summary>
		string ITypeAttribute.TypeName
		{
			get { return this.RendererTypeName; }
			set { this.RendererTypeName = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the legacy attribute.
		/// </summary>
		public WebLegacyRendererAttribute() { }

		/// <summary>
		/// Creates the legacy attribute with the given type of the renderer.
		/// </summary>
		/// <param name="rendererType">The type of the renderer.</param>
		public WebLegacyRendererAttribute(Type rendererType)
		{
			_rendererType = rendererType;
		}

		/// <summary>
		/// Creates the legacy attribute with the given type name of the renderer.
		/// </summary>
		/// <param name="rendererTypeName">The type name of the renderer, which may need to include the assembly name.</param>
		public WebLegacyRendererAttribute(string rendererTypeName)
		{
			_rendererTypeName = rendererTypeName;
		}

		#endregion
	}
}
