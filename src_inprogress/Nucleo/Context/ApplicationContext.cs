using System;
using System.Collections.Generic;
using System.Text;

using Nucleo.Collections;
using Nucleo.Context.Configuration;
using Nucleo.Context.Providers;


namespace Nucleo.Context
{
	/// <summary>
	/// This object represents a core API to make available common application services.  This object makes services available that implement the IService interface.  This object has similarities to how the Unity Application Block (from Microsoft) works, but it's purpose is different.  A provider and a loader component is required for this application to work correctly.  This is defined in the configuration file.
	/// </summary>
	/// <remarks>
	/// Because the application context is instance-based and doesn't implement the singleton pattern, it can be extended using extension methods.  This service exposes IService implementations; however, IService doesn't actually do anything but is a marker to implement a special service that ApplicationContext can load up.  For more information, check out:
	/// http://msmvps.com/blogs/bmains/archive/2009/10/30/accessing-service-oriented-api-s-using-an-iservice-interface.aspx
	/// </remarks>
	/// <seealso cref="ApplicationContextProvider"/>
	/// <seealso cref="ApplicationContextServiceLoader"/>
	/// <example>
	/// ApplicationContext context = ApplicationContext.GetCurrent();
	/// var service = context.GetService&lt;IEmailService>();
	/// service.SendEmail(new string[] { "a@a.com", "b@b.com", "Subject", "Message" });
	/// </example>
	public class ApplicationContext : IApplicationContext, IServiceProvider
	{
		private TypeRegistry _registry = null;



		#region " Constructors "

		private ApplicationContext() { }

		#endregion



		#region " Methods "

		private static object CreateObject(string type)
		{
			Type createdType = Type.GetType(type);

			if (createdType != null)
				return Activator.CreateInstance(createdType);
			else
				return null;
		}

		/// <summary>
		/// Gets a reference to the current ApplicationContext object.  This method recreates and reloads the application context every time, so that the application context has the most up-to-date information.
		/// </summary>
		/// <returns>Gets a reference to the current application context.</returns>
		/// <example>
		/// var context = ApplicationContext.GetCurrent();
		/// //use context
		/// </example>
		public static ApplicationContext GetCurrent()
		{
			ContextSettingsSection section = ContextSettingsSection.Instance;
			//If no config section exists, then return null; otherwise,
			//every other error is an exception because it should be provided.
			if (section == null)
				return null;

			IApplicationContextServiceRegistry registry = null;

			if (section != null && string.IsNullOrEmpty(section.ServiceRegistryType))
				registry = new Providers.ConfigurationApplicationContextServiceRegistry();
			else
			{
				registry = CreateObject(section.ServiceRegistryType) as IApplicationContextServiceRegistry;

				if (registry == null)
					throw new NullReferenceException("The servidce registry has not been specified in the configuration file or does not implement IApplicationContextServiceRegistry.");
			}

			return GetCurrent(registry);
		}

		/// <summary>
		/// Gets a reference to the current ApplicationContext object.  This method recreates and reloads the application context every time, so that the application context has the most up-to-date information.
		/// </summary>
		/// <returns>Gets a reference to the current application context.</returns>
		/// <example>
		/// var context = ApplicationContext.GetCurrent();
		/// //use context
		/// </example>
		public static ApplicationContext GetCurrent(IApplicationContextServiceRegistry serviceRegistry)
		{
			ApplicationContext context = new ApplicationContext();
			context._registry = new TypeRegistry();

			serviceRegistry.LoadServices(context._registry);

			return context;
		}

		/// <summary>
		/// Retrieves a service using its interface or its type specification.
		/// </summary>
		/// <typeparam name="T">The type interface to use to retrieve a value back.</typeparam>
		/// <returns>The instance if it is found, or null.</returns>
		/// <remarks>This could be via the interface <see cref="IEmailService">IEmailService</see> or via the type <see cref="EmailService">EmailService</see>.  If services have not yet been loaded, this method will cause that load to occur.</remarks>
		/// <example>
		/// var context = ApplicationContext.GetCurrent();
		/// var logger = context.GetService&lt;ILoggerService>();
		/// if (logger != null) { .. }
		/// </example>
		public T GetService<T>()
			where T: IService
		{
			return _registry.GetRegistration<T>();
		}

		public object GetService(Type serviceType)
		{
			return _registry.GetRegistration(serviceType);
		}

		public T GetService<T>(Type serviceType)
			where T : IService
		{
			object value = this.GetService(serviceType);
			return (value != null) ? (T)value : default(T);
		}

		#endregion
	}
}
