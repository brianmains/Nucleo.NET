using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.IO
{
	[TestClass]
	public class BinarySerializerTest
	{
		private string _filePath = AppDomain.CurrentDomain.BaseDirectory + @"\binaryserializationtest.txt";



		#region " Tests "

		[TestInitialize]
		public void Initialize()
		{
			if (File.Exists(_filePath))
				File.Delete(_filePath);
		}

		[TestCleanup]
		public void Shutdown()
		{
			if (File.Exists(_filePath))
				File.Delete(_filePath);
		}

		[TestMethod]
		public void TestCopyingListDataToFromArray()
		{
			List<int> intList = new List<int>();
			intList.Add(1);
			intList.Add(5);
			intList.Add(7);
			intList.Add(14);
			intList.Add(19);
			intList.Add(24);

			byte[] serialData = BinarySerializer.SerializeToBytes(intList);
			Assert.IsNotNull(serialData);
			Assert.IsTrue(serialData.Length > 0);

			List<int> outData = BinarySerializer.DeserializeFromBytes<List<int>>(serialData);
			Assert.IsNotNull(outData);
			Assert.AreEqual(6, outData.Count);
		}

		[TestMethod]
		public void TestCopyingListDataToFromFile()
		{
			List<int> intList = new List<int>();
			intList.Add(1);
			intList.Add(5);
			intList.Add(7);
			intList.Add(14);
			intList.Add(19);
			intList.Add(24);

			BinarySerializer.SerializeToFile(_filePath, intList);
			Assert.IsTrue(File.Exists(_filePath));

			List<int> outData = BinarySerializer.DeserializeFromFile<List<int>>(_filePath);
			Assert.IsNotNull(outData);
			Assert.AreEqual(6, outData.Count);
		}

		[TestMethod]
		public void TestCopyingStringDataToFromArray()
		{
			string data = "This is a message that I will serialize to a file";
			byte[] serialData = BinarySerializer.SerializeToBytes(data);
			Assert.IsNotNull(serialData);
			Assert.IsTrue(serialData.Length > 0);

			string outData = BinarySerializer.DeserializeFromBytes<string>(serialData);
			Assert.AreEqual("This is a message that I will serialize to a file", outData);
		}

		[TestMethod]
		public void TestCopyingStringDataToFromFile()
		{
			string data = "This is a message that I will serialize to a file";
			BinarySerializer.SerializeToFile(_filePath, data);
			Assert.IsTrue(File.Exists(_filePath));

			using (StreamReader reader = new StreamReader(_filePath))
				Assert.AreNotEqual(reader.ReadToEnd(), data);

			string outData = BinarySerializer.DeserializeFromFile<string>(_filePath);
			Assert.AreEqual("This is a message that I will serialize to a file", outData);
		}

		#endregion
	}
}
