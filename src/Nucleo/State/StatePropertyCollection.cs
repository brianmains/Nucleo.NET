using System;
using Nucleo.Collections;

namespace Nucleo.State
{
	public class StatePropertyCollection : SimpleCollection<StateProperty>
	{
		#region " Properties "

		public StateProperty this[string name]
		{
			get
			{
				if (string.IsNullOrEmpty(name))
					throw new ArgumentNullException("name");

				for (int index = 0, len = this.Count; index < len; index++)
				{
					StateProperty property = this[index];

					if (string.Compare(name, property.Name, true) == 0)
						return property;
				}

				return null;
			}
		}

		#endregion
	}
}
