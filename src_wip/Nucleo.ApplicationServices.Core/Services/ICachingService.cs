using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Services
{
	/// <summary>
	/// Represents the service used for caching data.
	/// </summary>
	/// <example>
	/// var context = ApplicationContext.GetCurrent();
	/// var obj = context.GetService&lt;ICachingService>();
	/// //Use object
	/// </example>
	public interface ICachingService : ICollectionService
	{

	}
}
