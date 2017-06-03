using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nucleo.State;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Tests.State
{
	public interface IFirstLookView : IView
	{
		string Output { get; set; }
	}

	public class FirstLookPresenter : BasePresenter<IFirstLookView>
	{
		public FirstLookPresenter(IFirstLookView view)
			: base(view)
		{
			view.Starting += new EventHandler(View_Starting);
			view.Initializing += new EventHandler(View_Initializing);
			view.Loading += new EventHandler(View_Loading);
			view.Loaded += new EventHandler(View_Loaded);
		}

		private void OutputMessages()
		{
			this.View.Output = "";
			this.View.Output += (this.CurrentContext.State.HasValue("Starting") ? "Starting" : "Not Starting") + "<br/>";
			this.View.Output += (this.CurrentContext.State.HasValue("Initializing") ? "Initializing" : "Not Initializing") + "<br/>";
			this.View.Output += (this.CurrentContext.State.HasValue("Loading") ? "Loading" : "Not Loading") + "<br/>";
			this.View.Output += (this.CurrentContext.State.HasValue("Loaded") ? "Loaded" : "Not Loaded") + "<br/>";
			this.View.Output += "Last Known State: " + this.CurrentContext.State.Get("State").Value.ToString() + "<br/>";
		}

		void View_Loaded(object sender, EventArgs e)
		{
			this.CurrentContext.State.Set(new StateValue { Key = "State", Value = "Loaded" });
			this.CurrentContext.State.Set(new StateValue { Key = "Loaded", Value = "Yes" });

			//After all events fired
			OutputMessages();
		}

		void View_Loading(object sender, EventArgs e)
		{
			this.CurrentContext.State.Set(new StateValue { Key = "State", Value = "Loading" });
			this.CurrentContext.State.Set(new StateValue { Key = "Loading", Value = "Yes" });
		}

		void View_Initializing(object sender, EventArgs e)
		{
			this.CurrentContext.State.Set(new StateValue { Key = "State", Value = "Initializing" });
			this.CurrentContext.State.Set(new StateValue { Key = "Initializing", Value = "Yes" });
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.CurrentContext.State.Set(new StateValue { Key = "State", Value = "Starting" });
			this.CurrentContext.State.Set(new StateValue { Key = "Starting", Value = "Yes" });
		}
	}

	[PresenterBinding(typeof(FirstLookPresenter))]
	public partial class FirstLook : BaseViewPage, IFirstLookView
	{
		public string Output
		{
			get { return this.lblCurrentStateOutput.Text; }
			set { this.lblCurrentStateOutput.Text = value; }
		}
	}
}