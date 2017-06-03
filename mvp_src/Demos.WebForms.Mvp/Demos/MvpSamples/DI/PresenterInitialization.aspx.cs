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
using Nucleo.Presentation.Initialization;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.DI
{
	//This class is used to initialize the presenter with some initial values, maybe performing some DI work
	public class PresenterInitializationSampleInitializer : IPresenterInitializer
	{

		public void Initialize(IPresenter presenter)
		{
			((IPresenterInitializationView)presenter.View).Message = "Loaded from PresenterInitializationInitializer class.";
		}
	}


	public interface IPresenterInitializationView : IView
	{
		string Message { get; set; }
	}

	public class PresenterInitializationPresenter : BasePresenter<IPresenterInitializationView>
	{
		public PresenterInitializationPresenter(IPresenterInitializationView view)
			: base(view) { }
	}

	[PresenterBinding(typeof(PresenterInitializationPresenter))]
	public partial class PresenterInitialization : DemoViewPage, IPresenterInitializationView
	{
		//Used to temporarily switch resolver.
		private IDependencyResolver _resolver = null;



		public override string Description
		{
			get { return "Initializing the presenter"; }
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
					{ typeof(IPresenterInitializer), new PresenterInitializationSampleInitializer() }
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