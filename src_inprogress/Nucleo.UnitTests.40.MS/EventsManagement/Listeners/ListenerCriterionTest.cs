using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.EventsManagement.Listeners
{
	[TestClass]
	public class ListenerCriterionTest
	{
		#region " Test Classes "

		protected class TestClass
		{

		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void SettingUpAnyCriteriaWorksOK()
		{
			//Arrange
			
			//Act
			var criteria = ListenerCriterion.Any();

			//Assert
			Assert.IsInstanceOfType(criteria, typeof(AnyListenerCriteria));
		}

		[TestMethod]
		public void SettingUpEntityCriteriaWithGenericWorksOK()
		{
			//Arrange

			//Act
			var criteria = ListenerCriterion.EntityType<TestClass>();

			//Assert
			Assert.IsInstanceOfType(criteria, typeof(EntityTypeListenerCriteria));
		}

		[TestMethod]
		public void SettingUpEntityCriteriaWorksOK()
		{
			//Arrange

			//Act
			var criteria = ListenerCriterion.Entity(typeof(TestClass));

			//Assert
			Assert.IsInstanceOfType(criteria, typeof(EntityListenerCriteria));
		}

		[TestMethod]
		public void SettingUpNameCriteriaWorksOK()
		{
			//Arrange
			var obj = "Test";

			//Act
			var criteria = ListenerCriterion.Identifier(obj);

			//Assert
			Assert.IsInstanceOfType(criteria, typeof(NameIdentifierListenerCriteria));
		}

		#endregion
	}
}
