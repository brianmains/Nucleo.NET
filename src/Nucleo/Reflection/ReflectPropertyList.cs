using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Reflection
{
	public class ReflectPropertyList : BaseReflectMemberList
	{
		#region " Constructors "

		public ReflectPropertyList(object target, bool isPrivate)
			: base(target, isPrivate) { }

		#endregion



		#region " Methods "

		public ReflectPropertyValueCollection GetAllValues()
		{
			ReflectPropertyValueCollection list = new ReflectPropertyValueCollection();
			PropertyInfo[] properties = this.GetProperties();

			foreach (PropertyInfo property in properties)
				list.Add(new ReflectPropertyValue(property.Name, property.PropertyType, 
					property.GetValue(base.Target, null)));

			return list;
		}

		private PropertyInfo[] GetProperties()
		{
			return Target.GetType().GetProperties(this.GetFlags());
		}

		public ReflectPropertyCollection WithAttribute(Type attributeType)
		{
			PropertyInfo[] properties = this.GetProperties();
			ReflectPropertyCollection outputList = new ReflectPropertyCollection();

			foreach (PropertyInfo property in properties)
			{
				if (property.GetCustomAttributes(attributeType, true).Length > 0)
					outputList.Add(new ReflectProperty(property.Name, base.Target, base.IsPrivate));
			}

			return outputList;
		}

		#endregion
	}
}
