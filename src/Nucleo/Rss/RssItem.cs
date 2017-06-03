using System;
using System.Xml;
using Nucleo.Collections;

namespace Nucleo.Rss
{
	public class RssItem
	{
		private string _author = string.Empty;
		private string _category = string.Empty;
		private string _comments = string.Empty;
		private string _description = string.Empty;
		private RssEnclosure _enclosure = null;
		private string _link = string.Empty;
		private DateTime _publishedDate = DateTime.MinValue;
		private string _source = string.Empty;
		private string _title = string.Empty;




		#region " Properties "

		/// <summary>
		/// Gets the author of the RSS item.
		/// </summary>
		public string Author
		{
			get { return _author; }
		}

		/// <summary>
		/// Gets the category of the RSS item.
		/// </summary>
		public string Category
		{
			get { return _category; }
		}

		/// <summary>
		/// Gets the comments of the RSS item.
		/// </summary>
		public string Comments
		{
			get { return _comments; }
		}

		/// <summary>
		/// Gets the description of the RSS item.
		/// </summary>
		public string Description
		{
			get { return _description; }
		}

		/// <summary>
		/// Gets or sets the enclosure information for the RSS file.
		/// </summary>
		public RssEnclosure Enclosure
		{
			get { return _enclosure; }
			set { _enclosure = value; }
		}

		/// <summary>
		/// Gets the link of the RSS item.
		/// </summary>
		public string Link
		{
			get { return _link; }
		}

		/// <summary>
		/// Gets the published date of the RSS item.
		/// </summary>
		public DateTime PublishedDate
		{
			get { return _publishedDate; }
		}

		/// <summary>
		/// Gets the source of the RSS item.
		/// </summary>
		public string Source
		{
			get { return _source; }
		}

		/// <summary>
		/// Gets the title of the RSS item.
		/// </summary>
		public string Title
		{
			get { return _title; }
		}

		#endregion



		#region " Constructors "

		public RssItem(string author, string title, string link, string description, DateTime publishDate)
		{
			_author = author;
			_title = title;
			_link = link;
			_publishedDate = publishDate;
			_description = description;
		}

		public RssItem(string author, string title, string link, string description, DateTime publishDate, string category, string source, string comments)
			: this(author,title, link, description, publishDate)
		{
			_category = category;
			_source = source;
			_comments = comments;
		}

		#endregion



		#region " Methods "

		

		#endregion
	}


	public class RssItemCollection : CollectionBase<RssItem> { }
}