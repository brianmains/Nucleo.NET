using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Tests.PresenterCreation
{
	//Presenter defined in TempPresenterCreator.


	public partial class FirstLook : BaseViewPage
	{
		protected override IPresenter CreatePresenter()
		{
			//In reality, the presenter manager uses this class to create the presenters,
			//rather than doing this here.  But in reality, behind the scenes, this is
			//how the process works; the presenter creator (stored in the config file)
			//is instantiated and used to create the presenters.
			//This makes it easy to use a DI container or some other technique to instantiate presenter objects.
			TempPresenterCreator creator = new TempPresenterCreator();
			return creator.Create(null, this);
		}
	}
}