using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Tests.Hierarchy
{
	public interface IHierarchy1View : IView { }

	public class Hierarchy1Presenter : BasePresenter<IHierarchy1View>
	{
		public Hierarchy1Presenter(IHierarchy1View view)
			: base(view) { }
	}

	[PresenterBinding(typeof(Hierarchy1Presenter))]
	public partial class Hierarchy1 : BaseViewUserControl, IHierarchy1View
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
		}
	}
}