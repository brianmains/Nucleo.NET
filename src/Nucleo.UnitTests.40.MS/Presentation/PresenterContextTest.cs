using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Context;
using Nucleo.EventsManagement;
using Nucleo.Models;
using Nucleo.Navigation;


namespace Nucleo.Presentation
{
	[TestClass]
	public class PresenterContextTest
	{
		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var ctx = new PresenterContext();
			var events = Isolate.Fake.Instance<EventsRegistry>();
			var injection = Isolate.Fake.Instance<ModelInjectionManager>();

			//Act
			ctx.EventRegistry = events;
			ctx.ModelInjection = injection;

			//Assert
			Assert.AreEqual(events, ctx.EventRegistry);
			Assert.AreEqual(injection, ctx.ModelInjection);

			Isolate.CleanUp();
		}
	}
}
