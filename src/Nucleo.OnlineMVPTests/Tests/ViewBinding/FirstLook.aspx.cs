using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Tests.ViewBinding
{
	public class FirstModel
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string State { get; set; }

		public IEnumerable StateReferenceData { get; set; }
	}

	public class ViewBindingModel
	{
		public FirstModel FirstModelProperty { get; set; }
	}

	public interface IViewBindingView : IView<ViewBindingModel>
	{

	}

	public class ViewBindingPresenter : BasePresenter<IViewBindingView>
	{
		public ViewBindingPresenter(IViewBindingView view)
			: base(view) 
		{
			view.Starting += View_Starting;
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Model = new ViewBindingModel
			{
				FirstModelProperty = new FirstModel
				{
					FirstName = "First",
					LastName = "Last",
					State = "PA",
					StateReferenceData = new[]
					{
						new { Text = "Maryland", Value = "MD" },
						new { Text = "New York", Value = "NY" },
						new { Text = "Pennsyvlania", Value = "PA" }
					}
				}
			};
		}
	}

	[PresenterBinding(typeof(ViewBindingPresenter))]
	public partial class FirstLook : BaseViewPage<ViewBindingModel>, IViewBindingView
	{
		
	}
}