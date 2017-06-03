using System;
using Nucleo.Collections;


namespace Nucleo.Logs
{
	public class LogManagerCollection : SimpleCollection<ILogManager>
	{
		public override void Add(ILogManager item)
		{
			base.Add(item);
		}

		public override void Remove(ILogManager item)
		{
			base.Remove(item);
		}
	}
}
