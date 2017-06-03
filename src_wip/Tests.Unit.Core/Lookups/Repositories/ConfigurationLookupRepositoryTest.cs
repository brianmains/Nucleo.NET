using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Configuration;
using Nucleo.Lookups.Configuration;
using Nucleo.Lookups.Identification;


namespace Nucleo.Lookups.Repositories
{
	[TestClass]
	public class ConfigurationLookupRepositoryTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingLookupValuesWorksCorrectly()
		{
			//Arrange
			var config = new LookupRepositoriesSection();

			var group = new LookupGroupElement { LookupName = "Test" };
			config.Groups.Add(group);

			group.Values.Add(new LookupElement
			{
				Name = "First", 
				Value = "1", 
				RepresentationCode = "F", 
				EffectiveDate = DateTime.MinValue, 
				EndDate = DateTime.MaxValue
			});
			group.Values.Add(new LookupElement
			{
				Name = "Second",
				Value = "2",
				RepresentationCode = "S",
				EffectiveDate = new DateTime(2007, 1, 1),
				EndDate = DateTime.MaxValue
			});
			group.Values.Add(new LookupElement
			{
				Name = "Third",
				Value = "3",
				RepresentationCode = "TH",
				EffectiveDate = DateTime.MinValue,
				EndDate = new DateTime(2007, 1, 1)
			});
			group.Values.Add(new LookupElement
			{
				Name = "Fourth",
				Value = "4",
				RepresentationCode = "FO",
				EffectiveDate = DateTime.MinValue,
				EndDate = new DateTime(2006, 12, 31)
			});
			group.Values.Add(new LookupElement
			{
				Name = "Fifth",
				Value = "5",
				RepresentationCode = "FI",
				EffectiveDate = new DateTime(2007, 1, 2),
				EndDate = DateTime.MaxValue
			});

			Isolate.Fake.StaticMethods(typeof(LookupRepositoriesSection));
			Isolate.WhenCalled(() => LookupRepositoriesSection.Instance).WillReturn(config);

			//Act
			var repos = new ConfigurationLookupRepository();
			var values = repos.GetAllValues(new LookupCriteria(new NameLookupIdentifier { Name = "Test" }, new DateTime(2007, 1, 1)));

			//Assert
			Assert.AreEqual(3, values.Count);
			Assert.AreEqual("First", values[0].Name);
			Assert.AreEqual("Second", values[1].Name);
			Assert.AreEqual("Third", values[2].Name);

			Isolate.CleanUp();
		}

		#endregion
	}
}
