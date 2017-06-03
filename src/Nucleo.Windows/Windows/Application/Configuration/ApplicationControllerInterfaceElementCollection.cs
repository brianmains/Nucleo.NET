using System;
using Nucleo.Configuration;


namespace Nucleo.Windows.Application.Configuration
{
	public class ApplicationControllerInterfaceElementCollection : ConfigurationCollectionBase<ApplicationControllerInterfaceElement>
	{
		public ApplicationControllerInterfaceElement this[WindowsInterfaceType uiInterface]
		{
			get
			{
				foreach (ApplicationControllerInterfaceElement element in this)
				{
					if (element.Interface == uiInterface)
						return element;
				}

				return null;
			}
		}
	}
}
