using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Rss
{
	[TestClass]
	public class RssReaderTest
	{
		#region " Tests "

		[TestMethod]
		public void LoadingRssChannelsWorksOK()
		{
			//Arrange
			var provider = new FakeRssResourceProvider(
				@"<rss version='2.0'>
					<channel>
						<title>Liftoff News</title>
						<link>http://liftoff.msfc.nasa.gov/</link>
						<description>Liftoff to Space Exploration.</description> 
						<item>
							 <title>Star City</title>
							 <link>http://liftoff.msfc.nasa.gov/news/2003/news-starcity.asp</link>
							 <description>How do Americans get ready to work with Russians aboard the International Space Station? They take a crash course in culture, language and protocol at Russia's Star City.</description>
							 <pubDate>Tue, 03 Jun 2003 09:39:21 GMT</pubDate>
							 <guid>http://liftoff.msfc.nasa.gov/2003/06/03.html#item573</guid>
						  </item>
						  <item>
							 <title>The Engine That Does More</title>
							 <link>http://liftoff.msfc.nasa.gov/news/2003/news-VASIMR.asp</link>
							 <description>Before man travels to Mars, NASA hopes to design new engines that will let us fly through the Solar System more quickly.  The proposed VASIMR engine would do that.</description>
							 <pubDate>Tue, 27 May 2003 08:37:32 GMT</pubDate>
							 <guid>http://liftoff.msfc.nasa.gov/2003/05/27.html#item571</guid>
						  </item>
						  <item>
							 <title>Astronauts' Dirty Laundry</title>
							 <link>http://liftoff.msfc.nasa.gov/news/2003/news-laundry.asp</link>
							 <description>Compared to earlier spacecraft, the International Space Station has many luxuries, but laundry facilities are not one of them.  Instead, astronauts have other options.</description>
							 <pubDate>Tue, 20 May 2003 08:56:02 GMT</pubDate>
							 <guid>http://liftoff.msfc.nasa.gov/2003/05/20.html#item570</guid>
						  </item>
					   </channel>
					</rss>");

			//Act
			var reader = RssReader.LoadRssFile(provider, "");

			//Assert
			Assert.IsNotNull(reader.Channel);
			Assert.AreEqual("Liftoff News", reader.Channel.Title);
			Assert.AreEqual("Liftoff to Space Exploration.", reader.Channel.Description);
		}

		[TestMethod]
		public void LoadingRssItemsWorksOK()
		{
			//Arrange
			var provider = new FakeRssResourceProvider(
				@"<rss version='2.0'>
					<channel>
						<title>Liftoff News</title>
						<link>http://liftoff.msfc.nasa.gov/</link>
						<description>Liftoff to Space Exploration.</description> 
						<item>
							 <title>Star City</title>
							 <link>http://liftoff.msfc.nasa.gov/news/2003/news-starcity.asp</link>
							 <description>How do Americans get ready to work with Russians aboard the International Space Station? They take a crash course in culture, language and protocol at Russia's Star City.</description>
							 <pubDate>Tue, 03 Jun 2003 09:39:21 GMT</pubDate>
							 <guid>http://liftoff.msfc.nasa.gov/2003/06/03.html#item573</guid>
						  </item>
						  <item>
							 <title>The Engine That Does More</title>
							 <link>http://liftoff.msfc.nasa.gov/news/2003/news-VASIMR.asp</link>
							 <description>Before man travels to Mars, NASA hopes to design new engines that will let us fly through the Solar System more quickly.  The proposed VASIMR engine would do that.</description>
							 <pubDate>Tue, 27 May 2003 08:37:32 GMT</pubDate>
							 <guid>http://liftoff.msfc.nasa.gov/2003/05/27.html#item571</guid>
						  </item>
						  <item>
							 <title>Astronauts' Dirty Laundry</title>
							 <link>http://liftoff.msfc.nasa.gov/news/2003/news-laundry.asp</link>
							 <description>Compared to earlier spacecraft, the International Space Station has many luxuries, but laundry facilities are not one of them.  Instead, astronauts have other options.</description>
							 <pubDate>Tue, 20 May 2003 08:56:02 GMT</pubDate>
							 <guid>http://liftoff.msfc.nasa.gov/2003/05/20.html#item570</guid>
						  </item>
					   </channel>
					</rss>");

			//Act
			var reader = RssReader.LoadRssFile(provider, "");

			//Assert
			Assert.AreEqual(3, reader.Items.Count);
			Assert.AreEqual("Star City", reader.Items[0].Title);
			Assert.AreEqual("The Engine That Does More", reader.Items[1].Title);
			Assert.AreEqual("Astronauts' Dirty Laundry", reader.Items[2].Title);
		}

		#endregion
	}
}
