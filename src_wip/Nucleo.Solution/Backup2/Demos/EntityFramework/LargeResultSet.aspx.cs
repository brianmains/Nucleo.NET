using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventArguments;
using Nucleo.EventsManagement;
using Nucleo.EventsManagement.Listeners;
using Nucleo.Orm.Entities;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;

using Nucleo.Code.Data.Entities;


namespace Nucleo.Demos.EntityFramework
{
	public class LargeResultSetModel
	{
		public IQueryable<SalesOrderDetail> SalesOrderDetails { get; set; }
	}

	public interface ILargeResultSetView : IView<LargeResultSetModel>
	{
		event DataEventHandler<bool> Refresh;
	}

	public class LargeResultSetPresenter : BasePresenter<ILargeResultSetView>
	{
		public LargeResultSetPresenter(ILargeResultSetView view)
			: base(view)
		{
			view.Refresh += View_Refresh;
			view.Starting += new EventHandler(View_Starting);
		}

		void View_Refresh(object sender, DataEventArgs<bool> e)
		{
			LoadData(e.Data);
		}

		void View_Starting(object sender, EventArgs e)
		{
			LoadData(false);
		}

		private void LoadData(bool loadAll)
		{
			var context = new AdventureWorksObjectContext();
			var uow = new ObjectSetEntityUnitOfWork<SalesOrderDetail>(context.SalesOrderDetails);

			IQueryable<SalesOrderDetail> result = null;

			if (loadAll)
				result = uow.Queries().Query((os) => from s in os select s);
			else
				result = uow.Queries().Query((os) => (from s in os select s).Take(100));

			if (this.View.Model == null)
				this.View.Model = new LargeResultSetModel();
			this.View.Model.SalesOrderDetails = result;
		}
	}

	[PresenterBinding(typeof(LargeResultSetPresenter))]
	public partial class LargeResultSet : DemoViewPage<LargeResultSetModel>, ILargeResultSetView
	{
		public event DataEventHandler<bool> Refresh;



		public override string Description
		{
			get { return ""; }
		}



		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.Model == null)
				return;

			this.gvw.DataSource = this.Model.SalesOrderDetails;
			this.gvw.DataBind();
		}

		protected virtual void OnRefresh(DataEventArgs<bool> e)
		{
			if (Refresh != null)
				Refresh(this, e);
		}


		protected void btn_Click(object sender, EventArgs e)
		{
			this.gvw.PageIndex = 0;
			this.OnRefresh(new DataEventArgs<bool>(this.rbl.SelectedValue == "A"));
		}

		protected void gvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			this.gvw.PageIndex = e.NewPageIndex;
			this.OnRefresh(new DataEventArgs<bool>(this.rbl.SelectedValue == "A"));
		}
	}
}