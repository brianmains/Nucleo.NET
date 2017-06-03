using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace Nucleo.Data
{
	public static class DataTypeUtility
	{
		public static DbType GetDatabaseType<T>()
		{
			if (System.Enum.IsDefined(typeof(DbType), typeof(T).Name))
				return (DbType)System.Enum.Parse(typeof(DbType), typeof(T).Name);
			else if (typeof(T).Equals(typeof(char)))
				return DbType.StringFixedLength;
			else
				return DbType.Object;
		}

		public static SqlDbType GetSqlDatabaseType<T>(bool useInvariants)
		{
			if (typeof(T).Equals(typeof(string)))
				return useInvariants ? SqlDbType.NVarChar : SqlDbType.VarChar;
			else if (typeof(T).Equals(typeof(Guid)))
				return SqlDbType.UniqueIdentifier;
			else if (typeof(T).Equals(typeof(char)))
				return useInvariants ? SqlDbType.NChar : SqlDbType.Char;
			else if (typeof(T).Equals(typeof(bool)))
				return SqlDbType.Bit;
			else if (typeof(T).Equals(typeof(int)))
				return SqlDbType.Int;
			else if (typeof(T).Equals(typeof(long)))
				return SqlDbType.BigInt;
			else if (typeof(T).Equals(typeof(short)))
				return SqlDbType.SmallInt;
			else if (typeof(T).Equals(typeof(byte)))
				return SqlDbType.TinyInt;
			else if (typeof(T).Equals(typeof(byte[])))
				return SqlDbType.Binary;
			else if (System.Enum.IsDefined(typeof(SqlDbType), typeof(T).Name))
				return (SqlDbType)System.Enum.Parse(typeof(SqlDbType), typeof(T).Name);

			return SqlDbType.VarChar;
		}
	}
}
