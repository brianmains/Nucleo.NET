using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventsManagement;
using Nucleo.EventsManagement.Listeners;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpScenarios.TabbedForms
{
	public interface IParentView : IView<ParentModel>
	{

	}

	public class ParentModel
	{

	}

	public class ParentPresenter : BasePresenter<IParentView>
	{
		public ParentPresenter(IParentView view)
			: base(view)
		{

		}
	}

	[PresenterBinding(typeof(ParentPresenter))]
	public partial class Parent : DemoViewPage<ParentModel>, IParentView
	{
		public override string Description
		{
			get { return "Parent"; }
		}
	}
}