using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.DataMapper
{
	public interface IRangeValue : IValue
	{
		object[] GetValues();
	}
}
