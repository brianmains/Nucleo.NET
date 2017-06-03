using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Validation
{
	public class ValidationSession
	{
		private ValidationItemCollection _items = null;



		#region " Properties "

		/// <summary>
		/// Gets the items that were noted in the this validation session.  These are not necessarily errors.
		/// </summary>
		public ValidationItemCollection Items
		{
			get
			{
				if (_items == null)
					_items = new ValidationItemCollection();
				return _items;
			}
		}

		#endregion



		#region " Constructors "

		public ValidationSession(ValidationItemCollection items)
		{
			_items = items;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Merges another session into this current session.
		/// </summary>
		/// <param name="session">The session to merge into this current one.</param>
		public void MergeSession(ValidationSession session)
		{
			for (int index = 0, len = session.Items.Count; index < len; index++)
				this.Items.Add(session.Items[index]);
		}

		#endregion
	}
}
