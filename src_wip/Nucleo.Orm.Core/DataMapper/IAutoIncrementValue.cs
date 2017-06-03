using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.DataMapper
{
	public interface IAutoIncrementValue : IValue
	{
		long Current { get; }

		void Increment(object value);
	}
}
