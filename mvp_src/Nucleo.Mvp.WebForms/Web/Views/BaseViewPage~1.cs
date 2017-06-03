using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Views;


namespace Nucleo.Web.Views
{
	/// <summary>
	/// Represents a base class for views that are a part of the page.
	/// </summary>
	/// <typeparam name="TModel">The model type.</typeparam>
	public abstract class BaseViewPage<TModel> : BaseViewPage
		where TModel: class, new()
	{
		private TModel _model = null;


		#region " Properties "

		/// <summary>
		/// Gets or sets the model in strongly-typed form.
		/// </summary>
		public TModel Model
		{
			get { return _model; }
			set { _model = value; }
		}

		#endregion
	}
}
