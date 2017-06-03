using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.EditorControls;
using Nucleo.Web.Tags;


namespace Nucleo.Web.Mvc.EditorControls
{
	public abstract class BaseEditorControlControlBuilder<TItem, TBuilder> : BaseMvcControlBuilder<TItem, TBuilder>
		where TItem: BaseEditorControl
		where TBuilder: BaseEditorControlControlBuilder<TItem, TBuilder>
	{
		#region " Constructors "

		public BaseEditorControlControlBuilder(NucleoControlFactory controlFactory)
			: base(controlFactory) { }

		#endregion



		#region " Methods "

		public TBuilder CurrentState(EditorCurrentState state)
		{
			this.GetControl().CurrentState = state;
			return this as TBuilder;
		}

		public TBuilder ReadOnly(bool readOnly)
		{
			this.GetControl().ReadOnly = readOnly;
			return this as TBuilder;
		}

		public TBuilder Text(string text)
		{
			this.GetControl().Text = text;
			return this as TBuilder;
		}

		#endregion
	}
}
