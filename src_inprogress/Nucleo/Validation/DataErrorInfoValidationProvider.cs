using System;
using System.ComponentModel;
using System.Reflection;


namespace Nucleo.Validation
{
	public class DataErrorInfoValidationProvider : ValidationProvider
	{
		#region " Methods "

		public override bool IsCorrectValidator(object obj)
		{
			return (obj.GetType().GetInterface(typeof(IDataErrorInfo).FullName) != null);
			//return (obj.GetType().IsAssignableFrom(typeof(IDataErrorInfo)));
		}

		public override ValidationItemCollection Validate(object obj)
		{
			PropertyInfo[] properties = obj.GetType().GetProperties();
			ValidationItemCollection items = new ValidationItemCollection();

			foreach (PropertyInfo property in properties)
			{
				if (!property.CanRead)
					continue;

				string error = ((IDataErrorInfo)obj)[property.Name];
				if (!string.IsNullOrEmpty(error))
					items.Add(new ValidationItem(property.Name, new ErrorValidationType(), error));
			}

			return items;
		}

		#endregion
	}
}
