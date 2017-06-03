using System;
using System.Collections.Generic;
using System.Reflection;


namespace Nucleo.Reflection
{
	public class ReflectEventList : BaseReflectMemberList
	{
		#region " Constructors "

		public ReflectEventList(object target, bool isPrivate)
			: base(target, isPrivate) { }

		#endregion



		#region " Methods "

		private EventInfo[] GetEvents()
		{
			return this.Target.GetType().GetEvents(this.GetFlags());
		}

		public IEnumerable<ReflectEvent> WithAttribute(Type attributeType)
		{
			EventInfo[] events = this.GetEvents();
			List<ReflectEvent> outputList = new List<ReflectEvent>();

			foreach (EventInfo eventInfo in events)
			{
				if (eventInfo.GetCustomAttributes(attributeType, true).Length > 0)
					outputList.Add(new ReflectEvent(eventInfo.Name, base.Target, base.IsPrivate));
			}

			return outputList;
		}

		#endregion
	}
}
