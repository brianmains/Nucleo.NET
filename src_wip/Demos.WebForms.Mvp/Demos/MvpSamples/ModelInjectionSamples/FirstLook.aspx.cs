using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Models;
using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.ModelInjectionSamples
{
	public class StateCodeAttribute : Attribute, IModelInjection { }

	public class StateCodeDataLoader : IModelDataLoader
	{
		public object GetModelData(ModelMemberMetadata metadata)
		{
			return new string[] { "PA", "NY", "MD" };
		}

		public bool SupportsInjection(IModelInjection injection)
		{
			return injection is StateCodeAttribute;
		}
	}

	public class FirstLookModel
	{
		[StateCode]
		public string[] States { get; set; }
	}

	public class FirstLookPresenter : BasePresenter<IFirstLookView>
	{
		public FirstLookPresenter(IFirstLookView view)
			: base(view)
		{
			this.CurrentContext.ModelInjection.RegisterBinding(new StateCodeDataLoader());
			view.Starting += new EventHandler(View_Starting);
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Model = new FirstLookModel();
			this.CurrentContext.ModelInjection.LoadInitialModelData(this.View.Model);
		}
	}

	public interface IFirstLookView : IView<FirstLookModel>
	{

	}

	[PresenterBinding(typeof(FirstLookPresenter))]
	public partial class FirstLook : BaseViewPage<FirstLookModel>, IFirstLookView
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);


		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.Model != null)
			{
				foreach (var state in this.Model.States)
					this.States.Items.Add(state);
			}
		}
	}
}