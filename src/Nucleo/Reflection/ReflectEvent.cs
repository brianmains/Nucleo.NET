using System;
using System.Reflection;


namespace Nucleo.Reflection
{
	public class ReflectEvent : BaseReflectMember
	{
		#region " Constructors "

		public ReflectEvent(string eventName, object target, bool isPrivate)
			: base(eventName, target, isPrivate) { }
		
		#endregion



		#region " Methods "

		public void AddHandler(Delegate handler)
		{
			this.GetEvent().AddEventHandler(base.Target, handler);
		}

		public void Fire()
		{
			this.Fire(new object[] { });
		}

		public void Fire(params object[] parms)
		{
			this.GetEvent().GetRaiseMethod().Invoke(base.Target, parms);
		}

		private EventInfo GetEvent()
		{
			EventInfo evt = this.Target.GetType().GetEvent(base.Name, this.GetFlags());
			if (evt == null)
				throw new NullReferenceException(string.Format("The event '{0}' could not be found.", base.Name));

			return evt;
		}

		public override MemberInfo GetMember()
		{
			return this.GetEvent();
		}

		public void RemoveHandler(Delegate handler)
		{
			this.GetEvent().RemoveEventHandler(base.Target, handler);
		}

		public override string ToString()
		{
			return this.Target.GetType().Name + "." + base.Name;
		}

		#endregion
	}
}
