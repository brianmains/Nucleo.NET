using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Nucleo.Web;
using Nucleo.Web.Tags;


namespace Nucleo.SampleComponents
{
	public class SampleAttributeControlRenderer : WebRenderer
	{
		new public SampleAttributeControl Component
		{
			get { return (SampleAttributeControl)base.Component; }
		}

		public override TagElement Render()
		{
			TagElement element = TagElementBuilder.Create("SPAN");
			element.Attributes.AppendAttribute("id", this.Component.ClientID);
			element.Attributes.AppendAttribute("name", this.Component.UniqueID);

			element.Attributes.AppendAttribute("margin", "3px");
			element.Content = this.Component.Text;

			return element;
		}
	}
}
