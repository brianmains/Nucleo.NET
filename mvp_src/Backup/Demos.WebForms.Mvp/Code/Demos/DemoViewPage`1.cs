﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nucleo.Demos
{
	public abstract class DemoViewPage<TModel> : Nucleo.Web.Views.BaseViewPage<TModel>, IDemoPage
		where TModel: class, new()
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