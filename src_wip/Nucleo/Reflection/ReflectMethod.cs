using System;
using System.Reflection;

using Nucleo.Exceptions;


namespace Nucleo.Reflection
{
	public class ReflectMethod : BaseReflectMember
	{
		#region " Constructors "

		public ReflectMethod(string methodName, object target, bool isPrivate)
			: base(methodName, target, isPrivate) { }

		#endregion


		
		#region " Methods "

		/// <summary>
		/// Uses an action to supply bulk operational processing.
		/// </summary>
		/// <param name="action">The action to process.</param>
		public void Action(Action<ReflectMethod> action)
		{
			action(this);
		}

		public override MemberInfo GetMember()
		{
			return this.GetMethod(new object[] { }, new Type[] { });
		}

		private MethodInfo GetMethod(object[] parms, Type[] parmTypes)
		{
			MethodInfo method = base.Target.GetType().GetMethod(base.Name, base.GetFlags(), null, parmTypes, null);
			if (method == null)
				throw new NotFoundException("The method " + base.Name + " could not be found.");

			return method;
		}

		public object Invoke()
		{
			return Invoke(new object[] { }, new Type[] { });
		}

		public T Invoke<T>()
		{
			object result = Invoke();
			return (result != null) ? (T)result : default(T);
		}

		public object Invoke(params object[] parms)
		{
			if (parms.Length == 0)
				return this.GetMethod(parms, new Type[] { }).Invoke(base.Target, parms);

			Type[] parmTypes = new Type[parms.Length];
			for (int index = 0, len = parms.Length; index < len; index++)
			{
				if (parms[index] != null)
					parmTypes[index] = parms[index].GetType();
				else
					throw new InvalidOperationException("This overload cannot be used with null values, as type cannot be inferred.  Please use the override with the array of types.");
			}

			return this.GetMethod(parms, parmTypes).Invoke(base.Target, parms);
		}

		public T Invoke<T>(params object[] parms)
		{
			object result = Invoke(parms);
			return (result != null) ? (T)result : default(T);
		}

		public object Invoke(object[] parms, Type[] parmTypes)
		{
			if (parms.Length != parmTypes.Length)
				throw new MismatchException("The parameter array length does not match the type length.");

			return this.GetMethod(parms, parmTypes).Invoke(base.Target, parms);
		}

		public T Invoke<T>(object[] parms, Type[] parmTypes)
		{
			object result = Invoke(parms, parmTypes);
			return (result != null) ? (T)result : default(T);
		}

		public override string ToString()
		{
			return this.Target.GetType().Name + "." + base.Name;
		}

		#endregion
	}
}
