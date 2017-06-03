using System;
using System.Windows.Forms;


namespace Nucleo.Windows
{
	public static class ControlUtility
	{
		/// <summary>
		/// Takes the original object, and if possible, converts the control to a windows forms equivalent.  If an object handler, the underlying value is unwrapped.  If a WPF element, the integration layer is used to perform the conversion.
		/// </summary>
		/// <param name="originalReference">A reference to convert.</param>
		/// <returns>An instance of a windows forms control, defined as System.Windows.Forms.Control class.</returns>
		public static Control GetWindowsControlReference(object originalReference)
		{
			object controlReference = originalReference;
			if (originalReference is System.Runtime.Remoting.ObjectHandle)
				controlReference = ((System.Runtime.Remoting.ObjectHandle)originalReference).Unwrap();

			if (originalReference is System.Windows.UIElement)
			{
				System.Windows.Forms.Integration.ElementHost host = new System.Windows.Forms.Integration.ElementHost();
				host.Child = (System.Windows.UIElement)originalReference;
				return host;
			}

			return (System.Windows.Forms.Control)originalReference;
		}
	}
}
