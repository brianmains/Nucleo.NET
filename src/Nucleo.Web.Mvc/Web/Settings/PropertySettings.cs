using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Settings
{
	public abstract class PropertySettings
	{
		private IDictionary<string, object> _settings = null;



		#region " Properties "

		protected IDictionary<string, object> Settings
		{
			get
			{
				if (_settings == null)
					_settings = new Dictionary<string, object>();

				return _settings;
			}
		}

		#endregion



		#region " Constructors "

		public PropertySettings() { }

		protected PropertySettings(IDictionary<string, object> settings)
		{
			_settings = settings;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds or updates a value to the underlying dictionary.
		/// </summary>
		/// <param name="name">The name of the value pair.</param>
		/// <param name="value">The value of the value pair.</param>
		protected void AddOrUpdateValue(string name, object value)
		{
			if (this.Settings.ContainsKey(name))
				this.Settings[name] = value;
			else
				this.Settings.Add(name, value);
		}

		/// <summary>
		/// Gets the value of the name/value pair, using the name.  This may return null if not found.
		/// </summary>
		/// <param name="name">The name of the pairing.</param>
		/// <returns>The value of the pairing.</returns>
		protected object GetValue(string name)
		{
			if (this.Settings.ContainsKey(name))
				return this.Settings[name];
			else
				return null;
		}

		/// <summary>
		/// Gets the value of the name/value pair, using the name.  This may return the default value of the specified type if not found.
		/// </summary>
		/// <param name="name">The name of the pairing.</param>
		/// <returns>The value of the pairing.</returns>
		protected T GetValue<T>(string name)
		{
			if (this.Settings.ContainsKey(name))
				return (T)this.Settings[name];
			else
				return default(T);
		}

		protected bool RemoveValue(string name)
		{
			if (this.Settings.ContainsKey(name))
				return this.Settings.Remove(name);
			else
				return false;
		}

		#endregion
	}
}
