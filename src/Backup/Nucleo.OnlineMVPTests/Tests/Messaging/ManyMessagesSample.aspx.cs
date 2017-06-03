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
	public class ManyMessagesSamplePresenter : BasePresenter<IManyMessagesSampleView>
	{
		public int id = 1;

		public ManyMessagesSamplePresenter(IManyMessagesSampleView view)
			: base(view)
		{
			view.Initializing += new EventHandler(View_Initializing);
		}

		void View_Initializing(object sender, EventArgs e)
		{
			this.CurrentContext.EventRegistry.Subscribe(
				ListenerCriterion.EntityType<ManyMessagesPresenter>(),
				(d) => 
				{		
					HttpContext.Current.Response.Write(string.Format("A subpresenter published an event: {0}<br/>", id++)); 
				});
		}
	}

	public interface IManyMessagesSampleView : IView
	{

	}

	[PresenterBinding(typeof(ManyMessagesSamplePresenter))]
	public partial class ManyMessagesSample : BaseViewPage, IManyMessagesSampleView
	{
		
	}
}