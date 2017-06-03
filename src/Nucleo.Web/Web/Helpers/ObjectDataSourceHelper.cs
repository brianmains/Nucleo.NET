using System;
using System.Web.UI.WebControls;


namespace Nucleo.Web.Helpers
{
	public static class ObjectDataSourceHelper
	{
		public static void SwitchValuesToNewParameter(ObjectDataSourceMethodEventArgs e, string oldParameterName, string newParameterName)
		{
			e.InputParameters[newParameterName] = e.InputParameters[oldParameterName];
			e.InputParameters.Remove(oldParameterName);
		}

		public static void SwitchValuesToNewParameters(ObjectDataSourceMethodEventArgs e, string[] oldParameterNames, string[] newParameterNames)
		{
			if (oldParameterNames.Length != newParameterNames.Length)
				throw new ArgumentException();

			for (int i = 0; i < oldParameterNames.Length; i++)
				SwitchValuesToNewParameter(e, oldParameterNames[i], newParameterNames[i]);
		}
	}
}
