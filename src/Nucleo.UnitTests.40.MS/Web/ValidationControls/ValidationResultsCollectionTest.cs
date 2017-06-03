using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.ValidationControls
{
	[TestClass]
	public class ValidationResultsCollectionTest
	{
		[TestMethod]
		public void FindingByEmptyGroupWorksOK()
		{
			//Arrange
			var list = new ValidationResultsCollection
			{
				new ValidationResults { DefaultGroupName = "X" },
				new ValidationResults { DefaultGroupName = "", ID = "First" },
				new ValidationResults { DefaultGroupName = "Y" },
				new ValidationResults { DefaultGroupName = "", ID = "Second" },
				new ValidationResults { DefaultGroupName = "" }
			};

			//Act
			var output = list.FindByGroup(null).ToList();

			//Assert
			Assert.AreEqual(3, output.Count);
			Assert.AreEqual("First", output[0].ID);
			Assert.AreEqual("Second", output[1].ID);
			Assert.IsNull(output[2].ID);
		}

		[TestMethod]
		public void FindingByNullGroupWorksOK()
		{
			//Arrange
			var list = new ValidationResultsCollection
			{
				new ValidationResults { DefaultGroupName = "X" },
				new ValidationResults { DefaultGroupName = null, ID = "First" },
				new ValidationResults { DefaultGroupName = "Y" },
				new ValidationResults { DefaultGroupName = null, ID = "Second" },
				new ValidationResults { DefaultGroupName = null }
			};

			//Act
			var output = list.FindByGroup(null).ToList();

			//Assert
			Assert.AreEqual(3, output.Count);
			Assert.AreEqual("First", output[0].ID);
			Assert.AreEqual("Second", output[1].ID);
			Assert.IsNull(output[2].ID);
		}

		[TestMethod]
		public void FindingByNamedGroupWorksOK()
		{
			//Arrange
			var list = new ValidationResultsCollection
			{
				new ValidationResults { DefaultGroupName = "X" },
				new ValidationResults { DefaultGroupName = "Y", ID = "First" },
				new ValidationResults { DefaultGroupName = "Y" },
				new ValidationResults { DefaultGroupName = "Z" },
				new ValidationResults { DefaultGroupName = "" },
				new ValidationResults { DefaultGroupName = null }
			};

			//Act
			var output = list.FindByGroup("Y").ToList();

			//Assert
			Assert.AreEqual(2, output.Count);
			Assert.AreEqual("First", output[0].ID);
		}
	}
}
