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


namespace Nucleo.Demos.MvpSamples.MessagingSamples.EventTypes
{
	public interface IEntityTypeReceiverView : IView
	{
		void AddMessage(string message);
	}

	public class EntityTypeReceiverPresenter : BaseWebPresenter<IEntityTypeReceiverView>
	{
		public EntityTypeReceiverPresenter(IEntityTypeReceiverView view)
			: base(view)
		{
			view.Initializing += new EventHandler(View_Initializing);
		}

		void View_Initializing(object sender, EventArgs e)
		{
			this.CurrentContext.EventRegistry.Subscribe(
				ListenerCriterion.EntityType(typeof(EntityTargetType)), (details) =>
				{
					string message = details.Attributes["Message"] as string;
					this.View.AddMessage(message);
				});
		}
	}

	[PresenterBinding(typeof(EntityTypeReceiverPresenter))]
	public partial class EntityTypeReceiver : DemoViewUserControl, IEntityTypeReceiverView
	{

		#region " Methods "

		public void AddMessage(string message)
		{
			this.lblMessages.Text += message + "<br/>";
		}

		#endregion
	}
}