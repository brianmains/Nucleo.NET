using System;
using System.Reflection;

using Nucleo.DynamicExecution.Configuration;
using Nucleo.EventArguments;


namespace Nucleo.DynamicExecution
{
	public class ConfigurationDynamicExecutionPathMethodProvider : DynamicExecutionPathMethodProvider
	{
		public override DynamicExecutionPathMethodInfoCollection GetMethods()
		{
			DynamicExecutionPathMethodInfoCollection collection = new DynamicExecutionPathMethodInfoCollection();

			DynamicExecutionPathSection section = DynamicExecutionPathSection.Instance;
			if (section == null)
				throw new NullReferenceException("The dynamic execution path configuration section hasn't been setup correctly");

			foreach (DynamicExecutionPathMethodElement element in section.Methods)
				collection.Add(new DynamicExecutionPathMethodInfo(element.MethodFriendlyName, element.ObjectTypeName, element.MethodName));

			return collection;
		}
	}
}
