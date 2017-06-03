using System;
using System.Reflection;


namespace Nucleo.Reflection
{
	public class ReflectDefinition
	{
		private bool _isPrivate = false;
		private object _target = null;



		#region " Properties "

		public ReflectEvent Event(string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			return new ReflectEvent(name, _target, _isPrivate);
		}

		public ReflectEventList Events()
		{
			return new ReflectEventList(_target, _isPrivate);
		}

		public ReflectMethod Method(string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			return new ReflectMethod(name, _target, _isPrivate);
		}

		public ReflectMethodList Methods()
		{
			return new ReflectMethodList(_target, _isPrivate);
		}

		public ReflectPropertyList Properties()
		{
			return new ReflectPropertyList(_target, _isPrivate);
		}

		public ReflectProperty Property(string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			return new ReflectProperty(name, _target, _isPrivate);
		}

		public ReflectType Type()
		{
			return new ReflectType(_target.GetType().Name, _target, _isPrivate);
		}

		#endregion



		#region " Constructors "

		public ReflectDefinition(object target, bool isPrivate)
		{
			_target = target;
			_isPrivate = isPrivate;
		}

		#endregion
	}
}
