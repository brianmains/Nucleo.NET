using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Collections;
using Nucleo.Attributes;


namespace Nucleo.Models
{
	[TestClass]
	public class ModelValueEntryTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingModelValuePropertiesWorksOK()
		{
			//Arrange
			var model = new ModelValueEntry();
			var def = Isolate.Fake.Instance<IModelInjection>();

			//Act
			model.Name = "X";
			model.Value = "A";
			model.Attributes = new ObjectCollection
			{
				new DescriptionAttribute("Test"),
				new TestMethodAttribute()
			};
			model.InjectionDefinition = def;

			//Assert
			Assert.AreEqual("X", model.Name);
			Assert.AreEqual("A", model.Value);
			Assert.AreEqual(2, model.Attributes.Count);
			Assert.AreEqual(def, model.InjectionDefinition);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingValueAsIntegerWorksOK()
		{
			//Arrange
			var model = new ModelValueEntry { Value = "123" };

			//Act
			var value = model.GetValue<int>();

			//Assert
			Assert.AreEqual(123, value);
		}

		[TestMethod]
		public void GettingValueAsStringWorksOK()
		{
			//Arrange
			var model = new ModelValueEntry { Value = "XYZ" };

			//Act
			var value = model.GetValue<string>();

			//Assert
			Assert.AreEqual("XYZ", value);
		}

		#endregion
	}
}
