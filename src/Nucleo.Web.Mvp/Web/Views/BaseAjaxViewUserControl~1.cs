using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Views
{
	public class BaseAjaxViewUserControl<TModel> : BaseAjaxViewUserControl
		where TModel: class
	{
		private TModel _model = null;


		#region " Properties "

		public TModel Model
		{
			get { return _model; }
			set { _model = value; }
		}

		#endregion
	}
}
