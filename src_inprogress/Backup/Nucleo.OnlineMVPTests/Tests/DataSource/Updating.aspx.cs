using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Tests.DataSource
{
	public interface IUpdatingView : IView { }

	public class UpdatingPresenter: BasePresenter<IUpdatingView>
	{
		public UpdatingPresenter(IUpdatingView view)
			: base(view) { }
	}

	[PresenterBinding(typeof(UpdatingPresenter))]
	public partial class Updating : BaseViewPage, IUpdatingView 
	{
		public void AddNew(TestClass cl)
		{
			var results = this.GetOrResetDefaultData();
			results.Add(cl);

			Session["UpdatingDataSourceTestData"] = results;
		}

		public void Delete(TestClass cl)
		{
			var results = this.GetOrResetDefaultData();

			var result = results.FirstOrDefault(i => i.Key == cl.Key);
			if (result != null)
				results.Remove(result);

			Session["UpdatingDataSourceTestData"] = results;
		}

		public IEnumerable<TestClass> GetAll()
		{
			return this.GetOrResetDefaultData();
		}

		private List<TestClass> GetOrResetDefaultData()
		{
			var results = Session["UpdatingDataSourceTestData"];
			if (results != null)
				return (List<TestClass>)results;

			var data = new List<TestClass>
				{
					new TestClass { Key = 1, Name = "PA" },
					new TestClass { Key = 2, Name = "MD" },
					new TestClass { Key = 3, Name = "DC" },
					new TestClass { Key = 4, Name = "VA" }
				};
			Session["UpdatingDataSourceTestData"] = data;

			return data;
		}

		public void Update(TestClass cl)
		{
			var results = this.GetOrResetDefaultData();
			var result = results.FirstOrDefault(i => i.Key == cl.Key);

			if (result != null)
				results.Remove(result);

			results.Add(cl);

			Session["UpdatingDataSourceTestData"] = results;
		}
	}
}