﻿using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Collections;
using Nucleo.Context;
using Nucleo.EventsManagement;
using Nucleo.Models;
using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.Views;
using Nucleo.Web.Context;
using Nucleo.Web.Core;


namespace Nucleo.Web.Presentation
{
	public class BaseWebPresenter<TView> : BasePresenter<TView>
		where TView : IView
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
