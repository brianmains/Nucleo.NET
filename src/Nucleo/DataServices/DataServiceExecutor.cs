using System;
using System.Collections.Generic;

using Nucleo.DataServices.Modules;
using Nucleo.DataServices.Modules.Configuration;
using Nucleo.DataServices.Results;


namespace Nucleo.DataServices
{
	/// <summary>
	/// Represents the core data service executor.
	/// </summary>
	public class DataServiceExecutor
	{
		#region " Constructors "

		protected DataServiceExecutor() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Creates the data service executor.
		/// </summary>
		/// <returns>The executor.</returns>
		public static DataServiceExecutor Create()
		{
			return new DataServiceExecutor();
		}

		/// <summary>
		/// Gets the target loader file from the configuration file.
		/// </summary>
		/// <returns>The loader for the service executor.</returns>
		protected virtual BaseModuleLoader GetLoaderFromConfiguration()
		{
			ModuleSettingsSection section = ModuleSettingsSection.Instance;
			return (BaseModuleLoader)Activator.CreateInstance(Type.GetType(section.ModuleLoaderType));
		}

		protected DataServiceModuleCollection GetModules()
		{
			ModuleSettingsSection section = ModuleSettingsSection.Instance;
			BaseModuleScheduler scheduler = this.GetSchedulerFromConfiguration();
			BaseModuleLoader loader = this.GetLoaderFromConfiguration();

			return this.GetModules(scheduler, loader);
		}

		protected virtual DataServiceModuleCollection GetModules(BaseModuleScheduler scheduler, BaseModuleLoader loader)
		{
			IEnumerable<ModuleIdentifier> identifiers = scheduler.GetModulesForExecution();
			return loader.GetModules(identifiers);
		}

		/// <summary>
		/// Gets the scheduler used to execute.
		/// </summary>
		/// <returns></returns>
		protected virtual BaseModuleScheduler GetSchedulerFromConfiguration()
		{
			ModuleSettingsSection section = ModuleSettingsSection.Instance;
			return (BaseModuleScheduler)Activator.CreateInstance(Type.GetType(section.ModuleSchedulerType));
		}

		/// <summary>
		/// Runs the data service, using the loaded modules.
		/// </summary>
		/// <returns></returns>
		public DataServiceExecutorResults Run()
		{
			IEnumerable<IDataServiceModule> modules = this.GetModules();
			List<IDataServiceResult> results = new List<IDataServiceResult>();

			foreach (IDataServiceModule module in modules)
			{
				try
				{
					IDataServiceResult result = module.Execute();
					results.Add(result);
				}
				catch (Exception ex)
				{
					results.Add(new ExceptionDataServiceResult(module, ex));
				}
			}

			return new DataServiceExecutorResults(results);
		}

		#endregion
	}
}
