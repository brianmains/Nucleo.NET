using System;
using System.Web.UI;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Web.Scripts.Configuration
{
	public class ExternalScriptElementCollection : ConfigurationCollectionBase<ExternalScriptElement>
	{
		#region " Methods "

		public ExternalScriptElement GetScript(string key)
		{
			for (int i = 0, len = this.Count; i < len; i++)
			{
				if (string.Compare(key, this[i].Name, StringComparison.InvariantCultureIgnoreCase) == 0)
					return this[i];
			}

			return null;
		}

		#endregion
	}
}
