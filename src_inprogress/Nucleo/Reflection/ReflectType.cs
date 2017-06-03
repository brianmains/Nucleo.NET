using System;
using System.Collections.Generic;
using System.Reflection;


namespace Nucleo.Reflection
{
	public class ReflectType : BaseReflectMember
	{
		#region " Constructors "

		public ReflectType(string name, object target, bool isPrivate)
			: base(name, target, isPrivate) { }

		#endregion



		#region " Methods "

		public override MemberInfo GetMember()
		{
			return this.Target.GetType();
		}

		public A[] IterateAttributesThoughTypeInheritance<A>()
			where A: Attribute
		{
			List<A> list = new List<A>();
			Type type = base.Target.GetType();

			while (type != null && type != typeof(object))
			{
				object[] attributes = type.GetCustomAttributes(typeof(A), false);
				for (int i = attributes.Length - 1; i >= 0; i--)
				{
					list.Insert(0, (A)attributes[i]);
				}

				type = type.BaseType;
			}

			return list.ToArray();
		}

		#endregion
	}
}
