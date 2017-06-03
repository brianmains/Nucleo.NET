using System;
using System.Web.UI.WebControls;



namespace Nucleo.Web.Inspectors
{
    public class PanelInspector : IContainerControlInspector
    {
        public bool IsForControl(Type controlType)
        {
			return (controlType.Equals(typeof(Panel)));
        }
    }
}
