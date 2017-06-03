using System;
using System.Collections.Generic;

using Nucleo.Collections;
using Nucleo.Exceptions;


namespace Nucleo.Context
{
	/// <summary>
	/// Represents a collection of services.
	/// </summary>
	public class ServiceCollection : SimpleCollection<IService>
	{
		#region " Methods "

		/// <summary>
		/// Adds a service to the collection.
		/// </summary>
		/// <param name="service"></param>
		public override void Add(IService service)
		{
			if (service == null)
				throw new ArgumentNullException("service");

			base.Add(service);
		}

		/// <summary>
		/// Gets a service by its type.  Can be used to check the interface type, or the concrete type.
		/// </summary>
		/// <typeparam name="T">The type of service to find.</typeparam>
		/// <returns>The service found or null if not found.</returns>
		public T GetByType<T>()
			where T : IService
		{
			for (int index = 0, len = this.Count; index < len; index++)
			{
				if (this[index] is T)
					return (T)this[index];
			}

			return default(T);
		}

		/// <summary>
		/// Removes a service reference.
		/// </summary>
		/// <param name="service">The service to remove.</param>
		public override void Remove(IService service)
		{
			if (service == null)
				throw new ArgumentNullException("service");

			base.Remove(service);
		}

		#endregion
	}
}
