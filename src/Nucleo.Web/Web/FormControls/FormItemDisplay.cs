using System;
using System.ComponentModel;
using System.Web.UI;

using Nucleo.Web.Templates;


namespace Nucleo.Web.FormControls
{
	/// <summary>
	/// Represents a single item to display.
	/// </summary>
	public class FormItemDisplay : BaseAjaxControl, IFormItem
	{
		private ControlElementTemplate _editTemplate = null;
		private ControlElementTemplate _insertTemplate = null;
		private FormItemDisplayStyle _itemStyle = null;
		private ControlElementTemplate _readOnlyTemplate = null;



		#region " Properties "

		/// <summary>
		/// Gets the current template from the matching current view.
		/// </summary>
		public ControlElementTemplate CurrentTemplate
		{
			get
			{
				if (this.CurrentView == FormCurrentView.ReadOnly)
					return this.ReadOnlyTemplate;
				else if (this.CurrentView == FormCurrentView.Edit)
					return this.EditTemplate;
				else if (this.CurrentView == FormCurrentView.Insert)
					return this.InsertTemplate;
				else
					return null;
			}
		}

		/// <summary>
		/// Gets the current view.
		/// </summary>
		public FormCurrentView CurrentView
		{
			get { return (FormCurrentView)(ViewState["CurrentView"] ?? FormCurrentView.ReadOnly); }
			private set { ViewState["CurrentView"] = value; }
		}

		/// <summary>
		/// Gets or sets the template when in editing mode.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public ControlElementTemplate EditTemplate
		{
			get{ return _editTemplate; }
			set{ _editTemplate = value; }
		}

		/// <summary>
		/// Gets the header or title for the field.
		/// </summary>
		public string Header
		{
			get { return (string)ViewState["Header"]; }
			set { ViewState["Header"] = value; }
		}

		/// <summary>
		/// Gets or sets the template when in inserting mode.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public ControlElementTemplate InsertTemplate
		{
			get { return _insertTemplate; }
			set { _insertTemplate = value; }
		}

		/// <summary>
		/// Gets or sets the styles to use fo the item.
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

		/// <summary>
		/// Gets or sets the template when in read only mode.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public ControlElementTemplate ReadOnlyTemplate
		{
			get { return _readOnlyTemplate; }
			set { _readOnlyTemplate = value; }
		}

		#endregion



		#region " Constructors "

		public FormItemDisplay() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Changes the current view.
		/// </summary>
		/// <param name="formCurrentView">The view to change to.</param>
		public void ChangeView(FormCurrentView formCurrentView)
		{
			this.CurrentView = formCurrentView;
		}

		protected override void RenderUI(BaseControlWriter writer)
		{
			FormItemDisplayRenderer renderer = new FormItemDisplayRenderer();
			renderer.Initialize(this, this.Page);

			renderer.Render(writer);
		}

		#endregion
	}
}
