using System;
using System.Collections.Generic;

using Nucleo.Collections;


namespace Nucleo.Web.Controls
{
	public class CheckImageCollection : SimpleCollection<CheckImage>
	{
		#region " Methods "

		/// <summary>
		/// Gets a check image by its associated value.
		/// </summary>
		/// <param name="value">The value to get the image by.</param>
		/// <returns>The image found associated to the value.</returns>
		public CheckImage GetByAssociatedValue(bool? value)
		{
			for (int index = 0, len = this.Count; index < len; index++)
			{
				if (this[index].AssociatedValue == value)
					return this[index];
			}

			return null;
		}

		#endregion
	}
}
