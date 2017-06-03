using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Rss
{
	public class RssEnclosure
	{
		private double _length = 0;
		private string _type = null;
		private Uri _url = null;



		#region " Properties "

		public double Length
		{
			get { return _length; }
		}

		public string Type
		{
			get { return _type; }
		}

		public Uri Url
		{
			get { return _url; }
		}

		#endregion



		#region " Constructors "

		public RssEnclosure(Uri url, string type, double length)
		{
			_url = url;
			_type = type;
			_length = length;
		}

		#endregion
	}
}
