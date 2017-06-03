using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventsManagement;
using Nucleo.EventsManagement.Listeners;
using Nucleo.Orm.Entities;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;

using Nucleo.Code.Data.Entities;


namespace Nucleo.Demos.EntityFramework
{
	public class SampleQueriesModel
	{
		public IQueryable<Product> Products { get; set; }
	}

	public interface ISampleQueriesView : IView<SampleQueriesModel>
	{
		event EventHandler Refresh;
	}

	public class SampleQueriesPresenter : BasePresenter<ISampleQueriesView>
	{
		public SampleQueriesPresenter(ISampleQueriesView view)
			: base(view)
		{
			view.Refresh += new EventHandler(View_Refresh);
			view.Starting += new EventHandler(View_Starting);
		}

		void View_Refresh(object sender, EventArgs e)
		{
			LoadData();
		}

		void View_Starting(object sender, EventArgs e)
		{
			LoadData();
		}
  
		private void LoadData()
		{
			var context = new AdventureWorksObjectContext();
			var uow = new ObjectSetEntityUnitOfWork<Product>(context.Products);

			var result = uow.Queries().Query((os) => from p in os
													 where p.Color != null
													 orderby p.SellStartDate descending
													 select p);

			if (this.View.Model == null)
				this.View.Model = new SampleQueriesModel();
			this.View.Model.Products = result;
		}



	}

	[PresenterBinding(typeof(SampleQueriesPresenter))]
	public partial class SampleQueries : DemoViewPage<SampleQueriesModel>, ISampleQueriesView
	{
		public event EventHandler Refresh;



		public override string Description
		{
			get { return "This example provides a great overview of what querying using the unit of work looks like."; }
		}



		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.Model == null)
				return;

			if (this.Model.Products != null)
			{
				this.gvwProducts.DataSource = this.Model.Products;
				this.gvwProducts.DataBind();
			}
		}

		protected virtual void OnRefresh(EventArgs e)
		{
			if (Refresh != null)
				Refresh(this, e);
		}



		protected void gvwProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			this.OnRefresh(e);
		}
	}
}