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


namespace Nucleo.Demos.MvpSamples.MessagingSamples.EventTypes
{
	public interface ITextIdentifierSenderView : IView
	{
		event DataEventHandler<string> Clicked;

		void SendMessage(string message);
	}

	public class TextIdentifierSenderPresenter : BaseWebPresenter<ITextIdentifierSenderView>
	{
		public TextIdentifierSenderPresenter(ITextIdentifierSenderView view)
			: base(view)
		{
			this.View.Clicked += new DataEventHandler<string>(View_Clicked);
		}

		void View_Clicked(object sender, DataEventArgs<string> e)
		{
			//Generally, it would be better to use an identifier here that's unique to the
			//event, and not a generalized name like "Send".  It may be better to also include
			//the source in the name (rename Send to TextIdentifierSenderPresenter-Send) to
			//ensure uniqueness and potential collision with names
			this.CurrentContext.EventRegistry.Publish(new PublishedEventDetails(this,
				ListenerCriterion.Identifier("Send"), new Dictionary<string, object>
				{
					{ "Message", e.Data }
				}));
		}
	}

	[PresenterBinding(typeof(TextIdentifierSenderPresenter))]
	public partial class TextIdentifierSender : DemoViewUserControl, ITextIdentifierSenderView
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