using System;
using Nucleo.Collections;

using Nucleo.Configuration;
using Nucleo.Windows.ApplicationListeners.Configuration;


namespace Nucleo.Windows.ApplicationListeners
{
	public sealed class ControlConversionManager
	{
		private SimpleCollection<UIControlConverter> _converters = null;



		#region " Properties "

		/// <summary>
		/// Gets a collection of converters used by the manager.
		/// </summary>
		private SimpleCollection<UIControlConverter> Converters
		{
			get
			{
				if (_converters == null)
					_converters = new SimpleCollection<UIControlConverter>();
				return _converters;
			}
		}

		#endregion



		#region " Methods "

		public object ConvertReference(object originalReference)
		{
			foreach (UIControlConverter converter in this.Converters)
			{
				if (converter.IsSupportedType(originalReference))
					return converter.GetFinalControlReference(originalReference);
			}

			return null;
		}

		/// <summary>
		/// Gets the manager to convert UI control references.
		/// </summary>
		/// <returns>The manager that contains the control converters.</returns>
		public static ControlConversionManager GetManager()
		{
			ControlConversionManager manager = new ControlConversionManager();
			ControlConversionSection section = ControlConversionSection.Instance;

			//If converters to load, load them into the collection
			if (section != null)
			{
				foreach (NameTypeElement element in section.Converters)
					manager.Converters.Add(ActivatorLoader.LoadType<UIControlConverter>(element));
			}

			return manager;
		}

		/// <summary>
		/// Manually registers a converter for a specific control type.
		/// </summary>
		/// <param name="converter">The converter to register.</param>
		public void RegisterConverter(UIControlConverter converter)
		{
			if (converter == null)
				throw new ArgumentNullException("converter");

			this.Converters.Add(converter);
		}

		#endregion
	}
}
