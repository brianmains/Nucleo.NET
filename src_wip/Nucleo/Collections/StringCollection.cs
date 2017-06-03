using System;
using System.Collections.Generic;


namespace Nucleo.Collections
{
	/// <summary>
	/// A collection of strings, which also reads in CSV data and converts to/from a CSV string.  It also can use a custom separator as well.
	/// </summary>
	public class StringCollection : System.Collections.Specialized.StringCollection
	{
		#region " Constructors "

		public StringCollection() { }

		public StringCollection(string item)
		{
			this.Add(item);
		}

		public StringCollection(IEnumerable<string> list)
		{
			this.AddRange(list);
		}

		public StringCollection(string[] list)
		{
			this.AddRange(list);
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a range of strings to the list.
		/// </summary>
		/// <param name="list"></param>
		public void AddRange(IEnumerable<string> list)
		{
			foreach (string item in list)
				this.Add(item);
		}

		/// <summary>
		/// Takes a comma separated list of items, and adds them to the collection.
		/// </summary>
		/// <param name="text">The text that contains comma-separated text.</param>
		public void FromCommaSeparatedList(string text)
		{
			this.FromSeparatedList(text, ",");
		}

		/// <summary>
		/// Takes a comma separated list of items, and adds them to the collection.
		/// </summary>
		/// <param name="text">The text that contains comma-separated text.</param>
		/// <param name="separator">The separator to use to parse out the content.</param>
		public void FromSeparatedList(string text, string separator)
		{
			string[] items = text.Split(separator.ToCharArray());
			foreach (string item in items)
			{
				if (!string.IsNullOrEmpty(item))
					this.Add(item);
			}
		}

		public string[] ToArray()
		{
			List<string> list = new List<string>();

			foreach (string item in this)
				list.Add(item);

			return list.ToArray();
		}

		/// <summary>
		/// Returns the list in comma-separated form.
		/// </summary>
		/// <returns>A single string of items separated by a comma.</returns>
		public string ToCommaSeparatedList()
		{
			return ToSeparatedList(",");
		}

		/// <summary>
		/// Returns the list in a form using a custom separator to separate the values.
		/// </summary>
		/// <param name="separator">The separator to use.</param>
		/// <returns>A single string of items separated by a custom separator.</returns>
		public string ToSeparatedList(string separator)
		{
			string list = string.Empty;

			for (int i = 0; i < this.Count; i++)
			{
				if (i != 0) list += separator;
				list += this[i];
			}

			return list;
		}

		#endregion



		#region " Static Methods "

		public static StringCollection FromList(string text, string separator)
		{
			StringCollection collection = new StringCollection();
			collection.FromSeparatedList(text, separator);
			return collection;
		}

		#endregion
	}
}
