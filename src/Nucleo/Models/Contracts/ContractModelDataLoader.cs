using System;
using Nucleo.Context;
using Nucleo.Context.Services;


namespace Nucleo.Models.Contracts
{
	/// <summary>
	/// Represents the data loader for the model to inject contracts.
	/// </summary>
	public class ContractModelDataLoader : IModelDataLoader
	{
		private IDependencyInjectionService _service = null;



		#region " Constructors "

		public ContractModelDataLoader() 
		{ 
			ApplicationContext context = ApplicationContext.GetCurrent();
			if (context != null)
				_service = context.GetService<IDependencyInjectionService>();
		}

		public ContractModelDataLoader(IDependencyInjectionService service)
		{
			_service = service;
		}

		#endregion



		#region " Methods "

		public object GetModelData(ModelMemberMetadata metadata)
		{
			if (_service == null)
				return null;

			return _service.Resolve(metadata.ValueType);
		}

		public bool SupportsInjection(IModelInjection injection)
		{
			return (injection is IContractInjection);
		}

		#endregion
	}
}
