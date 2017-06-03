using System;
using System.Collections.Generic;

using Nucleo.Context;

namespace Nucleo.Web.Context.Services
{
	public interface IPostedFilesService : IService
	{
		PostedFile Get(string key);
		PostedFile Get(int index);
	}
}
