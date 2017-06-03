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
	public interface IAttributeMatchingView : IView
	{
		string Message { get; set; }
	}

	public class AttributeMatchingPresenter : BasePresenter<IAttributeMatchingView>
	{
		public AttributeMatchingPresenter(IAttributeMatchingView view)
			: base(view)
		{
			view.Starting += View_Starting;
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Message = "Loaded by PresenterBindingAttribute declarationon the view.";
		}
	}

	[PresenterBinding(typeof(AttributeMatchingPresenter))]
	public partial class AttributeMatching : DemoViewPage, IAttributeMatchingView
	{
		public override string Description
		{
			get { return "An overview of using a attribute-based methodology to load the presenter."; }
		}

		public string Message
		{
			get { return this.lblMessage.Text; }
			set { this.lblMessage.Text = value; }
		}
	}
}