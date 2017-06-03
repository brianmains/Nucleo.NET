using System;
using System.Web.UI;
using System.Reflection;
using System.Globalization;
using System.Web.Handlers;

using Nucleo.Web.Scripts;


namespace Nucleo.Web
{
	public static class ScriptReferencing
	{
		#region " Methods "

		public static string GetResourceUrl(Assembly assembly, string resourceName, CultureInfo culture, bool zip, bool notifyScriptLoaded)
		{
#if NET20 || NET35
			MethodInfo method = typeof(ScriptResourceHandler).GetMethod("GetScriptResourceUrl", BindingFlags.Static | BindingFlags.NonPublic, null, 
				new Type[] { typeof(Assembly), typeof(string), typeof(CultureInfo), typeof(bool), typeof(bool) }, null);
			if (method == null)
				return null;

			return (string)method.Invoke(null, new object[] { assembly, resourceName, culture, zip, notifyScriptLoaded });
#else
			MethodInfo method = typeof(ScriptResourceHandler).GetMethod("GetScriptResourceUrl", BindingFlags.Static | BindingFlags.NonPublic, null, 
				new Type[] { typeof(Assembly), typeof(string), typeof(CultureInfo), typeof(bool) }, null);
			if (method == null)
				return null;

			return (string)method.Invoke(null, new object[] { assembly, resourceName, culture, zip });
#endif
		}

		#endregion
	}
}
