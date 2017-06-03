using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.EventArguments;
using Nucleo.Web;


namespace Nucleo.Extensions
{
	[TestClass]
	public class DictionaryEventArgsExtensionsTest
	{
		[TestMethod]
		public void CopyingToArgsAssignsOK()
		{
			var args = new DictionaryEventArgs();
			var form = new FormCollection(new Dictionary<string, string>
			{
				{ "FirstName", "Tom" },
				{ "LastName", "Smith" }
			});

			args.CopyFromForm(form);

			Assert.AreEqual("Tom", args.Get("FirstName", null));
			Assert.AreEqual("Smith", args.Get("LastName", null));
		}
	}
}
