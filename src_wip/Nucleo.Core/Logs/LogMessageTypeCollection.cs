using System;
using Nucleo.Collections;


namespace Nucleo.Logs
{
	public class LogMessageTypeCollection : SimpleCollection<LogMessageType>
	{
		#region " Properties "

		public LogMessageType this[string name]
		{
			get
			{
				for (int index = 0, len = this.Count; index < len; index++)
				{
					if (string.Compare(this[index].Name, name, StringComparison.OrdinalIgnoreCase) == 0)
						return this[index];
				}

				return null;
			}
		}

		#endregion



		#region " Methods "

		public LogMessageType GetByEnum(Enum value)
		{
			return this[value.ToString()];
		}

		public LogMessageType GetHighest()
		{
			if (this.Count == 0)
				return null;
			if (this.Count == 1)
				return this[0];

			int currentIndex = 0;

			for (int index = 1, len = this.Count; index < len; index++)
			{
				if (this[currentIndex].Value < this[index].Value)
					currentIndex = index;
			}

			return this[currentIndex];
		}

		public LogMessageType GetLowest()
		{
			if (this.Count == 0)
				return null;
			if (this.Count == 1)
				return this[0];

			int currentIndex = 0;

			for (int index = 1, len = this.Count; index < len; index++)
			{
				if (this[currentIndex].Value > this[index].Value)
					currentIndex = index;
			}

			return this[currentIndex];
		}

		#endregion
	}
}
