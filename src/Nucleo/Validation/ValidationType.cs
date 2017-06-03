using System;


namespace Nucleo.Validation
{
	public abstract class ValidationType
	{
		private byte _level = 0;
		private string _name = null;



		#region " Properties "

		public static EmptyValidationType Empty
		{
			get { return new EmptyValidationType(); }
		}

		public byte Level
		{
			get { return _level; }
		}

		public virtual bool IsEmpty
		{
			get { return false; }
		}

		public string Name
		{
			get { return _name; }
		}

		#endregion



		#region " Constructors "

		public ValidationType(string name, byte level)
		{
			_name = name;
			_level = level;
		}

		#endregion



		#region " Methods "



		#endregion
	}
}
