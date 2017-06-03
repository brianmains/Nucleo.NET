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
	public interface IMessageChild02View : IView
	{
		
	}

	public class MessageChild02Presenter : BasePresenter<IMessageChild02View>
	{
		public MessageChild02Presenter(IMessageChild02View view)
			: base(view) 
		{
			
		}
	}
	
	[PresenterBinding(typeof(MessageChild02Presenter))]
	public partial class MessageChild02 : BaseViewUserControl, IMessageChild02View
	{
		#region " Event Definitions "

		public static CancelEvent CancelEvent = EventsManager.Register<CancelEvent>(typeof(MessageChild02), "Cancel", null);
		public static SaveEvent SaveEvent = EventsManager.Register<SaveEvent>(typeof(MessageChild02), "Save", null);

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