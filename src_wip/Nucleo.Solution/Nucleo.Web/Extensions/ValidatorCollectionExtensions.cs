using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Linq;


namespace System.Web.UI
{
	public static class ValidatorCollectionExtensions
	{
		#region " Methods "

		public static IEnumerable<IValidator> FindInError(this ValidatorCollection vals)
		{
			return vals.OfType<IValidator>().Where(i => i.IsValid == false);
		}

		public static IEnumerable<IValidator> FindNotInError(this ValidatorCollection vals)
		{
			return vals.OfType<IValidator>().Where(i => i.IsValid == true);
		}

		public static IEnumerable<BaseValidator> FindByValidationGroup(this ValidatorCollection vals, string valGroup)
		{
			return vals.OfType<BaseValidator>().Where(i => i.ValidationGroup == valGroup);
		}

		#endregion
	}
}