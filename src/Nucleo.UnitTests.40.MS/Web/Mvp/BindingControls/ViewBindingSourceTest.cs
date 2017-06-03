using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Mvp.BindingControls
{
	[TestClass]
	public class ViewBindingSourceTest
	{
		[TestMethod]
		public void GettingAndSettingPropertiesAssignsOK()
		{
			var source = new ViewBindingSource();

			source.BindingOptions = new BindingOptions();
			source.ModelSource = "XYZ";
			source.UsePageAsSource = true;
			source.TargetControlID = "ABC";
			source.TargetControl = new Panels.SecurityPanel();

			Assert.AreEqual("ABC", source.TargetControlID);
			Assert.AreEqual(true, source.UsePageAsSource);
			Assert.AreEqual("XYZ", source.ModelSource);
			Assert.IsNotNull(source.BindingOptions);
			Assert.IsNotNull(source.TargetControl);
		}
	}
}
