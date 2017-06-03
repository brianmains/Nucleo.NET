using System;
using System.IO;


namespace Nucleo.Rss
{
	public class LocalRssResourceProvider : IRssResourceProvider
	{
		#region " Methods "

		public string GetRssContent(string location)
		{
			if (!File.Exists(location))
				throw new InvalidOperationException("Only files are allowed for this provider");

			string rssData;

			using (StreamReader rssFile = new StreamReader(location))
				rssData = rssFile.ReadToEnd();

			return rssData;
		}

		#endregion
	}
}
