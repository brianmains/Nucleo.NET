﻿using System;
using System.Collections.Specialized;

using Nucleo;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents the header collection for a specific browser request.
	/// </summary>
	public interface IRequestHeaderService  : ICollectionService
	{
		/// <summary>
		/// Gets all of the headers from the browser in name/value form.
		/// </summary>
		/// <returns>The name/value pairings.</returns>
		NameValueCollection GetAll();
	}
}
