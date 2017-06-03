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


namespace Nucleo.Tests.ModelBinding
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

	public class BindingFirstLookModel
	{
		[StateCode]
		public string[] States { get; set; }
	}

	public class BindingFirstLookPresenter : BasePresenter<IBindingFirstLookView>
	{
		public BindingFirstLookPresenter(IBindingFirstLookView view)
			: base(view) 
		{
			this.CurrentContext.ModelInjection.RegisterBinding(new StateCodeDataLoader());
			view.Starting += new EventHandler(View_Starting);
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Model = new BindingFirstLookModel();
			this.CurrentContext.ModelInjection.LoadInitialModelData(this.View.Model);
		}
	}

	public interface IBindingFirstLookView : IView<BindingFirstLookModel>
	{

	}

	[PresenterBinding(typeof(BindingFirstLookPresenter))]
	public partial class BindingFirstLook : BaseViewPage<BindingFirstLookModel>, IBindingFirstLookView
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