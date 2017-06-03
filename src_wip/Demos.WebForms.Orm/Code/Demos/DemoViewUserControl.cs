using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nucleo.Demos
{
	public class DemoViewUserControl : Nucleo.Web.Views.BaseViewUserControl, IDemoUserControl
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (this.Page is DemoPage)
			{
				((DemoPage)this.Page).AddDemoControl(this);
			}
		}


		public IEnumerable<CodeSample> GetSamples()
		{
			return CodeSampleFactory.Get(this);
		}
	}
}