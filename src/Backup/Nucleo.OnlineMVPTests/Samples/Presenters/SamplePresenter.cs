using System;
using System.Collections.Generic;
using System.Linq;
using Nucleo.Presentation;

using Nucleo.Samples.Views;


namespace Nucleo.Samples.Presenters
{
	public class SamplePresenter : BasePresenter<ISampleView>
	{
		public SamplePresenter(ISampleView view)
			: base(view)
		{
			view.Login += new EventHandler(view_Login);
		}

		void view_Login(object sender, EventArgs e)
		{
			if (this.View.UserName == "XYZ" && this.View.Password == "ABC")
			{
				//then OK
			}
			else
			{
				//flagg
			}
		}


	}

}