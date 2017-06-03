using System;
using Nucleo.Collections;


namespace Nucleo.DynamicExecution
{
	public class DynamicExecutionPathMethodInfoCollection : SimpleCollection<DynamicExecutionPathMethodInfo>
	{
		#region " Properties "

		public DynamicExecutionPathMethodInfo this[string friendlyName]
		{
			get
			{
				foreach (DynamicExecutionPathMethodInfo info in this)
				{
					if (string.Compare(info.MethodFriendlyName, friendlyName, true) == 0)
						return info;
				}

				return null;
			}
		}

		#endregion



		#region " Methods "

		public DynamicExecutionPathMethodInfo[] ToArray(string[] methodFriendlyNames)
		{
			CollectionBase<DynamicExecutionPathMethodInfo> list = new CollectionBase<DynamicExecutionPathMethodInfo>();

			foreach (string methodFriendlyName in methodFriendlyNames)
				list.Add(this[methodFriendlyName]);

			return list.ToArray();
		}

		#endregion
	}
}
