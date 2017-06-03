using System;
using Nucleo.Collections;


namespace Nucleo.Models
{
	/// <summary>
	/// Represents the collection of model data loaders.
	/// </summary>
	public class ModelDataLoaderCollection : SimpleCollection<IModelDataLoader>
	{
		#region " Methods "

		/// <summary>
		/// Finds a data loader from the model's injection definition.
		/// </summary>
		/// <param name="injection">The injection definition marked with the <see cref="IModelInjection"/>.</param>
		/// <returns>The associated model data loader, or null if not found.</returns>
		public IModelDataLoader Find(IModelInjection injection)
		{
			foreach (IModelDataLoader loader in this)
			{
				if (loader.SupportsInjection(injection))
					return loader;
			}

			return null;
		}

		#endregion
	}
}
