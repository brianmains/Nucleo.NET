using System;
using System.Web;
using System.Collections.Generic;


namespace Nucleo
{
	/// <summary>
	/// Represents a URL.  The path and attributes for the URL.
	/// </summary>
	public class Url
	{
		private IDictionary<string, object> _attributes = null;
		private string _path = null;


		#region " Properties "

		/// <summary>
		/// The attributes for the URL.
		/// </summary>
		public IDictionary<string, object> Attributes
		{
			get 
			{
				if (_attributes == null)
					_attributes = new Dictionary<string, object>();

				return _attributes; 
			}
			set { _attributes = value; }
		}

		/// <summary>
		/// The base page path for the URL (ie default.aspx or ~/pages/default.aspx).
		/// </summary>
		public string Path
		{
			get { return _path; }
			set { _path = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the URL with the path.
		/// </summary>
		/// <param name="path">The core path.</param>
		public Url(string path)
		{
			_path = path;
		}

		/// <summary>
		/// Creates the URL with the path and attributes (appended to querystring).
		/// </summary>
		/// <param name="path">The core path.</param>
		/// <param name="attributes">The attributes to append to the path.</param>
		public Url(string path, IDictionary<string, object> attributes)
		{
			_path = path;
			_attributes = attributes;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Creates a URL with a path and additional querystring values.
		/// </summary>
		/// <returns>The url.</returns>
		public override string ToString()
		{
			if (this.Attributes == null || this.Attributes.Count == 0)
				return this.Path;
			else
			{
				string path = this.Path;
				bool first = true;

				foreach (KeyValuePair<string, object> attribute in this.Attributes)
				{
					if (!first)
						path += "&";
					else
					{
						path += "?";
						first = false;
					}

					path += string.Format("{0}={1}", attribute.Key, 
							(attribute.Value ?? "").ToString());
				}

				return path;
			}
		}

		#endregion
	}
}
