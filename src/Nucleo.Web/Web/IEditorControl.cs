using System;


namespace Nucleo.Web
{
	public interface IEditorControl
	{
		/// <summary>
		/// Gets or sets whether the control is in read-only mode.
		/// </summary>
		bool ReadOnly { get; set; }
	}
}
