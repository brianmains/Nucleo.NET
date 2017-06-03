using System;
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
	public interface IWithEventsChild01View : IView
	{

	}

	public class WithEventsChild01Presenter : BasePresenter<IWithEventsChild01View>
	{
		public WithEventsChild01Presenter(IWithEventsChild01View view)
			: base(view)
		{

		}
	}

	[PresenterBinding(typeof(WithEventsChild01Presenter))]
	public partial class WithEventsChild01 : DemoViewUserControl, IWithEventsChild01View
	{
		#region " Event Definitions "

		public static CancelEvent CancelEvent = EventsManager.Register<CancelEvent>(typeof(WithEventsChild01), "Cancel", null);
		public static SaveEvent SaveEvent = EventsManager.Register<SaveEvent>(typeof(WithEventsChild01), "Save", null);

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