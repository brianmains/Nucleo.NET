using System;


namespace Nucleo.Web.UserControls
{
	public interface IUserControl
	{
		bool Enabled { get;set; }
		bool Visible { get;set; }
	}
}
