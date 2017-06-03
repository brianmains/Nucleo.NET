using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Presentation;


namespace Nucleo.Web.Services
{
	/// <summary>
	/// Represents the base class for WCF services that act as a view.
	/// </summary>
	/// <typeparam name="TModel">The model type.</typeparam>
	public class ViewWcfService<TModel> : ViewWcfService
		where TModel : class, new()
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
