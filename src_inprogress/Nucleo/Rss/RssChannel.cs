using System;
using System.Xml;


namespace Nucleo.Rss
{
	public class RssChannel
	{
		private string _description = string.Empty;
		private string _link = string.Empty;
		private string _title = string.Empty;


		#region " Properties "

		/// <summary>
		/// Gets the description of the RSS channel.
		/// </summary>
		public string Description
		{
			get { return _description; }
		}

		/// <summary>
		/// Gets the link of the RSS channel.
		/// </summary>
		public string Link
		{
			get { return _link; }
		}

		/// <summary>
		/// Gets the title of the RSS channel.
		/// </summary>
		public string Title
		{
			get { return _title; }
		}

		#endregion



		#region " Constructors "

		public RssChannel(string title, string link, string description)
		{
			_title = title;
			_link = link;
			_description = description;
		}

		#endregion
	}
}