using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Core;
using Nucleo.Dependencies;
using Nucleo.EventsManagement;
using Nucleo.EventsManagement.Listeners;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;
using Nucleo.Views.Initialization;


namespace Nucleo.Demos.MvpSamples.DI
{
	//This class is used to initialize the presenter with some initial values, maybe performing some DI work
	public class ViewInitializationSampleInitializer : IViewInitializer
	{
		public void Initialize(IView view)
		{
			((IViewInitializerView)view).Message = "Set from view initializer";
		}
	}

	public interface IViewInitializerView : IView
	{
		string Message { get; set; }
	}

	public class ViewInitializerPresenter : BasePresenter<IViewInitializerView>
	{
		public ViewInitializerPresenter(IViewInitializerView view)
			: base(view)
		{

		}
	}

	[PresenterBinding(typeof(ViewInitializerPresenter))]
	public partial class ViewInitializer : DemoViewPage, IViewInitializerView
	{
		//Used to temporarily switch resolver.
		private IDependencyResolver _resolver = null;



		public override string Description
		{
			get { return "Initializing the view"; }
		}


		public string Message
		{
			get { return this.lblInitialization.Text; }
			set { this.lblInitialization.Text = value; }
		}

		protected override void OnInit(EventArgs e)
		{
			//Store and switch temporarily
			_resolver = FrameworkSettings.Resolver;
			//Typically, this would be in global.asax
			FrameworkSettings.Resolver = new DictionaryBasedDependencyResolver(new Dictionary<Type, object>
				{
					{ typeof(IViewInitializer), new ViewInitializationSampleInitializer() }
				});

			base.OnInit(e);
		}

		protected override void OnUnload(EventArgs e)
		{
			//Restore previous
			FrameworkSettings.Resolver = _resolver;

			base.OnUnload(e);
		}
	}
}