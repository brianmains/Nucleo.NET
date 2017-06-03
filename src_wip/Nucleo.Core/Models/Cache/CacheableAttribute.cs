using System;


namespace Nucleo.Models.Cache
{
	/// <summary>
	/// Represents the attribute used to mark a property for caching in model injection.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class CacheableAttribute : Attribute 
	{
		/// <summary>
		/// Gets or sets the key used to vary the caching mechanism.
		/// </summary>
		public string Key { get; set; }
	}
}
