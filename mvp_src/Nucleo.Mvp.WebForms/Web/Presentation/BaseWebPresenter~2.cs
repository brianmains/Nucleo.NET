using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Collections;
using Nucleo.Context;
using Nucleo.EventsManagement;
using Nucleo.Models;
using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.Presentation.Context;
using Nucleo.Web.Presentation.Context;
using Nucleo.Views;
using Nucleo.Web.Context;
using Nucleo.Web.Core;


namespace Nucleo.Web.Presentation
{
	public class BaseWebPresenter<TView, TModel> : BasePresenter<TView, TModel>
		where TView : IView<TModel>
		where TModel : class, new()
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the current context.
		/// </summary>
		new public PresenterWebContext CurrentContext
		{
			get { return (PresenterWebContext)base.CurrentContext; }
			set { base.CurrentContext = value; }
		}

		#endregion



		#region " Constructors "

		public BaseWebPresenter(TView view)
			: base(view) { }

		#endregion



		#region " Methods "

		protected override PresenterContext CreatePresenterContext()
		{
			return PresenterWebContextCreator.Create();
		}

		#endregion
	}
}
