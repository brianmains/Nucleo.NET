using System;
using System.Collections.Generic;

using Nucleo.IO;


namespace Nucleo.Services
{
	public interface IPostedFilesService : IService
	{
		PostedFile Get(string key);
		PostedFile Get(int index);
	}
}
