using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Models.Cache
{
	/// <summary>
	/// Represents the information about the cache's availability.
	/// </summary>
	public class CacheInformation
	{
		public bool CanCache { get; set; }

		public string Key { get; set; }
	}
}
