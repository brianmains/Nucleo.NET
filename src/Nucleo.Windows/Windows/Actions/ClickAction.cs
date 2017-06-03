using System;
using Nucleo.Windows.UI;


namespace Nucleo.Windows.Actions
{
	public class ClickAction : IAction
	{
		#region " Constants "

		public const string DefaultActionName = "Click";

		#endregion



		#region " Properties "

		public string ActionName
		{
			get { return DefaultActionName; }
		}

		#endregion



		#region " Constructors "

		internal ClickAction() { }

		#endregion
	}
}
