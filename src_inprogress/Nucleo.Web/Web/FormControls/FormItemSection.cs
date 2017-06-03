using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.ClientRegistration;
using Nucleo.Web.Templates;


namespace Nucleo.Web.FormControls
{
	/// <summary>
	/// Represents a container for <see cref="IFormItem"/> object instance.
	/// </summary>
	/// <example>
	/// &lt;n:FormItemSection id="fs" runat="server" CurrentView="ReadOnly">
	///		&lt;Items>
	///			&lt;FormItemDisplay .. />
	///		&lt;/Items>
	/// %lt;/n:FormItemSection>
	/// </example>
	public class FormItemSection : BaseAjaxControl
	{
		private ControlElementTemplate _content = null;
		private ControlElementTemplate _header = null;
		private FormItemDisplayStyle _itemStyle = null;



		#region  " Properties "

		/// <summary>
		/// Gets or sets the content of the element, which replaces the existing content of the control and override the collection of items.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		ClientProperty("content"),
		MergableProperty(false)
		]
		public ControlElementTemplate Content
		{
			get { return _content; }
			set { _content = value; }
		}

		/// <summary>
		/// Gets the current view that the whole section is currently displaying in.
		/// </summary>
		public FormCurrentView CurrentView
		{
			get { return (FormCurrentView)(ViewState["CurrentView"] ?? FormCurrentView.ReadOnly); }
			private set { ViewState["CurrentView"] = value; }
		}
		
		/// <summary>
		/// Gets or sets the header to append to the top of the UI.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		ClientProperty("content"),
		MergableProperty(false)
		]
		public ControlElementTemplate Header
		{
			get { return _header; }
			set { _header = value; }
		}

		/// <summary>
		/// Gets the collection of items to display in the container.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public FormItemCollection Items
		{
			get { return (FormItemCollection)this.Controls; }
		}

		/// <summary>
		/// Gets or sets the styles to apply for each item; each item can be styled individually, or a global style can be setup here.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content)
		]
		public FormItemDisplayStyle ItemStyle
		{
			get { return _itemStyle; }
			set { _itemStyle = value; }
		}

		#endregion



		#region " Methods "

		protected override void AddedControl(Control control, int index)
		{
			base.AddedControl(control, index);

			((IFormItem)control).ChangeView(this.CurrentView);
		}

		/// <summary>
		/// Changes the current view.  This also controls the individual item displays.
		/// </summary>
		/// <param name="formCurrentView">The view to change to.</param>
		public void ChangeView(FormCurrentView formCurrentView)
		{
			this.CurrentView = formCurrentView;

			foreach (IFormItem item in this.Items)
				item.ChangeView(formCurrentView);
		}

		protected override ControlCollection CreateControlCollection()
		{
			return new FormItemCollection(this);
		}

		protected override void RenderUI(BaseControlWriter writer)
		{
			FormItemSectionRenderer renderer = new FormItemSectionRenderer();
			renderer.Initialize(this, this.Page);
			renderer.Render(writer);
		}

		#endregion
	}
}
