using System;
using System.Configuration.Provider;


namespace Nucleo.Providers
{
	/// <summary>
	/// Represents the collection of provider.
	/// </summary>
	/// <typeparam name="T">The provider type.</typeparam>
	public class ProviderCollection<T> : ProviderCollection where T:ProviderBase
	{
		#region " Properties "

		/// <summary>
		/// Gets a provider by the name.
		/// </summary>
		/// <param name="name">The name of the provider.</param>
		/// <returns>The entity or null if not found.</returns>
		new public T this[string name]
		{
			get { return (T)base[name]; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds the provider to the collection.
		/// </summary>
		/// <param name="provider">The provider to add.</param>
		public override void Add(System.Configuration.Provider.ProviderBase provider)
		{
			if (provider == null)
				throw new ArgumentNullException("provider", "Provider has not been provided");
			if (!(provider is T))
				throw new ArgumentException("The provider type is invalid", "provider");

			base.Add(provider);
		}

		/// <summary>
		/// Copies the array of providers to another collection.
		/// </summary>
		/// <param name="array">The array to copy.</param>
		/// <param name="index">The array index.</param>
		public void CopyTo(T[] array, int index)
        {
            base.CopyTo(array, index);
        }

		#endregion
	}
}
