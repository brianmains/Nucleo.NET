using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Views
{
	/// <summary>
	/// Represents a base class for views that are a part of the page as a user control.
	/// </summary>
	public abstract class BaseViewUserControl<TModel> : BaseViewUserControl
		where TModel: class
	{
		private TModel _model = null;


		#region " Properties "

		/// <summary>
		/// Gets or sets the model for the view.
		/// </summary>
		public TModel Model
		{
			get { return _model; }
			set { _model = value; }
		}

		#endregion
	}
}
