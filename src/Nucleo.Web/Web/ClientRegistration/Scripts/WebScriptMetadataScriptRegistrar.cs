using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.ClientRegistration.Scripts
{
	public class WebScriptMetadataScriptRegistrar : IScriptRegistrar
	{
		#region " Methods "

		public ScriptReferencingRequestDetailsCollection GetScriptDetails(object target)
		{
			var metadatas = ControlScriptMetadata.GetWebScriptMetadata(target);
			var references = new ScriptReferencingRequestDetailsCollection();

			if (metadatas.Length > 0)
			{
				for (int index = 0, len = metadatas.Length; index < len; index++)
					references.AddRange(metadatas[index].GetPrimaryScripts());
			}

			return references;
		}

		#endregion
	}
}
