using System;
using Nucleo.Collections;


namespace Nucleo.Logs
{
	public class LogVerbosityTypeCollection : SimpleCollection<LogVerbosityType>
	{
		#region " Properties "

		public LogVerbosityType this[string name]
		{
			get
			{
				for (int index = 0, len = this.Count; index < len; index++)
				{
					if (string.Compare(name, this[index].Name, StringComparison.CurrentCultureIgnoreCase) == 0)
						return this[index];
				}

				return null;
			}
		}

		#endregion



		#region " Methods "

		public LogVerbosityType GetByEnum(Enum value)
		{
			return this[value.ToString()];
		}

		public LogVerbosityType GetHighest()
		{
			if (this.Count == 0)
				return null;
			if (this.Count == 1)
				return this[0];

			int currentIndex = 0;

			for (int index = 1, len = this.Count; index < len; index++)
			{
				if (this[currentIndex].Level < this[index].Level)
					currentIndex = index;
			}

			return this[currentIndex];
		}

		public LogVerbosityType GetLowest()
		{
			if (this.Count == 0)
				return null;
			if (this.Count == 1)
				return this[0];

			int currentIndex = 0;

			for (int index = 1, len = this.Count; index < len; index++)
			{
				if (this[currentIndex].Level > this[index].Level)
					currentIndex = index;
			}

			return this[currentIndex];
		}

		#endregion
	}
}
