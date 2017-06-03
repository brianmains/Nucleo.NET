using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Views
{
	public class View<TModel> : View, IView<TModel>
	{
		private TModel _model = default(TModel);



		#region " Properties "

		public TModel Model
		{
			get { return _model; }
			set { _model = value; }
		}

		#endregion
	}
}
