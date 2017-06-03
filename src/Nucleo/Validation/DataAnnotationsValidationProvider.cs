using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;


namespace Nucleo.Validation
{
	public class DataAnnotationsValidationProvider : ValidationProvider
	{
		#region " Methods "

		public override bool IsCorrectValidator(object obj)
		{
			Attribute attrib = Attribute.GetCustomAttribute(obj.GetType(), typeof(DataAnnotatedInstanceAttribute));
			if (attrib != null)
				return true;

			return false;
		}

		public override ValidationItemCollection Validate(object obj)
		{
			PropertyInfo[] properties = obj.GetType().GetProperties();
			ValidationItemCollection items = new ValidationItemCollection();

			foreach (PropertyInfo property in properties)
			{
				object[] attributes = property.GetCustomAttributes(false);

				foreach (object attribute in attributes)
				{
					if (attribute is ValidationAttribute)
					{
						ValidationAttribute valAttrib = (ValidationAttribute)attribute;
						if (!valAttrib.IsValid(property.GetValue(obj, null)))
							items.Add(new ValidationItem(property.Name, new ErrorValidationType(), valAttrib.ErrorMessage));
					}
				}
			}

			return items;
		}

		#endregion
	}
}
