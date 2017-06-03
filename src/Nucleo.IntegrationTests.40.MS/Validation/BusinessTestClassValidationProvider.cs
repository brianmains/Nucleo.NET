using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Validation
{
	public class BusinessTestClassValidationProvider : ValidationProvider
	{
		#region " Methods "

		public override bool IsCorrectValidator(object obj)
		{
			return (obj is BusinessTestClass);
		}

		public override ValidationItemCollection Validate(object obj)
		{
			BusinessTestClass bus = (BusinessTestClass)obj;
			ValidationItemCollection list = new ValidationItemCollection();

			if (string.IsNullOrEmpty(bus.Name))
				list.Add(new ValidationItem("Name", new ErrorValidationType(), "The name is required"));
			else if (bus.Name.Length <= 2)
				list.Add(new ValidationItem("Name", new WarningValidationType(), "The name may not be an actual name."));
			else if (bus.Name == "Ted")
				list.Add(new ValidationItem("Name", new InformationValidationType(), "Are you sure you want that name?"));

			if (string.IsNullOrEmpty(bus.City))
				list.Add(new ValidationItem("City", new ErrorValidationType(), "The city is required"));
			else if (bus.City.Length <= 2)
				list.Add(new ValidationItem("City", new WarningValidationType(), "The city length is two or less, which may not be an actual city name"));
			else if (bus.City == "Pittsburgh")
				list.Add(new ValidationItem("City", new InformationValidationType(), "Great city"));

			if (string.IsNullOrEmpty(bus.State))
				list.Add(new ValidationItem("State", new ErrorValidationType(), "The state is required"));
			else if (bus.State.Length == 1 || bus.State.Length > 2)
				list.Add(new ValidationItem("State", new WarningValidationType(), "The state is not two characters"));
			else if (bus.State == "NY")
				list.Add(new ValidationItem("State", new InformationValidationType(), "How can you afford the taxes????"));

			if (bus.ZipCode == 0 || bus.ZipCode > 99999)
				list.Add(new ValidationItem("ZipCode", new ErrorValidationType(), "The zip code is wrong"));
			else if (bus.ZipCode >= 501 && bus.ZipCode <= 10000)
				list.Add(new ValidationItem("ZipCode", new WarningValidationType(), "This zip code may not be valid, but will be allowed"));
			else if (bus.ZipCode == 90210)
				list.Add(new ValidationItem("ZipCode", new InformationValidationType(), "Do you know any actors?"));

			return list;
		}

		#endregion
	}
}
