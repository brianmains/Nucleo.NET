using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Logs
{
	public class LogVerbosityType
	{
		private string _name = null;
		private byte _level = 0;



		#region " Properties "

		public byte Level
		{
			get { return _level; }
		}

		public string Name
		{
			get { return _name; }
		}

		#endregion



		#region " Constructors "

		public LogVerbosityType(string name, byte level)
		{
			_name = name;
			_level = level;
		}

		#endregion



		#region " Methods "

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is LogVerbosityType))
				return false;

			LogVerbosityType type = (LogVerbosityType)obj;
			return (this.Level == type.Level);
		}

		public override int GetHashCode()
		{
			return this.Level.GetHashCode();
		}

		#endregion
	}
}
