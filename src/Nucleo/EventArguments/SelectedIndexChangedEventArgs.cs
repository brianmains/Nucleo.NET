using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.EventArguments
{
	public class SelectedIndexChangedEventArgs
	{
		private int _index;
		private object _row;



		#region " Properties "

		public int Index
		{
			get { return _index; }
		}

		public object Row
		{
			get { return _row; }
		}

		#endregion



		#region " Constructors "

		public SelectedIndexChangedEventArgs(int index, object row)
		{
			_index = index;
			_row = row;
		}

		#endregion



		#region " Methods "

		public T GetRowAs<T>()
		{
			try { return (T)_row; }
			catch { return (T)Convert.ChangeType(_row, typeof(T)); }
		}

		#endregion
	}


	public delegate void SelectedIndexChangedEventHandler(object sender, SelectedIndexChangedEventArgs e);
}
