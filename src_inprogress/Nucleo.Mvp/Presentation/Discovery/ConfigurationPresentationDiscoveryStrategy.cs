using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Core.Configuration;
using Nucleo.Views;
using Nucleo.Configuration;


namespace Nucleo.Presentation.Discovery
{
	public class ConfigurationPresentationDiscoveryStrategy : IPresentationDiscoveryStrategy
	{

		#region " Methods "

		private Type FindType(IView view, string typeName)
		{
			if (string.IsNullOrEmpty(typeName))
				return null;

			string viewTypeName = GetName(view.GetType().Name);

			Type type = Type.GetType(string.Format(typeName, viewTypeName));
			if (type != null)
				return type;

			viewTypeName = GetName(view.GetType().BaseType.Name);
			return Type.GetType(string.Format(typeName, viewTypeName));
		}

		public Type FindPresenterType(DiscoveryOptions options)
		{
			FrameworkSettingsSection section = FrameworkSettingsSection.Instance;
			if (section == null)
				return FindType(options.View, options.View.GetType().FullName);

			foreach (PresenterTypeElement discoveryElement in section.DiscoveryTypeNames)
			{
				Type type = this.FindType(options.View, discoveryElement.TypeName);
				if (type != null)
					return type;
			}

			return null;
		}

		private string GetName(string name)
		{
			if (!name.EndsWith("View"))
				return name;
			else
				return name.Substring(0, name.Length - 5);
		}

		#endregion
	}
}
