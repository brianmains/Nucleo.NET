using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class ControlRenderingUtilityTest
	{
		#region " Tests "

		[TestMethod]
		public void RenderBackgroundImageWorksOK()
		{
			StringWriter textWriter = new StringWriter();
			HtmlTextWriter htmlWriter = new HtmlTextWriter(textWriter);

			ControlRenderingUtility.RenderBackgroundImage(htmlWriter, "images/background.jpg");
			htmlWriter.RenderBeginTag("a");

			StringAssert.Contains(textWriter.ToString(), "background-image:url(images/background.jpg);");
		}

		[TestMethod]
		public void RenderingBorderWorksOK()
		{
			StringWriter textWriter = new StringWriter();
			HtmlTextWriter htmlWriter = new HtmlTextWriter(textWriter);

			Style style = new Style();
			style.BorderColor = Color.Red;
			style.BorderStyle = BorderStyle.NotSet;
			style.BorderWidth = Unit.Pixel(1);

			ControlRenderingUtility.RenderBorder(htmlWriter, style);
			htmlWriter.RenderBeginTag("a");

			StringAssert.Contains(textWriter.ToString(), "border-color:Red;border-width:1px;");
			htmlWriter.Close();
		}

		#endregion
	}
}
