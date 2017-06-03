using System.Web.UI;

namespace Nucleo.Web.Mappings
{
	public abstract class ControlManager
	{
		/// <summary>
		/// Gets the underlying core value from the control.
		/// </summary>
		/// <param name="control">The control to evaluate.</param>
		/// <returns>The object stored in the underlying value.</returns>
		public abstract object GetValue(Control control);
		public abstract bool IsCorrectControl(Control control);
		public abstract void SetValue(Control control, object value);
	}
}
