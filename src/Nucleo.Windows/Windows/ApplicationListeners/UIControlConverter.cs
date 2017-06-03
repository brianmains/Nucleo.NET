using System;
using System.Collections.Generic;


namespace Nucleo.Windows.ApplicationListeners
{
	public abstract class UIControlConverter
	{
		#region " Properties "

		public abstract object GetFinalControlReference(object controlReference);

		protected internal abstract bool IsSupportedType(object controlReference);

		#endregion
	}
}
