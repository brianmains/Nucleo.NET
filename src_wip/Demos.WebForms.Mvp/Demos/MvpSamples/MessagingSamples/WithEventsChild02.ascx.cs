﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventsManagement;
using Nucleo.EventsManagement.Listeners;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.MessagingSamples
{
	public interface IWithEventsChild02View : IView
	{

	}

	public class WithEventsChild02Presenter : BasePresenter<IWithEventsChild02View>
	{
		public WithEventsChild02Presenter(IWithEventsChild02View view)
			: base(view)
		{

		}
	}

	[PresenterBinding(typeof(WithEventsChild02Presenter))]
	public partial class WithEventsChild02 : DemoViewUserControl, IWithEventsChild02View
	{
		#region " Event Definitions "

		public static CancelEvent CancelEvent = EventsManager.Register<CancelEvent>(typeof(WithEventsChild02), "Cancel", null);
		public static SaveEvent SaveEvent = EventsManager.Register<SaveEvent>(typeof(WithEventsChild02), "Save", null);

		#endregion



		#region " Event Handlers "

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			var evt = EventsManager.GetEvent(this, "Cancel");
			if (evt != null)
				evt.Raise(this);
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			var evt = EventsManager.GetEvent(this, "Save");
			if (evt != null)
				evt.Raise(this);
		}

		#endregion
	}
}