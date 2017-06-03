using System;
using System.Collections.Generic;
using System.Web.UI;

using Nucleo.Context;
using Nucleo.Web;
using Nucleo.Web.Scripts.Configuration;


namespace Nucleo.Web.Scripts
{
	/// <summary>
	/// Represents the core component to manage reference scripts within the application.  The scripts can be stored externally (configuration file) and retrieved on-demand.
	/// </summary>
	/// <example>
	/// // External script to the Nucleo API, hence the external part of the name
	/// var script = ReferenceScriptManager.GetExternalScript("jquery");
	/// if (!string.IsNullOrEmpty(script.Path))
	///		//Local script file
	///	else if (!string.IsNullOrEmpty(script.Type))
	///		//Embedded resource
	/// </example>
	public static class ReferenceScriptManager
	{
		#region " Methods "

		/// <summary>
		/// Creates a script reference by converting the details into this reference.
		/// </summary>
		/// <param name="details">The details to convert.</param>
		/// <returns>The script reference.</returns>
		/// <exception cref="ArgumentNullException">Thrown when the details are null.</exception>
		/// <example>
		/// var details = new ScriptReferencingRequestDetails("localpath.debug.js", ScriptMode.Debug);
		/// var finalRef = ReferenceScriptManager.CreateReference(details);
		/// Assert.AreEqual("localpath.debug.js", details.Path);
		/// </example>
		public static NucleoScriptReference CreateReference(ScriptReferencingRequestDetails details)
		{
			if (details == null)
				throw new ArgumentNullException("details");

			NucleoScriptReference reference = new NucleoScriptReference();
			if (!string.IsNullOrEmpty(details.Path))
			{
				reference.Path = details.Path;
				reference.OriginalPath = details.Path;
			}
			else
			{
				reference.Assembly = details.Assembly;
				reference.Name = details.Type;
			}

			reference.ScriptMode = details.Mode;

			return reference;
		}

		private static ExternalScriptSettingsSection GetConfig()
		{
			ExternalScriptSettingsSection section = ExternalScriptSettingsSection.Instance;
			if (section != null)
				return section;
			else
				return new ExternalScriptSettingsSection();
		}

		/// <summary>
		/// Gets the script reference by matching its key, which is loaded from its companion configuration file.
		/// </summary>
		/// <param name="key">The key of the external script.</param>
		/// <returns>The script reference tied to the key.</returns>
		/// <example>
		/// var script = ReferenceScriptManager.GetExternalScript("jquery");
		/// if (script != null)
		///		return script.Path;
		///	
		///	return null;
		/// </example>
		public static NucleoScriptReference GetExternalScript(string key)
		{
			if (string.IsNullOrEmpty(key))
				throw new ArgumentNullException("key");

			ExternalScriptSettingsSection config = GetConfig();
			ExternalScriptElement element = config.ExternalScripts[key];

			if (element == null)
				return null;

			NucleoScriptReference reference = new NucleoScriptReference();
			reference.UniqueIdentifier = element.Name;

#if DEBUG

			if (!string.IsNullOrEmpty(element.DebugPath))
			{
				reference.Path = element.DebugPath;
				reference.OriginalPath = element.DebugPath;
			}
			else if (!string.IsNullOrEmpty(element.DebugType))
			{
				reference.Name = element.DebugType;
				reference.Assembly = element.Assembly;
			}

#else

				if (!string.IsNullOrEmpty(element.ReleasePath))
				{
					reference.Path = element.ReleasePath;
					reference.OriginalPath = element.ReleasePath;
				}
				else if (!string.IsNullOrEmpty(element.ReleaseType))
				{
					reference.Name = element.ReleaseType;
					reference.Assembly = element.Assembly;
				}

#endif

			return reference;
		}

		public static ScriptReferencingRequestDetails GetExternalScriptDetails(string key)
		{
			NucleoScriptReference reference = GetExternalScript(key);
			if (reference == null)
				return null;

			if (!string.IsNullOrEmpty(reference.Path))
				return new ScriptReferencingRequestDetails(reference.Path, reference.ScriptMode);
			else
				return new ScriptReferencingRequestDetails(reference.Assembly, reference.Name, reference.ScriptMode);
		}

		public static NucleoScriptReference GetFrameworkScript(string clientType, ScriptMode mode, ScriptFramework framework)
		{
			if (string.IsNullOrEmpty(clientType))
				throw new ArgumentNullException("clientType");

			if (framework == ScriptFramework.WebForms)
				return CreateReference(new ScriptReferencingRequestDetails(
					typeof(ReferenceScriptManager).Assembly.FullName, clientType, mode));
			else if (framework == ScriptFramework.Mvc)
				return CreateReference(new ScriptReferencingRequestDetails(
					"Nucleo.Web.Mvc", clientType, mode));
			else if (framework == ScriptFramework.Mvp)
				return CreateReference(new ScriptReferencingRequestDetails(
					"Nucleo.Web.Mvp", clientType, mode));
			else
				return null;
		}

		public static NucleoScriptReference GetScript(Type controlType, ScriptMode mode)
		{
			if (controlType == null)
				throw new ArgumentNullException("controlType");

			return CreateReference(new ScriptReferencingRequestDetails(controlType, mode));
		}

		#endregion
	}
}
