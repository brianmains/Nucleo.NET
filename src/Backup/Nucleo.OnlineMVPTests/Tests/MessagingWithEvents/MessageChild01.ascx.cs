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


namespace Nucleo.Tests.MessagingWithEvents
{
	public interface IMessageChild01View : IView
	{
		
	}

	public class MessageChild01Presenter : BasePresenter<IMessageChild01View>
	{
		public MessageChild01Presenter(IMessageChild01View view)
			: base(view) 
		{
			
		}
	}

	[PresenterBinding(typeof(MessageChild01Presenter))]
	public partial class MessageChild01 : BaseViewUserControl, IMessageChild01View
	{
		#region " Event Definitions "

		public static CancelEvent CancelEvent = EventsManager.Register<CancelEvent>(typeof(MessageChild01), "Cancel", null);
		public static SaveEvent SaveEvent = EventsManager.Register<SaveEvent>(typeof(MessageChild01), "Save", null);

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