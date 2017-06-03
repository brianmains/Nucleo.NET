using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;


namespace Nucleo.Demos
{
	public abstract class DemoUserControl : UserControl, IDemoUserControl
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