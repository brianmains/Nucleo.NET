using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.Controls;
using Nucleo.ObjectModel;


namespace Nucleo.Web.Mvc.Controls
{
	public class CheckImageOptions : AttributedObject
	{
		#region " Properties "

		public CheckImage EmptyImage
		{
			get { return this.GetValue<CheckImage>("EmptyImage"); }
			set { this.AddOrUpdateValue("EmptyImage", value); }
		}

		public CheckImage FalseImage
		{
			get { return this.GetValue<CheckImage>("FalseImage"); }
			set { this.AddOrUpdateValue("FalseImage", value); }
		}

		public CheckImage TrueImage
		{
			get { return this.GetValue<CheckImage>("TrueImage"); }
			set { this.AddOrUpdateValue("TrueImage", value); }
		}

		#endregion
	}
}
