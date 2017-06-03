using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web;


namespace Nucleo.Extensions
{
	[TestClass]
	public class BaseControlWriterExtensionsTest
	{
		[TestMethod]
		public void WritingBeginTagWithAttributesAndStylesWorksOK()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteBeginTag("div", new { border = 0, width = "100px", height = "100px" }, new { display = "none", padding = "0px" });
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div border=\"0\" width=\"100px\" height=\"100px\" style=\"display:none;padding:0px\">", output);
		}

		[TestMethod]
		public void WritingBeginTagWithAttributesWorksOK()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteBeginTag("div", new { border = 0, width = "100px", height = "100px" });
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div border=\"0\" width=\"100px\" height=\"100px\">", output);
		}

		[TestMethod]
		public void WritingBeginTagWithIDAndNameWorksOK()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteBeginTag("div", "ABC", "DEF");
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div id=\"ABC\" name=\"DEF\">", output);
		}

		[TestMethod]
		public void WritingBeginTagWithEmptyIDAndNameRendersName()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteBeginTag("div", string.Empty, "DEF");
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div name=\"DEF\">", output);
		}

		[TestMethod]
		public void WritingBeginTagWithIDAndEmptyNameRendersName()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteBeginTag("div", "DEF", string.Empty);
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div id=\"DEF\">", output);
		}

		[TestMethod]
		public void WritingBeginTagWithIDAndNullNameRendersID()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteBeginTag("div", "DEF", null);
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div id=\"DEF\">", output);
		}

		[TestMethod]
		public void WritingBeginTagWithNullIDAndNameRendersID()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteBeginTag("div", null, "DEF");
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div name=\"DEF\">", output);
		}

		[TestMethod]
		public void WritingBeginTagWorksOK()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteBeginTag("div");
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div>", output);
		}

		[TestMethod]
		public void WritingEndTagWorksOK()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteEndTag("div");
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("</div>", output);
		}

		[TestMethod]
		public void WritingUnclosedBeginTagWithAttributesAndStylesWorksOK()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteUnclosedBeginTag("div", new { border = 0, width = "100px", height = "100px" }, new { display = "none", padding = "0px" });
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div border=\"0\" width=\"100px\" height=\"100px\" style=\"display:none;padding:0px\"", output);
		}

		[TestMethod]
		public void WritingUnclosedBeginTagWithAttributesWorksOK()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteUnclosedBeginTag("div", new { border = 0, width = "100px", height = "100px" });
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div border=\"0\" width=\"100px\" height=\"100px\"", output);
		}

		[TestMethod]
		public void WritingUnclosedBeginTagWorksOK()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteUnclosedBeginTag("div");
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div", output);
		}

		[TestMethod]
		public void WritingUnclosedBeginTagWithIDAndNameWorksOK()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteUnclosedBeginTag("div", "ABC", "DEF");
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div id=\"ABC\" name=\"DEF\"", output);
		}

		[TestMethod]
		public void WritingUnclosedBeginTagWithEmptyIDAndNameRendersName()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteUnclosedBeginTag("div", string.Empty, "DEF");
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div name=\"DEF\"", output);
		}

		[TestMethod]
		public void WritingUnclosedBeginTagWithIDAndEmptyNameRendersName()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteUnclosedBeginTag("div", "DEF", string.Empty);
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div id=\"DEF\"", output);
		}

		[TestMethod]
		public void WritingUnclosedBeginTagWithIDAndNullNameRendersID()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteUnclosedBeginTag("div", "DEF", null);
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div id=\"DEF\"", output);
		}

		[TestMethod]
		public void WritingUnclosedBeginTagWithNullIDAndNameRendersID()
		{
			//Arrange
			var writer = new StringControlWriter();

			//Act
			writer.WriteUnclosedBeginTag("div", null, "DEF");
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<div name=\"DEF\"", output);
		}
	}
}
