using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Encryption
{
	/// <summary>
	/// Represents the provider to hash data.
	/// </summary>
	public interface IHashProvider
	{
		/// <summary>
		/// Hashes the data into the underlying object.
		/// </summary>
		/// <param name="data">The data to hash.</param>
		/// <returns>The final data.</returns>
		object Hash(object data);
	}
}
