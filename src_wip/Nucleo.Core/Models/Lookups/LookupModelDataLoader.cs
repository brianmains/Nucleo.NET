using System;

using Nucleo.Lookups;
using Nucleo.Lookups.Identification;
using Nucleo.Lookups.Providers;
using Nucleo.Lookups.Repositories;
using Nucleo.Models;


namespace Nucleo.Models.Lookups
{
	/// <summary>
	/// Represents the model data loader to pull information from lookups.
	/// </summary>
	public class LookupModelDataLoader : IModelDataLoader
	{
		private LookupManager _manager = null;



		#region " Constructors "

		public LookupModelDataLoader(LookupManager manager)
		{
			_manager = manager;
		}

		#endregion



		#region " Methods "

		private LookupManager GetManager()
		{
			return _manager;
		}

		/// <summary>
		/// Gets the model data for the lookup member.
		/// </summary>
		/// <param name="metadata">The member containing the lookup.</param>
		/// <returns>The lookup instance.</returns>
		public object GetModelData(ModelMemberMetadata metadata)
		{
			if (metadata == null)
				throw new ArgumentNullException("metadata");
			if (!(metadata.InjectionDefinition is ILookupInjection))
				throw new ArgumentException("The injection definition must be an ILookupInjection type.");

			LookupManager manager = this.GetManager();
			var id = new NameLookupIdentifier { Name = ((ILookupInjection)metadata.InjectionDefinition).LookupName };

			ILookupRepository repository = manager.GetLookupRepository(id);

			return repository.GetAllValues(new LookupCriteria(id, null));
		}

		/// <summary>
		/// Returns whether the injection type is marked with the <see cref="ILookupInjection"/> interface.
		/// </summary>
		/// <param name="injection">The injection information.</param>
		/// <returns>The attribute.</returns>
		public bool SupportsInjection(IModelInjection injection)
		{
			return (injection is ILookupInjection);
		}

		#endregion
	}
}
