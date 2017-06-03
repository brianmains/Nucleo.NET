using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.DataMapper
{
	public static class Mappings
	{
		public static FieldMapping Map(string property, IValue value)
		{
			return new FieldMapping(property, value);
		}

		public static FieldMapping Map<T>(Expression<Func<T, object>> mapping, IValue value)
		{
			return new FieldMapping(((MemberExpression)mapping.Body).Member.Name, value);
		}
	}
}
