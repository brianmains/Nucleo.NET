using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Reflection;

using Nucleo.Reflection;


namespace Nucleo.Web.ClientRegistration.Scripts
{
	public class ClientAttributeScriptRegistrar : IScriptRegistrar
	{
		#region " Methods "

		public ScriptReferencingRequestDetailsCollection GetScriptDetails(object target)
		{
			var attributes = Reflect.Public(target).Type().IterateAttributesThoughTypeInheritance<ClientScriptAttribute>();
			var metadata = new ScriptReferencingRequestDetailsCollection();

			foreach (ClientScriptAttribute attribute in attributes)
			{
				ScriptMode scriptMode = ScriptMode.Auto;
#if DEBUG
				scriptMode = ScriptMode.Debug;
#else
				scriptMode = ScriptMode.Release;
#endif

				if (attribute.Mode == null || (attribute != null && attribute.Mode.Value == scriptMode))
					metadata.Add(new ScriptReferencingRequestDetails(attribute.Assembly, attribute.Type, scriptMode));
			}

			return metadata;
		}

		#endregion
	}
}
