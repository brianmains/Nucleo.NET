using System;
using System.Collections.Generic;
using System.Reflection;

using Nucleo.Collections;


namespace Nucleo.Reflection
{
	public class ReflectMethodList : BaseReflectMemberList
	{
		#region " Constructors "

		public ReflectMethodList(object target, bool isPrivate)
			: base(target, isPrivate) { }

		#endregion



		#region " Methods "

		private MethodInfo[] GetMethods()
		{
			return this.Target.GetType().GetMethods(this.GetFlags());
		}

		public ReflectMethodCollection WithAttribute(Type attributeType)
		{
			MethodInfo[] methods = this.GetMethods();
			ReflectMethodCollection outputList = new ReflectMethodCollection();

			foreach (MethodInfo method in methods)
			{
				if (method.GetCustomAttributes(attributeType, true).Length > 0)
					outputList.Add(new ReflectMethod(method.Name, base.Target, base.IsPrivate));
			}

			return outputList;
		}

		#endregion
	}
}
