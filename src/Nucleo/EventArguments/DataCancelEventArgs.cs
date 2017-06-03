using System;


namespace Nucleo.EventArguments
{
	[CLSCompliant(true)]
	public class DataCancelEventArgs<T> : DataEventArgs<T>
	{
		private bool _cancel = false;



		#region " Properties "

		public bool Cancel
		{
			get { return _cancel; }
			set { _cancel = value; }
		}

		#endregion



		#region " Constructors "

		public DataCancelEventArgs(T data)
			: base(data) { }

		public DataCancelEventArgs(T data, bool cancel)
			: base(data) 
		{
			_cancel = cancel;
		}

		#endregion
	}

	[CLSCompliant(true)]
	public delegate void DataCancelEventHandler<T>(object sender, DataCancelEventArgs<T> e);
}
