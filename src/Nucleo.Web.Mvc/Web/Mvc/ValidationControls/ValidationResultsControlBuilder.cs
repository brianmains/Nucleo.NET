using System;
using System.Web.Mvc;

using Nucleo.Validation;
using Nucleo.Web.Mvc;
using Nucleo.Web.ValidationControls;


namespace Nucleo.Web.Mvc.ValidationControls
{
	public class ValidationResultsControlBuilder : BaseMvcControlBuilder<ValidationResults, ValidationResultsControlBuilder>
	{
		#region " Constructors "

		public ValidationResultsControlBuilder(NucleoControlFactory controlFactory)
			: base(controlFactory) { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Sets the header message.
		/// </summary>
		/// <param name="headerMessage"></param>
		/// <returns></returns>
		public ValidationResultsControlBuilder HeaderMessage(string headerMessage)
		{
			this.GetControl().HeaderMessage = headerMessage;
			return this;
		}

		#endregion
	}
}
