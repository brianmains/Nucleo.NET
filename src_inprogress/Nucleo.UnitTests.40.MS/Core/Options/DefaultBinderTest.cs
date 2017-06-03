using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Presentation.Creation;
using Nucleo.Presentation.Discovery;


namespace Nucleo.Core.Options
{
	[TestClass]
	public class DefaultBinderTest
	{
		[TestMethod]
		public void CreatingOptionsWorksOK()
		{
			var options = DefaultBuilder.Create();

			Assert.IsInstanceOfType(options.Creator, typeof(DefaultPresenterCreator));
			Assert.IsInstanceOfType(options.DiscoveryStrategy, typeof(DefaultPresentationDiscoveryStrategy));
			Assert.IsNull(options.Cache);
		}
	}
}
