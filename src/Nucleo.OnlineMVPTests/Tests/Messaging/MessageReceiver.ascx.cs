using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventArguments;
using Nucleo.EventsManagement;
using Nucleo.EventsManagement.Listeners;
using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Tests.Messaging
{
	public interface IMessageReceiverView : IView
	{
		void AddMessage(string message);
	}

	public class MessageReceiverPresenter : BaseWebPresenter<IMessageReceiverView>
	{
		public MessageReceiverPresenter(IMessageReceiverView view) : base(view) 
		{
			view.Initializing += new EventHandler(View_Initializing);
		}

		void View_Initializing(object sender, EventArgs e)
		{
			this.CurrentContext.EventRegistry.Subscribe(
				ListenerCriterion.Identifier("MessageSent"), (details) =>
				{
					string message = details.Attributes["Message"] as string;
					this.View.AddMessage(message);
				});
		}
	}

	[PresenterBinding(typeof(MessageReceiverPresenter))]
	public partial class MessageReceiver : BaseViewUserControl, IMessageReceiverView
	{

		#region " Methods "

		public void AddMessage(string message)
		{
			this.lblMessages.Text += message + "<br/>";
		}

		#endregion
	}
}