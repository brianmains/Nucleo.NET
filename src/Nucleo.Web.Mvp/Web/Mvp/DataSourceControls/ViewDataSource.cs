using System;
using System.ComponentModel;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Views;


namespace Nucleo.Web.Mvp.DataSourceControls
{
	/// <summary>
	/// Represents the data source that binds data from within the view.  The process calls a method within the view to return data to it of a given type (specified by the TypeName property).
	/// </summary>
	public class ViewDataSource : ObjectDataSource
	{
		private IView _hostView = null;



		#region " Properties "

		/// <summary>
		/// Gets the host view.
		/// </summary>
		public IView HostView
		{
			get { return _hostView; }
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



		#region " Constructors "

		/// <summary>
		/// Creates the data source for the view.
		/// </summary>
		public ViewDataSource()
			: this(string.Empty, string.Empty) { }

		/// <summary>
		/// Creates the data source for the view.
		/// </summary>
		/// <param name="typeName">The type name of the entity being bound.</param>
		/// <param name="selectMethod">The method to select from.</param>
		public ViewDataSource(string typeName, string selectMethod)
			: base(typeName, selectMethod) 
		{
			this.ObjectCreating += new ObjectDataSourceObjectEventHandler(ViewDataSource_ObjectCreating);
			this.ObjectDisposing += new ObjectDataSourceDisposingEventHandler(ViewDataSource_ObjectDisposing);
		}

		#endregion



		#region " Methods "

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

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			_hostView = this.FindParentView();
			if (this._hostView is Page)
			{
				TypeName = Assembly.CreateQualifiedName(
					Page.GetType().Assembly.FullName,
					Page.GetType().FullName);
			}
			else
			{
				var parentBaseType = ((Control)_hostView).GetType().BaseType;
				TypeName = parentBaseType.FullName;
			}
		}

		#endregion



		#region " Event Handlers "

		void ViewDataSource_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
		{
			if (_hostView == null)
				throw new InvalidOperationException("Cannot find a parent view to host the ViewDataSource in.");

			e.ObjectInstance = _hostView;
		}

		void ViewDataSource_ObjectDisposing(object sender, ObjectDataSourceDisposingEventArgs e)
		{
			e.Cancel = true;
		}

		#endregion
	}
}
