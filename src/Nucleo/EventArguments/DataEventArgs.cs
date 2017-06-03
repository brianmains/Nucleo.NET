using System;


namespace Nucleo.EventArguments
{
	[CLSCompliant(true)]
	public class DataEventArgs<T> : EventArgs
	{
		private T _data;



		#region " Properties "

		public T Data
		{
			get { return _data; }
			set { _data = value; }
		}

		#endregion



		#region " Constructors "

		public DataEventArgs(T data)
		{
			_data = data;
		}

		#endregion
	}

	[CLSCompliant(true)]
	public delegate void DataEventHandler<T>(object sender, DataEventArgs<T> e);
}
