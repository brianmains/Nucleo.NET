using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web
{
	/// <summary>
	/// Provides a static way to point to the script modes within attribute definition, etc.
	/// </summary>
	public static class ScriptModes
	{
		/// <summary>
		/// Gets the auto script mode.
		/// </summary>
		public const ScriptMode Auto = ScriptMode.Auto;

		/// <summary>
		/// Gets the debug script mode.
		/// </summary>
		public const ScriptMode Debug = ScriptMode.Debug;

		/// <summary>
		/// Gets the inherit script mode.
		/// </summary>
		public const ScriptMode Inherit = ScriptMode.Inherit;

		/// <summary>
		/// Gets the release script mode.
		/// </summary>
		public const ScriptMode Release = ScriptMode.Release;
	}
}
