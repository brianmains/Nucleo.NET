using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.Actions
{
	public class SelectionAction : IAction
	{
		#region " Constants "

		public const string DefaultActionName = "Selection";

		#endregion



		#region " Properties "

		public string ActionName
		{
			get { return DefaultActionName; }
		}

		#endregion



		#region " Constructors "

		internal SelectionAction() { }

		#endregion
	}
}
