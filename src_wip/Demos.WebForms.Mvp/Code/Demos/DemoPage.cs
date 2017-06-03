using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;


namespace Nucleo.Demos
{
	public abstract class DemoPage : System.Web.UI.Page, IDemoPage
	{
		private List<IDemoUserControl> _userControls = new List<IDemoUserControl>();



		public abstract string Description
		{
			get;
		}



		internal void AddDemoControl(IDemoUserControl control)
		{
			_userControls.Add(control);
		}

		private IEnumerable<CodeSample> GetPageSamples()
		{
			return CodeSampleFactory.Get(this);
		}

		public virtual IEnumerable<CodeSample> GetSamples()
		{
			return this.GetPageSamples().Union(_userControls.SelectMany(i => i.GetSamples()));
		}
	}
}