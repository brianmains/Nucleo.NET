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


namespace Nucleo.Tests.Customizations
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
			((PresenterInitializationPresenter)presenter).View.SampleProperty = "Custom property.";
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
	public partial class PresenterInitialization : BaseViewPage, IPresenterInitializationView
	{
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