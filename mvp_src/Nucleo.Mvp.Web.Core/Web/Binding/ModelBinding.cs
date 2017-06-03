using System;
using System.Reflection;
using System.Collections.Generic;
using System.Globalization;


namespace Nucleo.Web.Binding
{
	/// <summary>
	/// Represents a component to bind the models.
	/// </summary>
	public class ModelBinding
	{
		private bool _hasErrors = false;



		#region " Properties "

		/// <summary>
		/// Gets whether the model binding reported any errors.
		/// </summary>
		public bool HasErrors
		{
			get { return _hasErrors; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Actually performs the work of converting the value.
		/// </summary>
		/// <param name="value">The value to convert.</param>
		/// <param name="propType">The property type.</param>
		/// <returns>The value.</returns>
		private static object GetValueToInject(string value, Type propType)
		{
			return Convert.ChangeType(value, propType, CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Gets the form collection from a model.
		/// </summary>
		/// <param name="model">The model instance.</param>
		/// <returns></returns>
		public FormCollection Read(object model)
		{
			if (model == null)
				throw new ArgumentNullException("model");

			PropertyInfo[] props = model.GetType().GetProperties();
			FormCollection coll = new FormCollection();

			for (int i = 0, len = props.Length; i < len; i++)
			{
				object value = props[i].GetValue(model, null);
				coll.Add(props[i].Name, (value != null) ? value.ToString() : default(string));
			}

			return coll;
		}

		/// <summary>
		/// Binds a model to the collection of form values.
		/// </summary>
		/// <param name="model">The object to bind.</param>
		/// <param name="form">The form values.</param>
		public bool Write(object model, FormCollection form)
		{
			if (model == null)
				throw new ArgumentNullException("model");
			if (form == null)
				return false;

			PropertyInfo[] props = model.GetType().GetProperties();

			for (int i = 0, len = props.Length; i < len; i++)
			{
				var prop = props[i];
				if (form.ContainsKey(prop.Name))
				{
					string value = form[prop.Name];

					try
					{
						prop.SetValue(model, GetValueToInject(value, prop.PropertyType), null);
					}
					catch
					{
						_hasErrors = true;
					}
				}
			}

			return true;
		}

		/// <summary>
		/// Instantiates the object, and then binds the form dictionary values to the model.
		/// </summary>
		/// <typeparam name="T">The type of object to create.</typeparam>
		/// <param name="form">The form.</param>
		public T Write<T>(FormCollection form)
		{
			T model = Activator.CreateInstance<T>();
			this.Write(model, form);

			return model;
		}

		#endregion
	}
}
