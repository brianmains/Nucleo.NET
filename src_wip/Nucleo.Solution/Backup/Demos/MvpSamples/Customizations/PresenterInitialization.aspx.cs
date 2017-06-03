using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Core;
using Nucleo.Core.Options;
using Nucleo.Dependencies;
using Nucleo.Presentation;
using Nucleo.Presentation.Initialization;
using Nucleo.Presentation.Creation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.Customizations
{
	public class SamplePresenterInitializationDependencyResolver : IDependencyResolver
	{
		public object GetDependency(Type type)
		{
			if (type.Equals(typeof(IPresenterInitializer)))
				return new SamplePresenterInitializer();

			return null;
		}

		public T GetDependency<T>()
		{
			return (T)GetDependency(typeof(T));
		}
	}

	public class SamplePresenterInitializer : IPresenterInitializer
	{

		public void Initialize(IPresenter presenter)
		{
			((PresenterInitializationPresenter)presenter).View.SampleProperty = "This is a custom property assignment from a presenter initializer.";
		}
	}

	public class PresenterInitializationPresenter : BasePresenter<IPresenterInitializationView>
	{
		public PresenterInitializationPresenter(IPresenterInitializationView view)
			: base(view) { }
	}

	public interface IPresenterInitializationView : IView
	{
		string SampleProperty { get; set; }
	}

	[PresenterBinding(typeof(PresenterInitializationPresenter))]
	public partial class PresenterInitialization : DemoViewPage, IPresenterInitializationView
	{

		public override string Description
		{
			get { return "<p>An IPresenterInitializer object can be used to initialize a presenter.  Here, the initializer sets a value on the underlying view to a specific value, but the action could be anything.</p><p>Typically, we'd use a dependency injection container to build up the presenter and pass in dependency references.</p>"; }
		}

		public string SampleProperty
		{
			get { return this.lbl.Text; }
			set { this.lbl.Text = value; }
		}

		protected override void OnInit(EventArgs e)
		{
			FrameworkSettings.Resolver = new SamplePresenterInitializationDependencyResolver();

			base.OnInit(e);
		}

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);

			FrameworkSettings.Resolver = null;
		}
	}
}