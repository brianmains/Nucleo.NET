using System;
using Nucleo;


namespace Nucleo.Services
{
	public interface ICurrentRequestService : IService
	{
		string RawUrl { get; }
	}
}
