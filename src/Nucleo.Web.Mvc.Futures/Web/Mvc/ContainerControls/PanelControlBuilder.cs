using System;
using System.Web.Mvc;
using System.Web.UI;
using System.ComponentModel;
using System.Collections.Generic;

using Nucleo.Web;
using Nucleo.Web.ContainerControls;
using Nucleo.Web.Templates;


namespace Nucleo.Web.Mvc.ContainerControls
{
	/// <summary>
	/// Represents the control builder for the panel.
	/// </summary>
	public class PanelControlBuilder : BaseMvcControlBuilder<Panel, PanelControlBuilder>
	{
		private ActionElementTemplate _content = null;



		#region " Constructors "

		public PanelControlBuilder(NucleoControlFactory controlFactory)
			: base(controlFactory) { }

		#endregion



		#region " Methods "

		public PanelControlBuilder Content(System.Action content)
		{
			if (content == null)
				throw new ArgumentNullException("content");

			_content = new ActionElementTemplate(content);
			return this;
		}

		public PanelControlBuilder DragDrop(PanelDragDropOptions dragDrop)
		{
			if (dragDrop == null)
				throw new ArgumentNullException("dragDrop");

			this.GetControl().DragDrop = dragDrop;
			return this;
		}

		/// <summary>
		/// Sets the control's hovering options.
		/// </summary>
		/// <param name="hovering">The options for hovering.</param>
		/// <returns>The control builder.</returns>
		public PanelControlBuilder Hovering(PanelHoverOptions hovering)
		{
			if (hovering == null)
				throw new ArgumentNullException("hovering");

			this.GetControl().Hovering = hovering;
			return this;
		}

		public PanelControlBuilder Modal(PanelModalOptions options)
		{
			if (options == null)
				throw new ArgumentNullException("options");

			this.GetControl().Modal = options;
			return this;
		}

		protected override void RenderUI(BaseControlWriter writer)
		{
			PanelRenderer renderer = new PanelRenderer();
			renderer.Initialize(this.GetControl(), this.GetControl().Page);

			renderer.Template = _content;

			renderer.Render(writer);
		}

		/// <summary>
		/// Sets the control's resizing options.
		/// </summary>
		/// <param name="resizing">The options for resizing.</param>
		/// <returns>The control builder.</returns>
		public PanelControlBuilder Resizing(PanelResizeOptions resizing)
		{
			if (resizing == null)
				throw new ArgumentNullException("resizing");

			this.GetControl().Resizing = resizing;
			return this;
		}

		public PanelControlBuilder TimeSensitivity(PanelTimeSensitivityOptions options)
		{
			if (options == null)
				throw new ArgumentNullException("options");

			this.GetControl().TimeSensitivity = options;
			return this;
		}

		/// <summary>
		/// Sets the title for the panel.
		/// </summary>
		/// <param name="title">The title to display.</param>
		/// <returns>The control builder.</returns>
		public PanelControlBuilder Title(string title)
		{
			this.GetControl().Title = title;
			return this;
		}

		#endregion
	}
}