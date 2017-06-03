using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.DataSource
{
	public interface INestedControlsView : IView
	{

	}


	public class NestedControlsPresenter : BasePresenter<INestedControlsView>
	{
		public NestedControlsPresenter(INestedControlsView view)
			: base(view) { }
	}

	[PresenterBinding(typeof(NestedControlsPresenter))]
	public partial class NestedControls : DemoViewPage, INestedControlsView
	{

		public override string Description
		{
			get { return "nested controls"; }
		}

		public IEnumerable<TestClass> GetAll()
		{
			return new TestClass[]
			{
				new TestClass { Key = 1, Name = "PA" },
				new TestClass { Key = 2, Name = "MD" },
				new TestClass { Key = 3, Name = "DC" },
				new TestClass { Key = 4, Name = "VA" }
			};
		}
	}
}