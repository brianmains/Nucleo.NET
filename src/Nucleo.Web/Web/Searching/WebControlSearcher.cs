using System;
using System.Web;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web.Searching
{
	public class WebControlSearcher : IControlSearcher
	{
		#region IControlSearcher Members

		public Control FindControl(Control baseControl, string id)
		{
			return baseControl.FindControl(id);
		}

		public Control FindControl(Control baseControl, string id, ControlSearcherDirection direction)
		{
			Control control = baseControl.FindControl(id);
			if (control != null)
				return control;

			if (direction == ControlSearcherDirection.Up)
			{
				//If not found, search up
				while (control == null)
				{
					baseControl = baseControl.NamingContainer ?? baseControl.Parent;
					if (baseControl == null)
						return null;
					control = baseControl.FindControl(id);

					if (control != null)
						return control;
				}
			}

			return null;
		}

		public T[] FindControls<T>(Control baseControl) 
			where T : Control
		{
			List<T> list = new List<T>();

			foreach (Control control in baseControl.Controls)
			{
				if (control is T)
					list.Add((T)control);
			}

			return list.ToArray();
		}

		public T[] FindControls<T>(Control baseControl, ControlSearcherDirection direction)
			where T : Control
		{
			List<T> list = new List<T>();

			Control parentControl = baseControl;

			if (direction == ControlSearcherDirection.Up)
			{
				while (parentControl != null)
				{
					foreach (Control control in parentControl.Controls)
					{
						if (control is T)
							list.Add((T)control);
					}

					parentControl = parentControl.NamingContainer ?? parentControl.Parent;
				}
			}

			return list.ToArray();
		}

		public T FindParent<T>(Control baseControl)
			where T: Control
		{
			Control parentControl = baseControl.NamingContainer ?? baseControl.Parent;

			while (parentControl != null)
			{
				if (parentControl is T)
					return parentControl as T;

				parentControl = parentControl.NamingContainer ?? parentControl.Parent;
			}

			return default(T);
		}

		public T[] FindParents<T>(Control baseControl)
			where T : Control
		{
			List<T> list = new List<T>();
			Control parentControl = baseControl.NamingContainer ?? baseControl.Parent;

			while (parentControl != null)
			{
				if (parentControl is T)
					list.Add(parentControl as T);

				parentControl = parentControl.NamingContainer ?? parentControl.Parent;
			}

			return list.ToArray();
		}

		#endregion
	}
}
