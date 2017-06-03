using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventArguments;
using Nucleo.Presentation;
using Nucleo.Presentation.Context;
using Nucleo.Core;
using Nucleo.Core.Options;
using Nucleo.Views;
using Nucleo.State;
using Nucleo.Web.State;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.StateSamples
{
	public interface ILoginSampleView : IView
	{
		event DictionaryEventHandler Login;
	}

	public class LoginSamplePresenter : BasePresenter<ILoginSampleView>
	{
		public LoginSamplePresenter(ILoginSampleView view)
			: base(view)
		{
			view.Login += View_Login;
		}

		void View_Login(object sender, DictionaryEventArgs e)
		{
			var user = e.Get<string>("UserName", null);

			if (user == "locked")
				this.CurrentContext.State.Set(new StateValue { Key = "Locked", Value = true });
			else if (user == "change")
				this.CurrentContext.State.Set(new StateValue { Key = "Change", Value = true });
		}

		protected override PresenterContext CreatePresenterContext()
		{
			var context = base.CreatePresenterContext();
			context.State = new WebCurrentExecutionState();

			return context;
		}
	}

	[PresenterBinding(typeof(LoginSamplePresenter))]
	public partial class LoginSample : DemoViewPage, ILoginSampleView
	{
		public event DictionaryEventHandler Login;



		public override string Description
		{
			get { return "An overview of logging into the application.  This sample illustrates how you can use the state feature to track the various states of login, so that your presenter and/or view can react to the changes in state."; }
		}


		protected virtual void OnLogin(DictionaryEventArgs e)
		{
			if (Login != null)
				Login(this, e);
		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			var args = new DictionaryEventArgs();
			args.Add("UserName", this.txtUserID.Text);
			args.Add("Password", this.txtPassword.Text);

			this.OnLogin(args);
		}
	}
}