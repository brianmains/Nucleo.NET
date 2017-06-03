using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Nucleo.Configuration;
using Nucleo.Web.Pages;


namespace Nucleo.Web.UserControls
{
	public abstract class UserControlBase : UserControl, IUserControl
	{
		#region " Properties "

		public abstract bool Enabled { get; set; }

		new public PageBase Page
		{
			get { return base.Page as PageBase; }
			set { base.Page = value; }
		}

		public override bool Visible
		{
			get { return base.Visible; }
			set { base.Visible = value; }
		}

		#endregion
	}
}