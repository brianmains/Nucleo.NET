using System;


namespace Nucleo.Logs
{
	public class LogMessageType
	{
		private string _name = null;
		private int _value = 0;



		#region " Properties "

		public string Name
		{
			get { return _name; }
		}

		public int Value
		{
			get { return _value; }
		}

		#endregion



		#region " Constructors "

		public LogMessageType(string name, int value)
		{
			_name = name;
			_value = value;
		}

		#endregion



		#region " Methods "

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is LogMessageType))
				return false;

			LogMessageType type = (LogMessageType)obj;
			return (this.Value == type.Value);
		}

		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		#endregion
	}
}
