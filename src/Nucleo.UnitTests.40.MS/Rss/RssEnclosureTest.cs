using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Rss
{
	[TestClass]
	public class RssEnclosureTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingEnclosureWorksOK()
		{
			//Arrange
			var enc = default(RssEnclosure);

			//Act
			enc = new RssEnclosure(new Uri("http://a.com/a.mp3"), "audio/mpeg", 34567890);

			//Assert
			Assert.AreEqual("audio/mpeg", enc.Type);
			Assert.AreEqual(34567890, enc.Length);
			Assert.AreEqual("http://a.com/a.mp3", enc.Url.ToString());
		}

		#endregion
	}
}
