using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventsManagement;
using Nucleo.EventsManagement.Listeners;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;
using Nucleo.Presentation.Modules;

using Nucleo.ModuleDemo.Models;
using Nucleo.ModuleDemo.Presentation;
using Nucleo.ModuleDemo.Views;


namespace Nucleo.Demos.MvpSamples.ModuleSamples
{
	[PresenterBinding(typeof(FirstLookPresenter))]
	public partial class FirstLook : DemoViewPage<FirstLookModel>, IFirstLookView
	{
		public override string Description
		{
			get { return "A first look at using modules."; }
		}



		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (this.Model == null)
				return;

			this.lblOutput.Text = (this.Model.Module != null)
				? "A module was found, with the given type: " + this.Model.Module.GetType().FullName + ". This module was given to the presenter dynamically, because the assembly the presenter contained a module attribute."
				: "No module has been loaded into the presenter.  This means the assembly with the presenter defined does not have a module attribute.";
		}
	}
}