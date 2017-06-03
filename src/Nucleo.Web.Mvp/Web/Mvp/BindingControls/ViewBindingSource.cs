using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventArguments;
using Nucleo.Views;
using Nucleo.Web.Inspectors;


namespace Nucleo.Web.Mvp.BindingControls
{
	/// <summary>
	/// Represents the binding source that read or writes data to/from the view.
	/// </summary>
	/// <example>
	/// &lt;n:ViewBindingSource ID="vbs" runat="server" TargetControlID="pnlFirstRegion" ModelSource="FirstModelProperty" />
	/// </example>
    public class ViewBindingSource : Control
    {
        private BindingOptions _bindingOptions = null;
		private Control _targetControl = null;



		#region " Events "

		/// <summary>
		/// Fires before an item is being bound.
		/// </summary>
		public event ItemBindingEventHandler ItemBinding;

		/// <summary>
		/// Fires after an item has been bound.
		/// </summary>
		public event ItemBoundEventHandler ItemBound;

		/// <summary>
		/// Fires before the entire binding process happens.
		/// </summary>
		public event ViewBindingEventHandler ViewBindingStarted;

		#endregion



		#region " Properties "

		/// <summary>
        /// Gets or sets the binding options for the binding source.
        /// </summary>
        [
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		Description("Gets or sets the binding options for the binding source.")
		]
        public BindingOptions BindingOptions
        {
            get { return _bindingOptions; }
            set { _bindingOptions = value; }
        }
        
        /// <summary>
        /// Gets or sets the source property of the model.  Set as null if the model is supposed to be the source.
        /// </summary>
        [Description("Gets or sets the source property of the model.  Set as null if the model is supposed to be the source.")]
        public string ModelSource
        {
            get { return (string)ViewState["ModelSource"]; }
            set { ViewState["ModelSource"] = value; }
        }

		/// <summary>
		/// Gets or optionally sets the target control.
		/// </summary>
		[Browsable(false)]
		public Control TargetControl
		{
			get
			{
				if (_targetControl == null)
					_targetControl = ControlUtility.FindControl(this, this.TargetControlID);

				return _targetControl;
			}
			set { _targetControl = value; }
		}

        /// <summary>
        /// Gets or sets the ID of the control to target.
        /// </summary>
        [Description("Gets or sets the ID of the control to target.")]
        public string TargetControlID
        {
            get { return (string)ViewState["TargetControlID"]; }
            set { ViewState["TargetControlID"] = value; }
        }

        /// <summary>
        /// Gets or sets whether to always use the page as the source for any methods, only if the page is a view.
        /// </summary>
        [Description("Gets or sets whether to always use the page as the source for any methods, only if the page is a view.")]
        public bool UsePageAsSource
        {
            get { return (bool)(ViewState["UsePageAsSource"] ?? false); }
            set { ViewState["UsePageAsSource"] = value; }
        }

        #endregion



        #region " Methods "

        private void BindToUI(ModelBindingInspectors inspectors)
        {
			if (CancelBinding() == true)
				return;

			var model = this.GetModelValue();
            if (model == null)
                return;

			foreach (Control control in TargetControl.Controls)
			{
				if (control.ID == null)
					continue;

				var prop = model.GetType().GetProperty(control.ID);
				if (prop == null)
					continue;

				var value = prop.GetValue(model, null);
				var args = new ItemBindingEventArgs(control, ViewBindingDirection.ToUserInterface)
				{
					PropertyName = prop.Name,
					Value = value,
					Cancel = false
				};

				this.OnItemBinding(args);

				if (!args.Cancel)
				{
					SetValueUsingInspector(inspectors, control, model, args.Value);

					this.OnItemBound(new ItemBoundEventArgs(control, ViewBindingDirection.ToUserInterface)
					{
						PropertyName = prop.Name,
						Value = value
					});
				}
            }
        }

		private bool CancelBinding()
		{
			var args = new ViewBindingEventArgs(ViewBindingDirection.ToUserInterface);
			this.OnViewBindingStarted(args);

			return args.Cancel;
		}

        protected virtual IView FindParentView()
        {
            if (this.UsePageAsSource)
            {
				if (this.Page is IView)
					return (IView)this.Page;
            }

            Control currentControl = this;

            while (currentControl.Parent != null)
            {
                currentControl = currentControl.Parent;

                if (currentControl is IView)
                    return (IView)currentControl;
            }

            if (this.Page is IView)
                return (IView)this.Page;

            return null;
        }

		private object GetModelValue()
		{
			var model = this.GetViewModel();
			if (model == null)
				return null;

			//If using an inner property, get this value.
			if (this.ModelSource != null)
			{
				var prop = model.GetType().GetProperty(this.ModelSource);
				if (prop == null)
					throw new InvalidOperationException("The property cound not be found: " + this.ModelSource);

				model = prop.GetValue(model, null);
			}

			return model;
		}

        private object GetViewModel()
        {
            var view = this.FindParentView();
            var viewType = view.GetType();

			var modelProperty = viewType.GetProperty("Model");
			return (modelProperty != null) ? modelProperty.GetValue(view, null) : null;
        }

		private string GetReferenceTableProperty(Control control)
		{
			if (this.BindingOptions == null)
				return control.ID + "ReferenceData";

			bool idSet = false;
			string id = string.Empty;

			if (!string.IsNullOrEmpty(this.BindingOptions.ReferenceTablePrefix))
			{
				id += this.BindingOptions.ReferenceTablePrefix.Replace(" ", "");
				idSet = true;
			}

			id += control.ID;

			if (!string.IsNullOrEmpty(this.BindingOptions.ReferenceTableSuffix))
			{
				id += this.BindingOptions.ReferenceTableSuffix.Replace(" ", "");
				idSet = true;
			}

			if (!idSet)
				id += "ReferenceData";

			return id;
		}

		/// <summary>
		/// Fires the <see cref="BindingStarted"/> event.
		/// </summary>
		/// <param name="e">The details of the event args.</param>
		protected virtual void OnViewBindingStarted(ViewBindingEventArgs e)
		{
			if (ViewBindingStarted != null)
				ViewBindingStarted(this, e);
		}

		protected virtual void OnItemBinding(ItemBindingEventArgs e)
		{
			if (ItemBinding != null)
				ItemBinding(this, e);
		}

		protected virtual void OnItemBound(ItemBoundEventArgs e)
		{
			if (ItemBound != null)
				ItemBound(this, e);
		}

		protected override void OnPreRender(EventArgs e)
		{
			this.BindToUI(ModelBindingInspectors.GetDefault());

			base.OnPreRender(e);
		}

		private void SetValueUsingInspector(ModelBindingInspectors inspectors, Control control, object model, object value)
		{
			var inspector = inspectors.GetInspectorForControl(control);
			if (inspector == null)
				return;

			if (inspector is IDataBoundInspector)
			{
				var refDataProp = model.GetType().GetProperty(this.GetReferenceTableProperty(control));
				if (refDataProp != null)
					((IDataBoundInspector)inspector).BindValues(control, refDataProp.GetValue(model, null));
			}

			if (inspector is IValueControlInspector)
				((IValueControlInspector)inspector).SetValueFromControl(control, value);
		}
		
        #endregion
    }
}