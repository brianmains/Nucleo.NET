using System;
using System.Collections.Generic;
using System.Reflection;

using Nucleo.DynamicExecution.Configuration;
using Nucleo.EventArguments;
using Nucleo.Exceptions;
using Nucleo.Providers;


namespace Nucleo.DynamicExecution
{
	public static class DynamicExecutionPath
	{
		private static DynamicExecutionPathMethodProvider _defaultMethodProvider = null;
		private static DynamicExecutionPathMethodProviderCollection _methodProviders = null;

		private static bool? _failOnException = null;
		private static bool? _failOnFirstFailure = null;
		private static bool _initialized = false;
		private static object _lock = new object();



		#region " Events "

		/// <summary>
		/// Fires an event when the method was executed.
		/// </summary>
		public static event DataEventHandler<DynamicExecutionPathMethodInfo> MethodExecuted;

		/// <summary>
		/// Fires an event when the method is executing.
		/// </summary>
		public static event DataCancelEventHandler<DynamicExecutionPathMethodInfo> MethodExecuting;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets the provider that's setup the default to provide the list of methods for dynamic execution.
		/// </summary>
		public static DynamicExecutionPathMethodProvider DefaultMethodProvider
		{
			get
			{
				InitializeProviders();
				return _defaultMethodProvider;
			}
		}

		/// <summary>
		/// Gets or sets whether to fail the current execution on an exception thrown.
		/// </summary>
		public static bool FailOnException
		{
			get
			{
				if (_failOnException == null)
				{
					DynamicExecutionPathSection section = GetSection();
					_failOnException = section.FailOnException;
				}

				return _failOnException.Value;
			}
			set { _failOnException = value; }
		}

		/// <summary>
		/// Gets or sets whether to fail on the first failure returned through the execution.
		/// </summary>
		public static bool FailOnFirstFailure
		{
			get
			{
				if (_failOnFirstFailure == null)
				{
					DynamicExecutionPathSection section = GetSection();
					_failOnFirstFailure = section.FailOnFirstFailure;
				}

				return _failOnFirstFailure.Value;
			}
			set { _failOnFirstFailure = value; }
		}

		/// <summary>
		/// Gets the collection of the providers for methods that get dynamically executed.
		/// </summary>
		public static DynamicExecutionPathMethodProviderCollection MethodProviders
		{
			get
			{
				InitializeProviders();
				return _methodProviders;
			}
		}

		#endregion



		#region " Methods "

		private static bool ConvertBool(object value)
		{
			return (bool)value;
		}

		private static bool ConvertBool(string value)
		{
			return bool.Parse(value);
		}

		private static byte ConvertByte(object value)
		{
			return (byte)value;
		}

		private static byte ConvertByte(string value)
		{
			return byte.Parse(value);
		}

		private static string ConvertString(object value)
		{
			return value as string;
		}

		/// <summary>
		/// Changes the current provider being used based on its name.
		/// </summary>
		/// <param name="providerName">The name of the provider.</param>
		public static void ChangeProvider(string providerName)
		{
			if (string.IsNullOrEmpty(providerName))
				throw new ArgumentNullException("providerName");

			_defaultMethodProvider = MethodProviders[providerName];
			if (_defaultMethodProvider == null)
				throw new ArgumentException("The provider name does not exist in the list of providers");
		}

		/// <summary>
		/// Executes the list of methods based upon an array of boolean values.  The list of booleans must match the list of methods being executed.
		/// </summary>
		/// <param name="executionPattern">The pattern of booleans to use for execution.</param>
		/// <returns>The status of the execution.</returns>
		public static DynamicExecutionPathStatus ExecuteMethods(bool[] executionPattern)
		{
			if (executionPattern == null || executionPattern.Length == 0)
				throw new ArgumentNullException("executionPattern");

			DynamicExecutionPathMethodInfoCollection methodCollection = DefaultMethodProvider.GetMethods();
			if (methodCollection.Count != executionPattern.Length)
				throw new MismatchException("The total number of methods doesn't match the current execution plan");

			List<DynamicExecutionPathMethodInfo> methodsList = new List<DynamicExecutionPathMethodInfo>();

			for (int i = 0; i < executionPattern.Length; i++)
			{
				if (executionPattern[i])
					methodsList.Add(methodCollection[i]);
			}

			return ExecuteMethodsInternal(methodsList.ToArray());
		}

		/// <summary>
		/// Executes the list of methods based upon an array of byte values.  The list of bytes must match the list of methods being executed.
		/// </summary>
		/// <param name="executionPattern">The pattern of bytes to use for execution.</param>
		/// <returns>The status of the execution.</returns>
		public static DynamicExecutionPathStatus ExecuteMethods(byte[] executionPattern)
		{
			if (executionPattern == null || executionPattern.Length == 0)
				throw new ArgumentNullException("executionPattern");

			DynamicExecutionPathMethodInfoCollection methodCollection = DefaultMethodProvider.GetMethods();
			if (methodCollection.Count != executionPattern.Length)
				throw new MismatchException("The total number of methods doesn't match the current execution plan");

			List<DynamicExecutionPathMethodInfo> methodsList = new List<DynamicExecutionPathMethodInfo>();

			for (int i = 0; i < executionPattern.Length; i++)
			{
				if (executionPattern[i] != 0)
					methodsList.Add(methodCollection[i]);
			}

			return ExecuteMethodsInternal(methodsList.ToArray());
		}

		/// <summary>
		/// Executes the list of methods based upon an array of method names (using the friendly name).  This option varies from the other two execution options because only the names of the methods being executed are required.
		/// </summary>
		/// <param name="executionPattern">The pattern of bytes to use for execution.</param>
		/// <returns>The status of the execution.</returns>
		public static DynamicExecutionPathStatus ExecuteMethods(string[] methodFriendlyNames)
		{
			DynamicExecutionPathMethodInfoCollection methodCollection = DefaultMethodProvider.GetMethods();
			return ExecuteMethodsInternal(methodCollection.ToArray(methodFriendlyNames));
		}

		private static DynamicExecutionPathStatus ExecuteMethodsInternal(DynamicExecutionPathMethodInfo[] methodInformationArray)
		{
			DynamicExecutionPathStatus status = new DynamicExecutionPathStatus();
			DynamicExecutionPathEventArgs args = new DynamicExecutionPathEventArgs();

			foreach (DynamicExecutionPathMethodInfo methodInformation in methodInformationArray)
			{
				DataCancelEventArgs<DynamicExecutionPathMethodInfo> cancelArgs = new DataCancelEventArgs<DynamicExecutionPathMethodInfo>(methodInformation);
				OnMethodExecuting(cancelArgs);

				if (cancelArgs.Cancel)
				{
					status.MethodsIgnored.Add(methodInformation);
					continue;
				}

				Exception thrownException = null;
				bool continueProcessing = RunMethod(methodInformation, ref thrownException);
				OnMethodExecuted(new DataEventArgs<DynamicExecutionPathMethodInfo>(methodInformation));

				if (thrownException != null)
				{
					methodInformation.ThrownException = thrownException;
					status.MethodsFailed.Add(methodInformation);
					if (FailOnException)
						return status;
					else
						continue;
				}

				if (args.Failed)
				{
					status.MethodsFailed.Add(methodInformation);

					if (FailOnFirstFailure)
						return status;
					else
					{
						args.Failed = false;
						continue;
					}
				}

				if (!continueProcessing)
				{
					status.MethodsExecuted.Add(methodInformation);
					return status;
				}

				status.MethodsExecuted.Add(methodInformation);
			}

			return status;
		}

		/// <summary>
		/// Gets a reference to the underlying section.
		/// </summary>
		/// <returns>The instance of the section.</returns>
		private static DynamicExecutionPathSection GetSection()
		{
			DynamicExecutionPathSection section = DynamicExecutionPathSection.Instance;
			if (section == null)
				throw new System.Configuration.ConfigurationErrorsException("The dynamic execution path component hasn't been configured properly");

			return section;
		}

		/// <summary>
		/// Sets up the provider lists by converting the configuration definition into their actual implementations.
		/// </summary>
		private static void InitializeProviders()
		{
			if (_initialized) return;

			lock (_lock)
			{
				if (_initialized) return;

				DynamicExecutionPathSection section = DynamicExecutionPathSection.Instance;
				_methodProviders = ProviderHelper.InitializeProviders<DynamicExecutionPathMethodProviderCollection, DynamicExecutionPathMethodProvider>(section.MethodProviders);
				_defaultMethodProvider = _methodProviders[section.MethodProviders.DefaultProvider];
			}
		}

		/// <summary>
		/// Handles firing the <see cref="MethodExecuted" /> event.
		/// </summary>
		/// <param name="e">The details regarding the method execution.</param>
		private static void OnMethodExecuted(DataEventArgs<DynamicExecutionPathMethodInfo> e)
		{
			if (MethodExecuted != null)
				MethodExecuted(DefaultMethodProvider, e);
		}

		/// <summary>
		/// Handles firing the <see cref="MethodExecuting" /> event.
		/// </summary>
		/// <param name="e">The details regarding the method execution.</param>
		private static void OnMethodExecuting(DataCancelEventArgs<DynamicExecutionPathMethodInfo> e)
		{
			if (MethodExecuting != null)
				MethodExecuting(DefaultMethodProvider, e);
		}

		/// <summary>
		/// Performs the actual work of executing the method using the supplied method information.  Uses reflection to construct an instance of any object.
		/// </summary>
		/// <param name="methodInformation">The method information to use for method execution.</param>
		/// <returns></returns>
		private static bool RunMethod(DynamicExecutionPathMethodInfo methodInformation, ref Exception thrownException)
		{
			if (methodInformation == null)
				throw new ArgumentNullException("methodInformation");

			Type objectType = Type.GetType(methodInformation.ObjectTypeName);
			if (objectType == null)
				throw new NullReferenceException("The type " + methodInformation.ObjectTypeName + " could not be instantiated");

			object objectReference = Activator.CreateInstance(objectType);
			MethodInfo method = objectType.GetMethod(methodInformation.MethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			ParameterInfo[] parameters = method.GetParameters();
			bool continueProcessing = true;

			if (parameters.Length == 0)
			{
				try
				{
					continueProcessing = (bool)method.Invoke(objectReference, new object[] { });
				}
				catch (Exception ex)
				{
					thrownException = ex;
					continueProcessing = false;
				}
			}
			else if (parameters.Length == 1 && parameters[0].ParameterType.Equals(typeof(DynamicExecutionPathEventArgs)))
			{
				DynamicExecutionPathEventArgs args = new DynamicExecutionPathEventArgs();

				try
				{
					method.Invoke(objectReference, new object[] { args });
					continueProcessing = args.ContinueProcessing;
				}
				catch (Exception ex)
				{
					thrownException = ex;
					continueProcessing = false;
				}
			}
			else
				throw new NotSupportedException("Dynamic execution only works with an empty parameter method, or where the method uses the DynamicExecutionPathEventArgs as a single property");

			return continueProcessing;
		}

		#endregion
	}
}
