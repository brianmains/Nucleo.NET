using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Views
{
	[Obsolete("Please use BaseViewPage with the IAjaxScriptableComponent designation.")]
	public class BaseAjaxViewPage<TModel> : BaseAjaxViewPage
		where TModel: class, new()
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
