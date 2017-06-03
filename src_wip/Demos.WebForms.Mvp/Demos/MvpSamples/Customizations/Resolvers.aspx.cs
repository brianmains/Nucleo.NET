using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nucleo.Dependencies;
using Nucleo.Presentation;
using Nucleo.Presentation.Creation;
using Nucleo.Core;
using Nucleo.Core.Options;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.Customizations
{
	public interface IResolverDatabaseService
	{
		object[] GetData();
	}

	public class SampleResolverDatabaseService : IResolverDatabaseService
	{
		public object[] GetData()
		{
			return new[]
			{
				new { Name = "A", Value = 1 },
				new { Name = "B", Value = 2 },
				new { Name = "C", Value = 3 }
			};
		}
	}

	public class SampleResolver : IDependencyResolver
	{

		public object GetDependency(Type type)
		{
			if (type.Equals(typeof(IResolverDatabaseService)))
				return new SampleResolverDatabaseService();
			else
				return null;
		}

		public T GetDependency<T>()
		{
			if (typeof(T).Equals(typeof(IResolverDatabaseService)))
				return (T)((object)new SampleResolverDatabaseService());
			else
				return default(T);
		}
	}

	public class ResolversModel
	{
		public object Data { get; set; }
	}

	public class ResolversPresenter : BasePresenter<IResolversView>
	{
		public IResolverDatabaseService Service { get; set; }

		public ResolversPresenter(IResolversView view, IResolverDatabaseService service)
			: base(view)
		{
			this.Service = service;
			view.Starting += new EventHandler(View_Starting);
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Model = new ResolversModel
			{
				Data = this.Service.GetData()
			};
		}
	}

	public interface IResolversView : IView<ResolversModel> { }

	[PresenterBinding(typeof(ResolversPresenter))]
	public partial class Resolvers : DemoViewPage<ResolversModel>, IResolversView
	{
		public override string Description
		{
			get { return "<p>The dependency resolver mimics ASP.NET MVC's implementation.  Most object references (like the presenter discovery strategy, for instance) is first checked within the resolver for existence.  If it doesn't exist, the default logic is the fallback.</p><p>The resolver essentially is a wrapper for a DI container, although it isn't meant to be an actual DI container representation.  It's only meant to resolve references internally for the framework, and potentially for retrieving some additional references.  By this I mean it doesn't register mappings, build up objects, or perform other common DI operations.</p>"; }
		}


		protected override void OnInit(EventArgs e)
		{
			FrameworkSettings.Resolver = new SampleResolver();

			base.OnInit(e);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.Model != null && this.Model.Data != null)
			{
				this.gvw.DataSource = this.Model.Data;
				this.gvw.DataBind();
			}
		}

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);

			//Just used to restore previous configuration
			FrameworkSettings.Resolver = null;
		}
	}
}