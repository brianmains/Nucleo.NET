using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Presentation;
using Nucleo.Core;
using Nucleo.Core.Options;
using Nucleo.Presentation.Creation;
using Nucleo.Presentation.Discovery;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Tests.PresenterLoading
{
	public interface IConventionMatchFirstLookView : IView
	{
		string Message { get; set; }
	}

	public class ConventionMatchFirstLookPresenter : BasePresenter<IConventionMatchFirstLookView>
	{
		public ConventionMatchFirstLookPresenter(IConventionMatchFirstLookView view) 
			: base(view)
		{
			view.Starting += View_Starting;
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Message = "Loaded by convention without PresenterBinding attribute.";
		}
	}

	public partial class ConventionMatchFirstLook : BaseViewPage, IConventionMatchFirstLookView
	{
		public string Message
		{
			get { return this.lblMessage.Text; }
			set { this.lblMessage.Text = value; }
		}

		protected override void OnInit(EventArgs e)
		{
			//Temporarily switch this out
			FrameworkSettings.DiscoveryStrategy = new ConventionPresentationDiscoveryStrategy();

			base.OnInit(e);
		}

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);

			FrameworkSettings.DiscoveryStrategy = new DefaultPresentationDiscoveryStrategy();
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
		}
	}
}