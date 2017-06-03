using System;


namespace Nucleo.Windows.ApplicationListeners
{
	public class WindowsUIControlConverter : UIControlConverter
	{
		public override object GetFinalControlReference(object controlReference)
		{
			return controlReference;
		}

		protected internal override bool IsSupportedType(object controlReference)
		{
			return (controlReference is System.Windows.Forms.Control);
		}
	}
}
