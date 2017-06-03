using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.EventArguments
{
	public class DataCommandEventArgs<T>
	{
		private string _command;
		private T _data;



		#region " Properties "

		public string Command
		{
			get { return _command; }
			set { _command = value; }
		}

		public T Data
		{
			get { return _data; }
			set { _data = value; }
		}

		#endregion



		#region " Constructors "

		public DataCommandEventArgs(string command, T data)
		{
			_command = command;
			_data = data;
		}

		#endregion
	}



	public delegate void DataCommandEventHandler<T>(object sender, DataEventArgs<T> e);
}
