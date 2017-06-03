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
	public interface IAttributeMatchFirstLookView : IView
	{
		string Message { get; set; }
	}

	public class AttributeMatchFirstLookPresenter : BasePresenter<IAttributeMatchFirstLookView>
	{
		public AttributeMatchFirstLookPresenter(IAttributeMatchFirstLookView view) 
			: base(view)
		{
			view.Starting += View_Starting;
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Message = "Loaded by PresenterBindingAttribute declarationon the view.";
		}
	}

	[PresenterBinding(typeof(AttributeMatchFirstLookPresenter))]
	public partial class AttributeMatchFirstLook : BaseViewPage, IAttributeMatchFirstLookView
	{
		public string Message
		{
			get { return this.lblMessage.Text; }
			set { this.lblMessage.Text = value; }
		}
	}
}