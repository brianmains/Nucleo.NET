using System;
using System.Runtime.Remoting;


namespace Nucleo.Windows.ApplicationListeners
{
	public class ObjectHandleToWindowsUIControlConverter : UIControlConverter
	{
		public override object GetFinalControlReference(object controlReference)
		{
			ObjectHandle handle = controlReference as ObjectHandle;
			return handle.Unwrap();
		}

		protected internal override bool IsSupportedType(object controlReference)
		{
			ObjectHandle handle = controlReference as ObjectHandle;
			if (handle == null)
				return false;

			return (handle.Unwrap() is System.Windows.Forms.Control);
		}
	}
}
