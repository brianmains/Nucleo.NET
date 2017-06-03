using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.IO
{
	public interface IFoundObject
	{
		string FullName { get; }

		string ShortName { get; }
	}
}
