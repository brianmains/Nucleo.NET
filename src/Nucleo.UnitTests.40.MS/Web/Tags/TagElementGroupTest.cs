using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Collections;


namespace Nucleo.Web.Tags
{
	[TestClass]
	public class TagElementGroupTest
	{
		#region " Tests "

		[TestMethod]
		public void PassingDictionaryAttributesToAllTagsWorksOK()
		{
			//Arrange
			var tagFake1 = Isolate.Fake.Instance<TagElement>(Members.CallOriginal);
			var tagFake2 = Isolate.Fake.Instance<TagElement>(Members.CallOriginal);

			var list = new TagElementCollection();
			list.AppendTag(tagFake1);
			list.AppendTag(tagFake2);

			var group = new TagElementGroup(list);

			var attributes = new Dictionary<string, object>();
			attributes.Add("type", "text");
			attributes.Add("value", "2");

			//Act
			group.ApplyAttributes(attributes);

			//Assert
			Assert.IsTrue(group.Tags.IsAll(i => i.Attributes.GetAttributeValue("type") == "text", ValidationIsAllCheck.True), "The type is not text");
		}

		[TestMethod]
		public void PassingDictionaryAttributesToSomeTagsWorksOK()
		{
			//Arrange
			var tagFake1 = Isolate.Fake.Instance<TagElement>(Members.CallOriginal);
			var tagFake2 = Isolate.Fake.Instance<TagElement>(Members.CallOriginal);

			var list = new TagElementCollection();
			list.AppendTag(tagFake1);
			list.AppendTag(tagFake2);

			var group = new TagElementGroup(list);

			var attributes = new Dictionary<string, object>();
			attributes.Add("type", "text");
			attributes.Add("value", "2");

			//Act
			group.ApplyAttributes(attributes, new AlternatingTagGroupRule(true));

			//Assert
			Assert.IsTrue(group.Tags.GetAlternatingItems(true).IsAllTrue(i => i.Attributes.GetAttributeValue("type") == "text"), "The type is not text");
		}

		[TestMethod]
		public void PassingObjectAttributesToAllTagsWorksOK()
		{
			//Arrange
			var tagFake1 = Isolate.Fake.Instance<TagElement>(Members.CallOriginal);
			var tagFake2 = Isolate.Fake.Instance<TagElement>(Members.CallOriginal);

			var list = new TagElementCollection();
			list.AppendTag(tagFake1);
			list.AppendTag(tagFake2);

			var group = new TagElementGroup(list);

			//Act
			group.ApplyAttributes(new { type = "text", value = "2" });

			//Assert
			Assert.IsTrue(group.Tags.IsAllTrue(i => i.Attributes.GetAttribute("type").Value == "text"), "The type is not text");
		}

		[TestMethod]
		public void PassingObjectAttributesToSomeTagsWorksOK()
		{
			//Arrange
			var tagFake1 = Isolate.Fake.Instance<TagElement>(Members.CallOriginal);
			var tagFake2 = Isolate.Fake.Instance<TagElement>(Members.CallOriginal);
			var tagFake3 = Isolate.Fake.Instance<TagElement>(Members.CallOriginal);
			var tagFake4 = Isolate.Fake.Instance<TagElement>(Members.CallOriginal);

			var list = new TagElementCollection();
			list.AppendTag(tagFake1);
			list.AppendTag(tagFake2);
			list.AppendTag(tagFake3);
			list.AppendTag(tagFake4);

			var group = new TagElementGroup(list);

			//Act
			group.ApplyAttributes(new { type = "text", value = "2" }, new AlternatingTagGroupRule(true));

			var groupItems = group.Tags.GetAlternatingItems(false);

			//Assert
			foreach (var groupItem in groupItems)
			{
				if ("text" != (string)groupItem.Attributes.GetAttributeValue("type"))
					Assert.Fail("The type attribute is not a value of 'text'.");
			}
		}

		#endregion
	}
}
