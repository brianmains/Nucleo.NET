using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.EditorControls;


namespace Nucleo.Web.Mvc.EditorControls
{
	public class TextEditorControlBuilder : BaseEditorControlControlBuilder<TextEditor, TextEditorControlBuilder>
	{
		#region " Constructors "

		public TextEditorControlBuilder(NucleoControlFactory controlFactory)
			: base(controlFactory) { }

		#endregion
	}
}
