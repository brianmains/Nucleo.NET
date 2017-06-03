using System;


namespace Nucleo.Rss
{
	public interface IRssResourceProvider
	{
		#region " Methods "

		string GetRssContent(string location);

		#endregion
	}
}
