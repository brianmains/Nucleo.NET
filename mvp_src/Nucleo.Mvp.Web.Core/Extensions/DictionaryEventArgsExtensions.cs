using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web;


namespace Nucleo.EventArguments
{
	/// <summary>
	/// Represents the extensions for event args.
	/// </summary>
	public static class DictionaryEventArgsExtensions
	{
		#region " Methods "

		/// <summary>
		/// Copies the form collection to the dictionary args.
		/// </summary>
		/// <param name="args">The destination.</param>
		/// <param name="form">The source form collection.</param>
		public static void CopyFromForm(this DictionaryEventArgs args, FormCollection form)
		{
			foreach (string key in form.Keys)
			{
				args.Add(key, form[key]);
			}
		}
		
		#endregion
	}
}
