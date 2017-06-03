﻿using System;
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
	public interface IMessageSenderView : IView
	{
		event DataEventHandler<string> Clicked;

		void SendMessage(string message);
	}

	public class MessageSenderPresenter : BaseWebPresenter<IMessageSenderView>
	{
		public MessageSenderPresenter(IMessageSenderView view) : base(view) 
		{
			this.View.Clicked += new DataEventHandler<string>(View_Clicked);
		}

		void View_Clicked(object sender, DataEventArgs<string> e)
		{
			this.CurrentContext.EventRegistry.Publish(new PublishedEventDetails(this,
				ListenerCriterion.Identifier("MessageSent"), new Dictionary<string, object>
				{
					{ "Message", e.Data }
				}));
		}
	}

	[PresenterBinding(typeof(MessageSenderPresenter))]
	public partial class MessageSender : BaseViewUserControl, IMessageSenderView
	{
		public event DataEventHandler<string> Clicked;

		#region " Properties "

		public void SendMessage(string message)
		{
			if (Clicked != null)
				Clicked(this, new DataEventArgs<string>(message));
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			this.SendMessage(this.txtMsg.Text);
		}

		#endregion
	}
}