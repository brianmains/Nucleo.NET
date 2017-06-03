using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo
{
	public interface ICodeSampleSupport
	{
		IEnumerable<CodeSample> GetSamples();
	}
}
