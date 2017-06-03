using System;
using System.Collections.Generic;

using Nucleo.Web.Tags;


namespace Nucleo.Web.MappingControls
{
	public class ControlMappingManagerRenderer : WebRenderer
	{
		#region " Properties "

		new public ControlMappingManager Component
		{
			get { return (ControlMappingManager)base.Component; }
		}

		#endregion



		#region " Methods "

		public override TagElement Render()
		{
			TagElement element = TagElementBuilder.Create("INPUT");
			element.Attributes.AppendAttribute("TYPE", "HIDDEN");
			CommonTagSettings.SetIdentifiers(element, this.Component);

			return element;
		}

		#endregion
	}
}
