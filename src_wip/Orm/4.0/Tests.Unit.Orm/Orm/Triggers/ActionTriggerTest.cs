using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Orm.Triggers
{
	[TestClass]
	public class ActionTriggerTest
	{
		[TestMethod]
		public void CreatingTriggerAssignsThrowsNoExceptions()
		{
			//Arrange
			//Act
			var trigger = new ActionTrigger(true, (o, td) => { });

			//Assert
			Assert.IsTrue(trigger.IsForObject(new object(), TriggerAction.Insert));
		}

		[TestMethod]
		public void FiringActionWorksOK()
		{
			//Arrange
			var result = false;
			var trigger = new ActionTrigger(true, (o, td) => { result = true; });

			//Act
			trigger.Fire(new object(), TriggerAction.Insert);

			//Assert
			Assert.AreEqual(true, result);
		}
	}
}
