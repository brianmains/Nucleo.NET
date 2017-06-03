using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo
{
	[TestClass]
	public class IdentifierTest
	{
		[TestMethod]
		public void CreatingFromGuidWorksAsExpected()
		{
			//arrange
			Guid key = Guid.Empty;

			//Act
			var id = Identifier.Create(key);

			//Assert
			Assert.AreEqual(Guid.Empty, id.Get());
		}

		[TestMethod]
		public void CreatingFromIntWorksAsExpected()
		{
			//arrange
			int key = 12;

			//Act
			var id = Identifier.Create(key);

			//Assert
			Assert.AreEqual(Convert.ToInt32(12), id.Get());
		}

		[TestMethod]
		public void CreatingFromLongWorksAsExpected()
		{
			//arrange
			long key = 12;

			//Act
			var id = Identifier.Create(key);

			//Assert
			Assert.AreEqual(Convert.ToInt64(12), id.Get());
		}

		[TestMethod]
		public void CreatingFromShortWorksAsExpected()
		{
			//arrange
			short key = 12;

			//Act
			var id = Identifier.Create(key);

			//Assert
			Assert.AreEqual(Convert.ToInt16(12), id.Get());
		}

		[TestMethod]
		public void GettingGenericallyReturnsCorrectValue()
		{
			//arrange
			short key = 12;
			var id = Identifier.Create(key);

			//Act
			var value = id.Get<short>();

			//Assert
			Assert.AreEqual(12, value);
		}
	}
}
