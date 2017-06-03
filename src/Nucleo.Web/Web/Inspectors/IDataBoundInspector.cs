using System;
using System.Web.UI;


namespace Nucleo.Web.Inspectors
{
	public interface IDataBoundInspector
	{
		void BindValues(Control control, object data);
	}
}
