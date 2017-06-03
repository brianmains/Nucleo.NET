using System;
using System.Xml;
using System.Net;
using System.IO;
using Nucleo.Collections;


namespace Nucleo.Rss
{
	/// <summary>
	/// An RSS Reader component that can download a file from the web (with internet access), or from a local path.  Once the file is read, the RSS file is accessible through the Channel and Items property.
	/// </summary>
	/// <remarks>The reader can parse both online files and offline files, as long as it can read it.</remarks>
	/// <example>
	///	//To use the RSS reader, use code like the following:
	///	RssReader reader = RssReader.LoadRssFile("http://somesite.com/rss.aspx");
	///	string title = reader.Channel.Title;
	///	string output = string.Empty;
	/// 
	///	foreach (RssItem item in reader.Items)
	///		output += string.concat(item.Title, " (", item.Author, ", ", item.PublishedDate, ")");
	/// </example>
	public class RssReader
	{
		private RssChannel _channel = null;
		private RssItemCollection _items = null;



		#region " Properties "

		/// <summary>
		/// Gets the channel that was downloaded for the RSS feed.
		/// </summary>
		public RssChannel Channel
		{
			get { return _channel; }
		}

		/// <summary>
		/// Gets the items that were downloaded for the RSS feed.
		/// </summary>
		public RssItemCollection Items
		{
			get
			{
				if (_items == null)
					_items = new RssItemCollection();
				return _items;
			}
		}

		#endregion

		

		#region " Constructors "

		private RssReader() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Loads an RSS file into the system.
		/// </summary>
		/// <param name="path">The URI, or the local file path, to load RSS data with.</param>
		private void LoadFile(IRssResourceProvider provider, string path)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(provider.GetRssContent(path));

			_channel = LoadChannelFromXml((XmlElement)document.SelectSingleNode("//channel"));

			_items = new RssItemCollection();
			XmlNodeList itemsList = document.SelectNodes("//item");

			foreach (XmlNode itemNode in itemsList)
			{
				RssItem item = LoadItemFromXml((XmlElement)itemNode);
				_items.Add(item);
			}
		}

		private RssChannel LoadChannelFromXml(XmlElement channelElement)
		{
			if (channelElement == null)
				throw new ArgumentNullException("channelElement");

			return new RssChannel(
				channelElement["title"].InnerText,
				channelElement["link"].InnerText,
				channelElement["description"].InnerText);
		}

		private RssItem LoadItemFromXml(XmlElement itemElement)
		{
			if (itemElement == null)
				throw new ArgumentNullException("itemElement");

			RssItem item = new RssItem(
				itemElement["author"] != null ? itemElement["author"].InnerText : string.Empty,
				itemElement["title"] != null ? itemElement["title"].InnerText : string.Empty,
				itemElement["link"] != null ? itemElement["link"].InnerText : string.Empty,
				itemElement["description"] != null ? itemElement["description"].InnerText : string.Empty,
				itemElement["pubDate"] != null ? DateTime.Parse(itemElement["pubDate"].InnerText) : DateTime.MinValue,
				itemElement["category"] != null ? itemElement["category"].InnerText : string.Empty,
				itemElement["source"] != null ? itemElement["source"].InnerText : string.Empty,
				itemElement["comments"] != null ? itemElement["comments"].InnerText : string.Empty);

			if (itemElement["enclosure"] != null)
			{
				XmlElement enclosureElement = itemElement["enclosure"];
				
				item.Enclosure = new RssEnclosure(
					new Uri(enclosureElement.GetAttribute("url")),
					enclosureElement.GetAttribute("type") ?? "",
					enclosureElement.GetAttribute("length") != null ? double.Parse(enclosureElement.GetAttribute("length")) : 0
				);
			}

			return item;
		}

		public static RssReader LoadRssFile(IRssResourceProvider provider, string path)
		{
			RssReader reader = new RssReader();
			reader.LoadFile(provider, path);
			return reader;
		}

		/// <summary>
		/// Loads an RSS file into the system.
		/// </summary>
		/// <param name="path">The local path of the RSS file.</param>
		public static RssReader LoadRssFile(string path)
		{
			return LoadRssFile(new LocalRssResourceProvider(), path);
		}

		/// <summary>
		/// Loads an RSS file into the system.
		/// </summary>
		/// <param name="path">The local path of the RSS file.</param>
		public static RssReader LoadRssFile(Uri url)
		{
			return LoadRssFile(new OnlineRssResourceProvider(), url.ToString());
		}

		#endregion
	}
}