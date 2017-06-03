using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Validation
{
	[TestClass]
	public class DataErrorInfoValidationProviderTest
	{
		#region " Test Class "

		protected class TestClass : IDataErrorInfo
		{
			public string Name { get; set; }
			public string City { get; set; }
			public string State { get; set; }



			#region IDataErrorInfo Members

			public string Error
			{
				get { return null; }
			}

			public string this[string columnName]
			{
				get
				{
					if (columnName == "Name" && string.IsNullOrEmpty(this.Name))
						return "Please enter a name";
					else if (columnName == "City" && string.IsNullOrEmpty(this.City))
						return "Please enter a city";
					else if (columnName == "State" && string.IsNullOrEmpty(this.State))
						return "Please enter a state";
					else
						return null;
				}
			}

			#endregion
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void IsValidProviderReturnsFalseWhenNotImplementingIDataErrorInfo()
		{
			//Arrange
			var test = new System.Data.DataTable();
			var provider = new DataErrorInfoValidationProvider();

			//Act
			var result = provider.IsCorrectValidator(test);

			//Assert
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void IsValidProviderReturnsTrueWhenImplementingIDataErrorInfo()
		{
			//Arrange
			var test = new TestClass { Name = "Test", City = "Paris", State = "TX" };
			var provider = new DataErrorInfoValidationProvider();

			//Act
			var result = provider.IsCorrectValidator(test);

			//Assert
			Assert.AreEqual(true, result);
		}

		#endregion
	}
}
