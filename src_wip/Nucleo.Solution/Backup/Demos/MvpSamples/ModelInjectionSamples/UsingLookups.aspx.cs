using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Lookups;
using Nucleo.Lookups.Providers;
using Nucleo.Lookups.Repositories;
using Nucleo.Models;
using Nucleo.Models.Lookups;
using Nucleo.Presentation;
using Nucleo.Presentation.Context;
using Nucleo.Views;
using Nucleo.Web.Views;
using Nucleo.Lookups.Identification;


namespace Nucleo.Demos.MvpSamples.ModelInjectionSamples
{
	public class UsingLookupsRepository : ILookupRepository
	{

		public LookupCollection GetAllValues(LookupCriteria criteria)
		{
			string name = ((NameLookupIdentifier)criteria.Identifier).Name;

			if (name == "Countries")
			{
				return new LookupCollection
				{
					new Lookup { Name = "US", Value = "United States", RepresentationCode = "US" },
					new Lookup { Name = "CAN", Value = "Canada", RepresentationCode = "CAN" },
					new Lookup { Name = "MEX", Value = "Mexico", RepresentationCode = "MEX" }
				};
			}
			else if (name == "States")
			{
				return new LookupCollection
				{
					new Lookup { Name = "PA", Value = "Pennsylvania", RepresentationCode = "PA" },
					new Lookup { Name = "MD", Value = "Maryland", RepresentationCode = "MD" },
					new Lookup { Name = "NY", Value = "New York", RepresentationCode = "NY" }
				};
			}

			return new LookupCollection() { };
		}
	}

	public class UsingLookupsProvider : ILookupProvider
	{

		public ILookupRepository GetRepository(Lookups.Identification.ILookupIdentifier id)
		{
			return new UsingLookupsRepository();
		}

		public bool SupportsIdentifier(Lookups.Identification.ILookupIdentifier id)
		{
			return (id is NameLookupIdentifier);
		}
	}

	public class UsingLookupsModel
	{
		[LookupInjection("Countries")]
		public LookupCollection Countries { get; set; }

		[LookupInjection("States")]
		public LookupCollection States { get; set; }
	}

	public interface IUsingLookupsView : IView<UsingLookupsModel>
	{

	}

	public class UsingLookupsPresenter : BasePresenter<IUsingLookupsView>
	{
		public UsingLookupsPresenter(IUsingLookupsView view)
			: base(view)
		{
			View.Starting += View_Starting;
		}

		protected override PresenterContext CreatePresenterContext()
		{
			var ctx = base.CreatePresenterContext();

			//Replace the defaults

			LookupManager mgr = LookupManager.Create();
			mgr.Register(new UsingLookupsProvider());

			ctx.ModelInjection.RegisterBinding(new LookupModelDataLoader(mgr));

			return ctx;
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Model = new UsingLookupsModel();
			this.CurrentContext.ModelInjection.LoadInitialModelData(this.View.Model);
		}
	}

	[PresenterBinding(typeof(UsingLookupsPresenter))]
	public partial class UsingLookups : DemoViewPage<UsingLookupsModel>, IUsingLookupsView
	{
		public override string Description
		{
			get { return "Using a lookup provider for injecting model-based data."; }
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			this.gvwCountries.DataSource = this.Model.Countries;
			this.gvwCountries.DataBind();

			this.gvwStates.DataSource = this.Model.States;
			this.gvwStates.DataBind();
		}
	}
}