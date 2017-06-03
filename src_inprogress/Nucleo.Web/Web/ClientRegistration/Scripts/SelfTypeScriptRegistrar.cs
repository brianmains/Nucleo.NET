using System;
using System.Web.UI;


namespace Nucleo.Web.ClientRegistration.Scripts
{
	public class SelfTypeScriptRegistrar : IScriptRegistrar
	{

		#region " Methods "

		public ScriptReferencingRequestDetailsCollection GetScriptDetails(object target)
		{
			return new ScriptReferencingRequestDetailsCollection(
				new ScriptReferencingRequestDetails(target.GetType(), ScriptMode.Auto));
		}

		#endregion
	}
}
