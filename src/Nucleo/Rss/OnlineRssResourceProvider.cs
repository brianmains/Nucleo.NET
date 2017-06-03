using System;
using System.IO;
using System.Net;

namespace Nucleo.Rss
{
	public class OnlineRssResourceProvider : IRssResourceProvider
	{
		#region " Methods "

		public string GetRssContent(string location)
		{
			if (!location.StartsWith("http://") && !location.StartsWith("https://"))
				throw new InvalidOperationException("This provider only works with online content");

			WebClient client = new WebClient();
			string rssData;

			using (StreamReader rssFile = new StreamReader(client.OpenRead(location)))
				rssData = rssFile.ReadToEnd();

			return rssData;
		}

		#endregion
	}
}
