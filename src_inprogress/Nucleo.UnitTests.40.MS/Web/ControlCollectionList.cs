using System;
using System.Text;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class ControlCollectionList
	{
		[
		TestMethod,
		ExpectedException(typeof(ArgumentOutOfRangeException))
		]
		public void AddingControlAtIncorrectIndexOfCorrectTypeThrowsException()
		{
			var coll = new ControlCollectionList<Panel>(new Label());

			coll.AddAt(1, new Panel());
		}

		[
		TestMethod,
		ExpectedException(typeof(InvalidOperationException))
		]
		public void AddingControlAtIndexOfIncorrectTypeThrowsException()
		{
			var coll = new ControlCollectionList<Panel>(new Panel());

			coll.AddAt(0, new Label());
		}

		[
		TestMethod
		]
		public void AddingControlOfCorrectTypeAddsOK()
		{
			var coll = new ControlCollectionList<Panel>(new Label());

			coll.Add(new Panel());

			Assert.AreEqual(1, coll.Count);
		}

		[
		TestMethod,
		ExpectedException(typeof(InvalidOperationException))
		]
		public void AddingControlOfIncorrectTypeThrowsException()
		{
			var coll = new ControlCollectionList<Panel>(new Panel());

			coll.Add(new Label());
		}

		[TestMethod]
		public void CreatingCollectionWithOwnerThrowsNoException()
		{
			var owner = new Panel();

			var coll = new ControlCollectionList<Panel>(owner);
		}
	}
}
