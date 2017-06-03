using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Rss
{
	public class FakeRssResourceProvider : IRssResourceProvider
	{
		private string _rssContent = null;



		#region " Constructors "

		public FakeRssResourceProvider(string rssContent)
		{
			_rssContent = rssContent;
		}

		#endregion



		#region " Methods "

		public string GetRssContent(string location)
		{
			return _rssContent;
		}

		#endregion
	}
}
