using System;
using System.Web.UI;
using System.Collections.Generic;

using Nucleo.Web;
using Nucleo.Context;
using Nucleo.Logs;
using Nucleo.Reflection;

using Nucleo.Web.ClientRegistration.Scripts;


namespace Nucleo.Web.ClientRegistration
{
	public class ClientScriptRegistry
	{
		private ScriptReferencingRequestDetailsCollection _scripts = null;



		#region " Properties "

		/// <summary>
		/// Gets the scripts associated with the registry.
		/// </summary>
		public ScriptReferencingRequestDetailsCollection Scripts
		{
			get
			{
				if (_scripts == null)
					_scripts = new ScriptReferencingRequestDetailsCollection();
				return _scripts;
			}
		}

		#endregion



		#region " Constructors "

		protected ClientScriptRegistry() { }

		#endregion



		#region " Methods "

		public static ClientScriptRegistry CreateFor(object target)
		{
			if (target == null)
				throw new ArgumentNullException("target");

			ClientScriptRegistry registry = new ClientScriptRegistry();

			if (target is ISelfTypeScriptRegistryImplementation)
				registry.Scripts.AddRange(new SelfTypeScriptRegistrar().GetScriptDetails(target));
			else if (target is ILocalWebScriptMetadataScriptRegistryImplementation)
				registry.Scripts.AddRange(new LocalWebScriptMetadataScriptRegistrar().GetScriptDetails(target));
			else if (target is IWebScriptMetadataScriptRegistryImplementation)
				registry.Scripts.AddRange(new WebScriptMetadataScriptRegistrar().GetScriptDetails(target));
			else if (target is IClientAttributeScriptRegistryImplementation)
				registry.Scripts.AddRange(new ClientAttributeScriptRegistrar().GetScriptDetails(target));
			else
			{
				registry.Scripts.AddRange(new WebScriptMetadataScriptRegistrar().GetScriptDetails(target));
				registry.Scripts.AddRange(new ClientAttributeScriptRegistrar().GetScriptDetails(target));
			}

			return registry;
		}

		#endregion
	}
}
