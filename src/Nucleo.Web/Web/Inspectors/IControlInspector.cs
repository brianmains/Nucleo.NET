using System;
using System.Web.UI;


namespace Nucleo.Web.Inspectors
{
	public interface IControlInspector
	{
		#region " Methods "

		bool IsForControl(Type controlType);

		#endregion
	}
}
