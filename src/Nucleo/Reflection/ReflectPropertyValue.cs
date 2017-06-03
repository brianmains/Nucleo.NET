using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Reflection
{
	public class ReflectPropertyValue
	{
		private string _name = null;
		private Type _propertyType = null;
		private object _value = null;



		#region " Properties "

		public string Name
		{
			get { return _name; }
		}

		public Type PropertyType
		{
			get { return _propertyType; }
		}

		public object Value
		{
			get { return _value; }
		}

		#endregion



		#region " Constructors "

		public ReflectPropertyValue(string name, Type propertyType, object value)
		{
			_name = name;
			_propertyType = propertyType;
			_value = value;
		}

		#endregion
	}
}
