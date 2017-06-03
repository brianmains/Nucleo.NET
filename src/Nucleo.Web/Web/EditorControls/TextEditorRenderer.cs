using System;
using System.Collections.Generic;

using Nucleo.Web.Tags;


namespace Nucleo.Web.EditorControls
{
	public class TextEditorRenderer : WebRenderer
	{
		#region " Properties "

		new public TextEditor Component
		{
			get { return (TextEditor)base.Component; }
		}

		#endregion



		#region " Methods "

		public override TagElement Render()
		{
			TagElement tag = TagElementBuilder.Create("INPUT");
			CommonTagSettings.SetIdentifiers(tag, this.Component);

			tag.Attributes.AppendAttribute("type", "text");
			if (this.Component.CurrentState == EditorCurrentState.Normal)
				tag.Attributes.AppendAttribute("class", "NucleoTextEditorNormalState");	
			else
				tag.Attributes.AppendAttribute("class", "NucleoTextEditorErrorState");
			if (this.Component.ReadOnly)
				tag.Attributes.AppendAttribute("disabled", "disabled");

			tag.Attributes.AppendAttribute("value", this.Component.Text);

			TagElement parent = TagElementBuilder.Create("SPAN");
			parent.Attributes.AppendAttribute("id", this.Component.WrapperClientID)
				.AppendAttribute("name", this.Component.WrapperUniqueID);
			parent.Children.AppendTag(tag);

			return parent;
		}

		#endregion
	}
}
