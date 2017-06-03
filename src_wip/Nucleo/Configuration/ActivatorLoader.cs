using System;
using Nucleo.Global;


namespace Nucleo.Configuration
{
	/// <summary>
	/// A loader to use for activating objects of specific types.
	/// </summary>
	public static class ActivatorLoader
	{
		public static T LoadType<T>(NameTypeElement element)
		{
			Type objectType = Type.GetType(element.Type);
			return (T)Activator.CreateInstance(objectType);
		}
	}
}
