using System;


namespace Nucleo.Validation
{
	public class EmptyValidationType : ValidationType
	{
		#region " Properties "

		public override bool IsEmpty
		{
			get { return true; }
		}

		#endregion



		#region " Constructors "

		public EmptyValidationType()
			: base(null, 0) { }

		#endregion
	}
}
