using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.Hierarchy
{
	public interface IFirstLookView : IView { }

	public class FirstLookPresenter : BasePresenter<IFirstLookView>
	{
		public FirstLookPresenter(IFirstLookView view)
			: base(view) { }
	}

	[PresenterBinding(typeof(FirstLookPresenter))]
	public partial class FirstLook : DemoViewPage, IFirstLookView
	{

		public override string Description
		{
			get { return "An overview of the hierarchy of controls."; }
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
		}
	}
}