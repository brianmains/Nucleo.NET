using System;
using System.Web.UI;
using System.IO;

using Nucleo.Web.Scripts;


namespace Nucleo.Web
{
	public static class ScriptObjectHelper
	{
		private const string DebugJS = ".debug.js";
		private const string ReleaseJS = ".js";



		#region " Methods "

		/// <summary>
		/// Gets the descriptor for the designated control.
		/// </summary>
		/// <param name="control">The script control to get the descriptor for.</param>
		/// <param name="controlID">The ID of the control.</param>
		/// <returns>The descriptor for the script control.</returns>
		public static NucleoScriptControlDescriptor GetDescriptor(IScriptControl control, string controlID)
		{
			return new NucleoScriptControlDescriptor(control.GetType().FullName, controlID);
		}

		/// <summary>
		/// Gets the descriptor for the designated control.  Use this overload for base classes.
		/// </summary>
		/// <param name="control">The script control to get the descriptor for.</param>
		/// <param name="type">The type of the control to register; this is useful for base classes.</param>
		/// <param name="controlID">The ID of the control.</param>
		/// <returns>The descriptor for the script control.</returns>
		public static NucleoScriptControlDescriptor GetDescriptor(IScriptControl control, Type type, string controlID)
		{
			return new NucleoScriptControlDescriptor(type.FullName, controlID);
		}

		/// <summary>
		/// Gets the descriptor for the designated control.
		/// </summary>
		/// <param name="control">The extender control to get the descriptor for.</param>
		/// <param name="controlID">The ID of the control.</param>
		/// <returns>The descriptor for the extender control.</returns>
		public static NucleoScriptBehaviorDescriptor GetDescriptor(IExtenderControl control, string controlID)
		{
			return new NucleoScriptBehaviorDescriptor(control.GetType().FullName, controlID);
		}

		/// <summary>
		/// Gets the descriptor for the designated control.  Use this overload for base classes.
		/// </summary>
		/// <param name="control">The extender control to get the descriptor for.</param>
		/// <param name="type">The type of the control to register; this is useful for base classes.</param>
		/// <param name="controlID">The ID of the control.</param>
		/// <returns>The descriptor for the extender control.</returns>
		public static NucleoScriptBehaviorDescriptor GetDescriptor(IExtenderControl control, Type type, string controlID)
		{
			return new NucleoScriptBehaviorDescriptor(type.FullName, controlID);
		}

		public static NucleoScriptControlDescriptor GetDescriptorForBaseType(IScriptControl control, string controlID, ScriptDescriptorCollection existingCollection)
		{
			ScriptDescriptor descriptor = existingCollection.GetByClientType(control.GetType().FullName, controlID);

			if (descriptor != null)
				return (NucleoScriptControlDescriptor)descriptor;
			else
				return GetDescriptor(control, controlID);
		}

		public static NucleoScriptBehaviorDescriptor GetDescriptorForBaseType(IExtenderControl control, string controlID, ScriptDescriptorCollection existingCollection)
		{
			ScriptDescriptor descriptor = existingCollection.GetByClientType(control.GetType().FullName, controlID);

			if (descriptor != null)
				return (NucleoScriptBehaviorDescriptor)descriptor;
			else
				return GetDescriptor(control, controlID);
		}

		public static NucleoScriptReference GetCoreScriptReference(Control control, ScriptMode mode, CoreScriptIncludes scriptInclude)
		{
			var partialName = "Nucleo." + scriptInclude.ToString();
			return GetScriptReferenceObject(control, partialName, mode, true);
		}

		public static string GetScriptReference(Control control, string scriptPartialName, ScriptMode mode)
		{
			return GetScriptReference(control, scriptPartialName, mode, false);
		}

		public static string GetScriptReference(Control control, string scriptPartialName, ScriptMode mode, bool isEmbeddedResource)
		{
			return GetScriptReferenceInternal(control, control.GetType(), scriptPartialName, mode, isEmbeddedResource);
		}

		/// <summary>
		/// Registers the script using the full name of the control, and using the appropriate file extension based upon the script type.  This approach does not use ClientScriptManager to reference an embedded url.
		/// </summary>
		/// <param name="control">The control to reference via the client-side script.</param>
		/// <param name="mode">Whether the script is for debug/release mode.</param>
		/// <returns>The URL to the script.</returns>
		public static string GetScriptReference(Control control, ScriptMode mode)
		{
			return GetScriptReference(control, control.GetType().FullName, mode, false);
		}

		/// <summary>
		/// Registers the script using the full name of the control, and using the appropriate file extension based upon the script type.
		/// </summary>
		/// <param name="control">The control to reference via the client-side script.</param>
		/// <param name="mode">Whether the script is for debug/release mode.</param>
		/// <param name="isEmbeddedResource">Whether the URL is an embedded resource.</param>
		/// <returns>The URL to the script.</returns>
		public static string GetScriptReference(Control control, ScriptMode mode, bool isEmbeddedResource)
		{
			return GetScriptReference(control, control.GetType().FullName, mode, isEmbeddedResource);
		}

		public static string GetScriptReference(Control control, Type targetType, ScriptMode mode)
		{
			return GetScriptReference(control, targetType, mode, false);
		}

		public static string GetScriptReference(Control control, Type targetType, ScriptMode mode, bool isEmbeddedResource)
		{
			return GetScriptReferenceInternal(control, targetType, targetType.FullName, mode, isEmbeddedResource);
		}

		private static string GetScriptReferenceInternal(Control control, Type objType, string scriptPartialName, ScriptMode mode, bool isEmbeddedResource)
		{
			if (scriptPartialName.ToLower().EndsWith(".js"))
			{
				if (!isEmbeddedResource)
					return scriptPartialName;
				else
					return NucleoAjaxManager.GetWebResourceUrl(control, objType, scriptPartialName);
			}
			else
			{
				string scriptName = (mode == ScriptMode.Debug)
					? scriptPartialName + DebugJS : scriptPartialName + ReleaseJS;

				if (!isEmbeddedResource)
					return scriptName;
				else
					return NucleoAjaxManager.GetWebResourceUrl(control, objType, scriptPartialName);
			}
		}

		public static NucleoScriptReference GetScriptReferenceObject(Control control, string scriptPartialName, ScriptMode mode)
		{
			return GetScriptReferenceObject(control, scriptPartialName, mode, false);
		}

		public static NucleoScriptReference GetScriptReferenceObject(Control control, string scriptPartialName, ScriptMode mode, bool isEmbeddedResource)
		{
			return GetScriptReferenceObjectInternal(control, control.GetType(), scriptPartialName, mode, isEmbeddedResource);
		}

		public static NucleoScriptReference GetScriptReferenceObject(Control control, ScriptMode mode)
		{
			return GetScriptReferenceObject(control, mode, false);
		}

		public static NucleoScriptReference GetScriptReferenceObject(Control control, ScriptMode mode, bool isEmbeddedResource)
		{
			return GetScriptReferenceObject(control, control.GetType(), mode, isEmbeddedResource);
		}

		public static NucleoScriptReference GetScriptReferenceObject(Control control, Type controlType, ScriptMode mode, bool isEmbeddedResource)
		{
			return GetScriptReferenceObjectInternal(control, controlType, controlType.FullName, mode, isEmbeddedResource);
		}

		private static NucleoScriptReference GetScriptReferenceObjectInternal(Control control, Type objType, string scriptPartialName, ScriptMode mode, bool isEmbeddedResource)
		{
			if (scriptPartialName.ToLower().EndsWith(".js"))
			{
				if (!isEmbeddedResource)
					return new NucleoScriptReference(scriptPartialName);
				else
				{
					NucleoScriptReference reference = new NucleoScriptReference();
					reference.Assembly = objType.Assembly.FullName;
					reference.Name = scriptPartialName;
					reference.OriginalPath = scriptPartialName;

					return reference;

					//return new NucleoScriptReference(NucleoAjaxManager.GetWebResourceUrl(control, objType, scriptPartialName));
				}
			}
			else
			{
				string scriptName = (mode == ScriptMode.Debug)
					? scriptPartialName + DebugJS : scriptPartialName + ReleaseJS;

				if (!isEmbeddedResource)
					return new NucleoScriptReference(scriptName);
				else
				{
					NucleoScriptReference reference = new NucleoScriptReference();
					reference.Assembly = objType.Assembly.FullName;
					reference.Name = scriptName;
					reference.OriginalPath = scriptName;

					return reference;

					//return new NucleoScriptReference(NucleoAjaxManager.GetWebResourceUrl(control, objType, scriptPartialName), scriptName, true);
				}
			}
		}

		public static void RegisterCoreScripts(Control control, ScriptMode mode, CoreScriptIncludes scripts, ref ScriptReferenceCollection collection)
		{
			if ((scripts & CoreScriptIncludes.Common) == CoreScriptIncludes.Common)
			{
				collection.Add(new ScriptReference(
					NucleoAjaxManager.GetWebResourceUrl(control, control.GetType(), 
					GetScriptReference(control ,"Nucleo.Common", mode))));
			}

			if ((scripts & CoreScriptIncludes.WebUtilities) == CoreScriptIncludes.WebUtilities)
			{
				collection.Add(new ScriptReference(
					NucleoAjaxManager.GetWebResourceUrl(control, control.GetType(), 
					GetScriptReference(control, "Nucleo.WebUtilities", mode))));
			}

			if ((scripts & CoreScriptIncludes.ObjectUtilities) == CoreScriptIncludes.ObjectUtilities)
			{
				collection.Add(new ScriptReference(
					NucleoAjaxManager.GetWebResourceUrl(control, control.GetType(), 
					GetScriptReference(control, "Nucleo.ObjectUtilities", mode))));
			}
		}

		#endregion
	}
}
