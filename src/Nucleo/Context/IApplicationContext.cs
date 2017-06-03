using System;


namespace Nucleo.Context
{
	public interface IApplicationContext : IServiceProvider
	{
		/// <summary>
		/// Gets the service by its type.
		/// </summary>
		/// <typeparam name="T">The type of service to return.</typeparam>
		/// <returns>The returned service, or null if not found.</returns>
		T GetService<T>() where T : IService;

		/// <summary>
		/// Gets the service by its type.
		/// </summary>
		/// <typeparam name="T">The type of service to convert the found value to.</typeparam>
		/// <param name="type">The type of service to find.</param>
		/// <returns>The returned service, or null if not found.</returns>
		T GetService<T>(Type type)
			where T : IService;
	}
}
