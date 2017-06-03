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
	public class GenericObjectSetModel
	{
		public IQueryable Products { get; set; }
	}

	public interface IGenericObjectSetView : IView<GenericObjectSetModel>
	{
		event EventHandler Refresh;
	}

	public class GenericObjectSetPresenter : BasePresenter<IGenericObjectSetView>
	{
		public GenericObjectSetPresenter(IGenericObjectSetView view)
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
			//productSet = ObjectEntitySet
			var productSet = context.CreateObjectSet(typeof(Product));

			//Can add objects as an object type, instead of knowing the underlying type
			//productSet.AddObject();
			///Can delete objects as an object type, instead of knowing the underlying type
			//productSet.DeleteObject();

			//Queries can be done by an expression

			var result = default(IQueryable);

			if (this.View.Model == null)
				this.View.Model = new GenericObjectSetModel();
			this.View.Model.Products = result;
		}



	}

	[PresenterBinding(typeof(GenericObjectSetPresenter))]
	public partial class GenericObjectSet : DemoViewPage<GenericObjectSetModel>, IGenericObjectSetView
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