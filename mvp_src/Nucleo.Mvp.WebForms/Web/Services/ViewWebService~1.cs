using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Services
{
	/// <summary>
	/// Represents the web service that represents the view.
	/// </summary>
	/// <typeparam name="TModel">The type of model.</typeparam>
	public class ViewWebService<TModel> : ViewWebService
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
