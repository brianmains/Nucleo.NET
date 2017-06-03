﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Core;
using Nucleo.Core.Options;
using Nucleo.Dependencies;
using Nucleo.Presentation;
using Nucleo.Presentation.Creation;
using Nucleo.Views;
using Nucleo.Views.Initialization;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.Customizations
{
	public class SampleViewInitializationDependencyResolver : IDependencyResolver
	{
		public object GetDependency(Type type)
		{
			if (type.Equals(typeof(IViewInitializer)))
				return new SampleViewInitializer();

			return null;
		}

		public T GetDependency<T>()
		{
			if (typeof(T).Equals(typeof(IViewInitializer)))
				return (T)((object)new SampleViewInitializer());

			return default(T);
		}
	}

	public class SampleViewInitializer : IViewInitializer
	{

		public void Initialize(IView view)
		{
			((IViewInitializationView)view).SampleProperty = "This is a custom property assignment from a view initializer.";
		}
	}

	public class ViewInitializationPresenter : BasePresenter<IViewInitializationView>
	{
		public ViewInitializationPresenter(IViewInitializationView view)
			: base(view) { }
	}

	public interface IViewInitializationView : IView
	{
		string SampleProperty { get; set; }
	}

	[PresenterBinding(typeof(ViewInitializationPresenter))]
	public partial class ViewInitialization : DemoViewPage, IViewInitializationView
	{
		public override string Description
		{
			get { return "<p>An IViewInitializer object can be used to initialize a view.  Here, the initializer sets a value on the underlying view to a specific value, but the action could be anything.</p><p>Typically, we'd use a dependency injection container to build up the view and pass in dependency references.</p>"; }
		}


		public string SampleProperty
		{
			get { return this.lbl.Text; }
			set { this.lbl.Text = value; }
		}

		protected override void OnInit(EventArgs e)
		{
			FrameworkSettings.Resolver = new SampleViewInitializationDependencyResolver();

			base.OnInit(e);
		}

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);

			FrameworkSettings.Resolver = null;
		}
	}
}