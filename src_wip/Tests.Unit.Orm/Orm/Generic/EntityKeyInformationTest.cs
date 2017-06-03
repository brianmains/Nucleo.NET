using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Orm.Generic
{
	[TestClass]
	public class EntityKeyInformationTest
	{
		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			var info = new EntityKeyInformation();

			info.EntityName = "X";
			info.EntityType = typeof(EntityKeyInformation);
			info.KeyName = "Y";
			info.KeyValue = 123;

			Assert.AreEqual("X", info.EntityName);
			Assert.AreEqual(typeof(EntityKeyInformation), info.EntityType);
			Assert.AreEqual("Y", info.KeyName);
			Assert.AreEqual(123, info.KeyValue);
		}
	}
}
