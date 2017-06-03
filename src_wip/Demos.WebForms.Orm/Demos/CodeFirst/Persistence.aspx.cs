using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventArguments;
using Nucleo.EventsManagement;
using Nucleo.EventsManagement.Listeners;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;

using Nucleo.Code.Data.CodeFirst;
using Nucleo.Orm.Entities;


namespace Nucleo.Demos.CodeFirst
{
	public class PersistenceModel
	{
		public IQueryable<Culture> Cultures { get; set; }

		public Culture SelectedCulture { get; set; }
	}

	public interface IPersistenceView : IView<PersistenceModel>
	{
		event EventHandler Cancelled;

		event DictionaryEventHandler Saved;

		event DataEventHandler<string> Selected;

		event DataEventHandler<string> Deleted;
	}

	public class PersistencePresenter : BasePresenter<IPersistenceView>
	{
		public PersistencePresenter(IPersistenceView view)
			: base(view)
		{
			view.Starting += View_Starting;
			view.Cancelled += View_Cancelled;
			view.Saved += View_Saved;
			view.Selected += View_Selected;
			view.Deleted += View_Deleted;
		}



		private DbSetEntityUnitOfWork<Culture> GetUnitOfWork()
		{
			var ctx = DbContextHelper.Create<AdventureWorksDbContext>("AdventureWorksObjectContext", true);
			return new DbSetEntityUnitOfWork<Culture>(ctx, ctx.Cultures);
		}

		private void LoadData()
		{
			var uow = GetUnitOfWork();

			if (this.View.Model == null)
				this.View.Model = new PersistenceModel();

			this.View.Model.Cultures = uow.Queries().Query((os) => os);
		}



		void View_Starting(object sender, EventArgs e)
		{
			this.LoadData();
		}

		void View_Deleted(object sender, DataEventArgs<string> e)
		{
			var uow = this.GetUnitOfWork();
			var entity = uow.Queries().Query((os) => os.Where(i => i.CultureID == e.Data)).FirstOrDefault();

			uow.QueueDelete(entity);
			uow.SaveChanges();

			this.LoadData();
		}

		void View_Selected(object sender, DataEventArgs<string> e)
		{
			var uow = this.GetUnitOfWork();
			var entity = uow.Queries().Query((os) => os.Where(i => i.CultureID == e.Data)).FirstOrDefault();

			if (this.View.Model == null)
				this.View.Model = new PersistenceModel();
			this.View.Model.SelectedCulture = entity;
		}

		void View_Saved(object sender, DictionaryEventArgs e)
		{
			string id = e.Get("ID", "");
			string name = e.Get("Name", "");
			DateTime modDate = e.Get("Date", DateTime.Now);

			var uow = this.GetUnitOfWork();
			var entity = uow.Queries().Query((os) => os.Where(i => i.CultureID == id)).FirstOrDefault();
			bool added = (entity == null);

			if (added)
				entity = new Culture { CultureID = id };

			entity.Name = name;
			entity.ModifiedDate = modDate;

			if (added)
				uow.QueueInsert(entity);
			else
				uow.QueueUpdate(entity);

			uow.SaveChanges();

			this.LoadData();
		}

		void View_Cancelled(object sender, EventArgs e)
		{
			this.LoadData();
		}



	}

	[PresenterBinding(typeof(PersistencePresenter))]
	public partial class Persistence : DemoViewPage<PersistenceModel>, IPersistenceView
	{
		public event EventHandler Cancelled;

		public event DictionaryEventHandler Saved;

		public event DataEventHandler<string> Selected;

		public event DataEventHandler<string> Deleted;



		public override string Description
		{
			get { return "This is an overview of how objects can be persisted to the database.  Using the unit of work, objects are queued for insertion, modification, or deletion.  Upong saving changes, the objects are commited to the database."; }
		}



		private void ClearForm()
		{
			this.CultureID.Text = string.Empty;
			this.Name.Text = string.Empty;
			this.ModifiedDate.Text = string.Empty;
		}

		protected virtual void OnCancelled(EventArgs e)
		{
			if (Cancelled != null)
				Cancelled(this, e);
		}

		protected virtual void OnDeleted(DataEventArgs<string> e)
		{
			if (Deleted != null)
				Deleted(this, e);
		}

		protected virtual void OnSaved(DictionaryEventArgs e)
		{
			if (Saved != null)
				Saved(this, e);
		}

		protected virtual void OnSelected(DataEventArgs<string> e)
		{
			if (Selected != null)
				Selected(this, e);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.Model == null)
				return;

			if (this.Model.SelectedCulture != null)
			{
				this.CultureID.Text = this.Model.SelectedCulture.CultureID;
				this.Name.Text = this.Model.SelectedCulture.Name;
				this.ModifiedDate.Text = this.Model.SelectedCulture.ModifiedDate.ToShortDateString();
			}

			if (this.Model.Cultures != null)
			{
				this.gvwCultures.DataSource = this.Model.Cultures;
				this.gvwCultures.DataBind();
			}
		}


		public void btnCancel_Click(object sender, EventArgs e)
		{
			this.OnCancelled(e);

			ClearForm();
		}

		public void btnSave_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			var args = new DictionaryEventArgs();
			args.Add("ID", this.CultureID.Text);
			args.Add("Name", this.Name.Text);
			args.Add("Date", DateTime.Parse(this.ModifiedDate.Text));

			this.OnSaved(args);

			ClearForm();
		}

		protected void gvwCultures_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			var key = ((GridView)sender).DataKeys[e.RowIndex].Value.ToString();
			this.OnDeleted(new DataEventArgs<string>(key));

			ClearForm();
		}

		protected void gvwCultures_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
		{
			var key = ((GridView)sender).DataKeys[e.NewSelectedIndex].Value.ToString();
			this.OnSelected(new DataEventArgs<string>(key));
		}
	}
}