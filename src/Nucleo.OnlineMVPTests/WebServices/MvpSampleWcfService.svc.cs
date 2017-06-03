using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

using Nucleo.Presentation;
using Nucleo.Web.Services;
using Nucleo.Views;
using Nucleo.Web.Views;
using Nucleo.EventArguments;



namespace Nucleo.WebServices
{
	public class MvpSampleWcfServicePresenter : BasePresenter<IMvpSampleWcfSWerviceView>
	{
		public MvpSampleWcfServicePresenter(IMvpSampleWcfSWerviceView view)
			: base(view)
		{
			view.Starting += View_Starting;
		}

		void  View_Starting(object sender, EventArgs e)
		{
			this.View.Model = new MvpSampleWcfServiceModel
			{
				Data = this.GetValues()
			};
		}

		public string[] GetValues()
		{
			return new string[] { "A", "B", "C", "D", "E" };
		}
	}

	public interface IMvpSampleWcfSWerviceView : IView<MvpSampleWcfServiceModel>
	{	
	}

	public class MvpSampleWcfServiceModel
	{
		public string[] Data { get; set; }
	}


	[ServiceContract(Namespace = "Nucleo.WebServices")]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[PresenterBinding("Nucleo.WebServices.MvpSampleWcfServicePresenter, Nucleo.OnlineMVPTests")]
	public class MvpSampleWcfService : ViewWcfService<MvpSampleWcfServiceModel>, IMvpSampleWcfSWerviceView
	{
		#region " Methods "

		[
		OperationContract,
		WebGet(ResponseFormat = WebMessageFormat.Json)
		]
		public string[] GetValues()
		{
			return this.Model.Data;
		}

		#endregion
	}
}
