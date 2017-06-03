using System;
using System.Web.UI;

using Nucleo.Collections;


namespace Nucleo.Web.Repeating
{
	public class LayoutItem
	{
		private SimpleCollection<Control> _controls = null;



		#region " Properties "

		public SimpleCollection<Control> Controls
		{
			get
			{
				if (_controls == null)
					_controls = new SimpleCollection<Control>();
				return _controls;
			}
		}

		#endregion
	}
}
