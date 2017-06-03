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



namespace Nucleo.Tests.Messaging
{
	public class ManyMessagesPresenter : BasePresenter<IManyMessagesView>
	{
		public ManyMessagesPresenter(IManyMessagesView view)
			: base(view) 
		{
			view.Loading += new EventHandler(View_Loading);
		}

		void View_Loading(object sender, EventArgs e)
		{
			this.CurrentContext.EventRegistry.Publish(
				new PublishedEventDetails(this, ListenerCriterion.EntityType<ManyMessagesPresenter>()));
		}
	}

	public interface IManyMessagesView : IView
	{
		
	}

	[PresenterBinding(typeof(ManyMessagesPresenter))]
	public partial class ManyMessages : BaseViewUserControl, IManyMessagesView
	{
		
	}
}