using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.EventArguments
{
	[TestClass]
	public class DictionaryEventArgsTest
	{
		[TestMethod]
		public void AddingArgumentsWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, object>();
			var args = new DictionaryEventArgs(dict);

			//Act
			args.Add("A", 1);

			//Assert
			Assert.AreEqual(1, dict["A"]);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void AddingEmptyArgumentsFails()
		{
			//Arrange
			var args = new DictionaryEventArgs();

			//Act
			args.Add("", 1);

			//Assert
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void AddingNullArgumentsFails()
		{
			//Arrange
			var args = new DictionaryEventArgs();

			//Act
			args.Add(null, 1);

			//Assert
		}

		[TestMethod]
		public void CreatingDictionaryArgsWithDictWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, object>();

			//Act
			var args = new DictionaryEventArgs(dict);

			//Assert

		}

		[TestMethod]
		public void CreatingDictionaryArgsWorksOK()
		{

			//Act
			var args = new DictionaryEventArgs();

			//Assert
			
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void GettingEmptyArgumentsFails()
		{
			//Arrange
			var args = new DictionaryEventArgs();

			//Act
			args.Get("", null);

			//Assert
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void GettingEmptyArgumentsWithGenericsFails()
		{
			//Arrange
			var args = new DictionaryEventArgs();

			//Act
			args.Get<int>("", 1);

			//Assert
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void GettingNullArgumentsFails()
		{
			//Arrange
			var args = new DictionaryEventArgs();

			//Act
			args.Get(null, null);

			//Assert
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void GettingNullArgumentsWithGenericsFails()
		{
			//Arrange
			var args = new DictionaryEventArgs();

			//Act
			args.Get<int>(null, 1);

			//Assert
		}

		[TestMethod]
		public void RemovingArgumentsWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, object>();
			dict.Add("A", 1);
			var args = new DictionaryEventArgs(dict);

			//Act
			args.Remove("A");

			//Assert
			Assert.IsFalse(dict.ContainsKey("A"));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void RemovingEmptyArgumentsFails()
		{
			//Arrange
			var args = new DictionaryEventArgs();

			//Act
			args.Remove("");

			//Assert
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void RemovingNullArgumentsFails()
		{
			//Arrange
			var args = new DictionaryEventArgs();

			//Act
			args.Remove(null);

			//Assert
		}
	}
}
