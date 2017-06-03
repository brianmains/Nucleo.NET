using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Plugins
{
	public interface IApplicationModelPlugin
	{
		#region " Properties "

		/// <summary>
		/// Who created the plugin.
		/// </summary>
		string Author { get; }

		/// <summary>
		/// The description that explains what the plugin is all about.
		/// </summary>
		string Description { get; }

		/// <summary>
		/// The most recent publish date for the plugin.
		/// </summary>
		DateTime PublishDate { get; }

		/// <summary>
		/// The title for the plugin.
		/// </summary>
		string Title { get; }

		#endregion



		#region " Methods "

		/// <summary>
		/// Loads any menus into the API
		/// </summary>
		void LoadMenus();

		/// <summary>
		/// Loads any miscellaneous items into the API
		/// </summary>
		void LoadMiscellaneous();

		/// <summary>
		/// Loads any toolbars into the API
		/// </summary>
		void LoadToolbars();

		/// <summary>
		/// Loads any tool windows into the API
		/// </summary>
		void LoadToolWindows();

		/// <summary>
		/// Unloads any document windows into the API
		/// </summary>
		void UnloadDocumentWindows();

		/// <summary>
		/// Unloads any menus into the API
		/// </summary>
		void UnloadMenus();

		/// <summary>
		/// Unloads any miscellaneous items into the API
		/// </summary>
		void UnloadMiscellaneous();

		/// <summary>
		/// Unloads any toolbars into the API
		/// </summary>
		void UnloadToolbars();
		
		/// <summary>
		/// Unloads any tool windows into the API
		/// </summary>
		void UnloadToolWindows();

		#endregion
	}
}
