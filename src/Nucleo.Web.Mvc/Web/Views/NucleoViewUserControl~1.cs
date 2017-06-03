﻿using System;
using System.Web;
using System.Web.Mvc;


namespace Nucleo.Web.Views
{
	public class NucleoViewUserControl<T> : ViewUserControl<T>
		where T: class
	{
		#region " Methods "

		/// <summary>
		/// Decrypts the string value.
		/// </summary>
		/// <param name="value">The value to decrypt.</param>
		/// <returns>The final value.</returns>
		public string Dec(string value)
		{
			return this.ViewContext.HttpContext.Server.HtmlDecode(value);
		}

		public string Enc(string value)
		{
			return this.ViewContext.HttpContext.Server.HtmlEncode(value);
		}

		#endregion
	}
}
