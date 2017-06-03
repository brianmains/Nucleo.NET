using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Reflection
{
	public static class Reflect
	{
		public static ReflectDefinition NonPublic(object target)
		{
			return new ReflectDefinition(target, true);
		}

		public static ReflectDefinition Public(object target)
		{
			return new ReflectDefinition(target, false);
		}
	}
}
