using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Nucleo.Presentation;
using Nucleo.Web.Services;
using Nucleo.Views;
using Nucleo.Web.Views;
using Nucleo.EventArguments;


namespace Nucleo.WebServices
{
	public class MvpSampleServicePresenter : BasePresenter<IMvpSampleServiceView>
	{
		public MvpSampleServicePresenter(IMvpSampleServiceView view)
			: base(view)
		{
			view.NeedData += new DataEventHandler<string[]>(View_NeedData);
		}

		void View_NeedData(object sender, DataEventArgs<string[]> e)
		{
			e.Data = this.GetValues();
		}

		public string[] GetValues()
		{
			return new string[] { "A", "B", "C", "D", "E" };
		}
	}

	public interface IMvpSampleServiceView : IView
	{
		event DataEventHandler<string[]> NeedData;		
	}


	/// <summary>
	/// Summary description for MvpSampleService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService]
	[PresenterBinding(typeof(MvpSampleServicePresenter))]
	public class MvpSampleService : ViewWebService, IMvpSampleServiceView
	{
		#region " Events "

		public event DataEventHandler<string[]> NeedData;

		#endregion



		#region " Constructors "

		public MvpSampleService() { }

		#endregion



		#region " Methods "

		[WebMethod]
		public string[] GetValues()
		{
			var args = new DataEventArgs<string[]>(null);

			if (NeedData != null)
				NeedData(this, args);

			return args.Data;
		}

		#endregion
	}
}
