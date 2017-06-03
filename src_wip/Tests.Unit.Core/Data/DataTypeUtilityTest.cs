using System;
using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Data
{
	[TestClass]
	public class DataTypeUtilityTest
	{
		#region " Tests "

		[TestMethod]
		public void ConvertingToSqlBitTypeWorksOK()
		{
			//Arrange

			//Act
			var variant = DataTypeUtility.GetSqlDatabaseType<bool>(false);
			var invariant = DataTypeUtility.GetSqlDatabaseType<bool>(true);

			//Assert
			Assert.AreEqual(SqlDbType.Bit, variant);
			Assert.AreEqual(SqlDbType.Bit, invariant);
		}

		[TestMethod]
		public void ConvertingToSqlByteArrayTypeWorksOK()
		{
			//Arrange

			//Act
			var variant = DataTypeUtility.GetSqlDatabaseType<byte[]>(false);
			var invariant = DataTypeUtility.GetSqlDatabaseType<byte[]>(true);

			//Assert
			Assert.AreEqual(SqlDbType.Binary, variant);
			Assert.AreEqual(SqlDbType.Binary, invariant);
		}

		[TestMethod]
		public void ConvertingToSqlByteTypeWorksOK()
		{
			//Arrange

			//Act
			var variant = DataTypeUtility.GetSqlDatabaseType<byte>(false);
			var invariant = DataTypeUtility.GetSqlDatabaseType<byte>(true);

			//Assert
			Assert.AreEqual(SqlDbType.TinyInt, variant);
			Assert.AreEqual(SqlDbType.TinyInt, invariant);
		}

		[TestMethod]
		public void ConvertingToSqlCharTypeWorksOK()
		{
			//Arrange

			//Act
			var variant = DataTypeUtility.GetSqlDatabaseType<char>(false);
			var invariant = DataTypeUtility.GetSqlDatabaseType<char>(true);

			//Assert
			Assert.AreEqual(SqlDbType.Char, variant);
			Assert.AreEqual(SqlDbType.NChar, invariant);
		}

		[TestMethod]
		public void ConvertingToSqlDateTimeTypeWorksOK()
		{
			//Arrange

			//Act
			var variant = DataTypeUtility.GetSqlDatabaseType<DateTime>(false);
			var invariant = DataTypeUtility.GetSqlDatabaseType<DateTime>(true);

			//Assert
			Assert.AreEqual(SqlDbType.DateTime, variant);
			Assert.AreEqual(SqlDbType.DateTime, invariant);
		}

		[TestMethod]
		public void ConvertingToSqlGuidTypeWorksOK()
		{
			//Arrange

			//Act
			var variant = DataTypeUtility.GetSqlDatabaseType<Guid>(false);
			var invariant = DataTypeUtility.GetSqlDatabaseType<Guid>(true);

			//Assert
			Assert.AreEqual(SqlDbType.UniqueIdentifier, variant);
			Assert.AreEqual(SqlDbType.UniqueIdentifier, invariant);
		}

		[TestMethod]
		public void ConvertingToSqlIntTypeWorksOK()
		{
			//Arrange

			//Act
			var variant = DataTypeUtility.GetSqlDatabaseType<int>(false);
			var invariant = DataTypeUtility.GetSqlDatabaseType<int>(true);

			//Assert
			Assert.AreEqual(SqlDbType.Int, variant);
			Assert.AreEqual(SqlDbType.Int, invariant);
		}

		[TestMethod]
		public void ConvertingToSqlLongTypeWorksOK()
		{
			//Arrange

			//Act
			var variant = DataTypeUtility.GetSqlDatabaseType<long>(false);
			var invariant = DataTypeUtility.GetSqlDatabaseType<long>(true);

			//Assert
			Assert.AreEqual(SqlDbType.BigInt, variant);
			Assert.AreEqual(SqlDbType.BigInt, invariant);
		}

		[TestMethod]
		public void ConvertingToSqlShortTypeWorksOK()
		{
			//Arrange

			//Act
			var variant = DataTypeUtility.GetSqlDatabaseType<short>(false);
			var invariant = DataTypeUtility.GetSqlDatabaseType<short>(true);

			//Assert
			Assert.AreEqual(SqlDbType.SmallInt, variant);
			Assert.AreEqual(SqlDbType.SmallInt, invariant);
		}

		[TestMethod]
		public void ConvertingToSqlVarcharTypeWorksOK()
		{
			//Arrange

			//Act
			var variant = DataTypeUtility.GetSqlDatabaseType<string>(false);
			var invariant = DataTypeUtility.GetSqlDatabaseType<string>(true);

			//Assert
			Assert.AreEqual(SqlDbType.VarChar, variant);
			Assert.AreEqual(SqlDbType.NVarChar, invariant);
		}
		
		[TestMethod]
		public void GettingStandardDatabaseTypesWorksOK()
		{
			//Arrange
			
			//Act
			var val1 = DataTypeUtility.GetDatabaseType<Int32>();
			var val2 = DataTypeUtility.GetDatabaseType<DateTime>();
			var val3 = DataTypeUtility.GetDatabaseType<Boolean>();
			var val4 = DataTypeUtility.GetDatabaseType<decimal>();

			//Assert
			Assert.AreEqual(DbType.Int32, val1);
			Assert.AreEqual(DbType.DateTime, val2);
			Assert.AreEqual(DbType.Boolean, val3);
			Assert.AreEqual(DbType.Decimal, val4);
		}

		[TestMethod]
		public void GettingStringDatabaseTypesWorksOK()
		{
			//Arrange

			//Act
			var val1 = DataTypeUtility.GetDatabaseType<string>();
			var val2 = DataTypeUtility.GetDatabaseType<char>();

			//Assert
			Assert.AreEqual(DbType.String, val1);
			Assert.AreEqual(DbType.StringFixedLength, val2);
		}

		#endregion
	}
}
