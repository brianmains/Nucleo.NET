using System;
using System.Web.UI;


namespace Nucleo.Web.EditorControls
{
	/// <summary>
	/// Represents a common interface for editor controls.
	/// </summary>
	public interface IEditorControl : ITextControl
	{
		/// <summary>
		/// Gets or sets the ID of the editor control.
		/// </summary>
		string ID { get; set; }

		/// <summary>
		/// Gets whether the editor control has changes.
		/// </summary>
		bool HasChanges { get; }

		/// <summary>
		/// Gets or sets whether the editor control is readonly.
		/// </summary>
		bool ReadOnly { get; set; }
	}
}
