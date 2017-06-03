using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.PresenterLoadingSamples
{
	public interface IConfigurationMatchingView : IView
	{
		string Message { get; set; }
	}

	public class ConfigurationMatchingPresenter : BasePresenter<IConfigurationMatchingView>
	{
		public ConfigurationMatchingPresenter(IConfigurationMatchingView view)
			: base(view)
		{
			view.Starting += View_Starting;
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Message = "Loaded by PresenterBindingConfiguration declaration in the configuration file.";
		}
	}

	[PresenterBinding(typeof(ConfigurationMatchingPresenter))]
	public partial class ConfigurationMatching : DemoViewPage, IConfigurationMatchingView
	{
		public override string Description
		{
			get { return "An overview of using a configuration-based methodology to load the presenter."; }
		}


		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
		}

		public string Message
		{
			get { return this.lblMessage.Text; }
			set { this.lblMessage.Text = value; }
		}
	}
}