using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nucleo.Presentation;
using Nucleo.Presentation.Creation;
using Nucleo.Core;
using Nucleo.Core.Options;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.Customizations
{
	public interface IDatabaseService
	{
		object[] GetData();
	}

	public class SampleDatabaseService : IDatabaseService
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

	public class SamplePresenterCreator : IPresenterCreator
	{
		public IPresenter Create(Type presenterType, object view)
		{
			//Could be DI container instead
			return (IPresenter)Activator.CreateInstance(presenterType,
				new object[] { view, ((IDatabaseService)(new SampleDatabaseService())) });
		}
	}

	public class PresenterCreationModel
	{
		public object Data { get; set; }
	}

	public class PresenterCreationPresenter : BasePresenter<IPresenterCreationView>
	{
		public IDatabaseService Service { get; set; }

		public PresenterCreationPresenter(IPresenterCreationView view, IDatabaseService service)
			: base(view)
		{
			this.Service = service;
			view.Starting += new EventHandler(View_Starting);
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Model = new PresenterCreationModel
			{
				Data = this.Service.GetData()
			};
		}
	}

	public interface IPresenterCreationView : IView<PresenterCreationModel> { }

	[PresenterBinding(typeof(PresenterCreationPresenter))]
	public partial class PresenterCreation : DemoViewPage<PresenterCreationModel>, IPresenterCreationView
	{
		public override string Description
		{
			get { return "<p>This example illustrates what a customized presenter creator looks like.  In this example, the creator injects into the constructor of a presenter a service that gets some data.  This service, in turn, gets data that gets passed to the view, eventually appearing in the user interface through a gridview.</p><p>Here we could use a dependency injection container, or some other object, to pass in references, instead of hard-coding the reference to pass in.  This was done for example purposes.</p>"; }
		}


		protected override void OnInit(EventArgs e)
		{
			FrameworkSettings.Creator = new SamplePresenterCreator();

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
			FrameworkSettings.Creator = new DefaultPresenterCreator();
		}
	}
}