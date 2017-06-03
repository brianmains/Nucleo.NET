using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Tests.PresenterLoading
{
	public interface IConfigurationMatchFirstLookView : IView
	{
		string Message { get; set; }
	}

	public class ConfigurationMatchFirstLookPresenter : BasePresenter<IConfigurationMatchFirstLookView>
	{
		public ConfigurationMatchFirstLookPresenter(IConfigurationMatchFirstLookView view) 
			: base(view)
		{
			view.Starting += View_Starting;
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Message = "Loaded by PresenterBindingConfiguration declaration in the configuration file.";
		}
	}

	[PresenterBinding(typeof(ConfigurationMatchFirstLookPresenter))]
	public partial class ConfigurationMatchFirstLook : BaseViewPage, IConfigurationMatchFirstLookView
	{
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