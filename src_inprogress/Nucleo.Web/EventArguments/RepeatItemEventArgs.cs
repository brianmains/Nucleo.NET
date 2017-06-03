using System;

using Nucleo.Web;
using Nucleo.Web.Repeating;


namespace Nucleo.EventArguments
{
	/// <summary>
	/// The event arguments for the current item being repeated in the system.
	/// </summary>
	public class RepeatItemEventArgs : EventArgs
	{
		private IRepeatableList _repeatControl = null;
		private int _repeatIndex = -1;



		#region " Properties "

		/// <summary>
		/// Gets the control that is repeating.
		/// </summary>
		public IRepeatableList RepeatControl
		{
			get { return _repeatControl; }
		}

		/// <summary>
		/// Gets the current index in the repeat process.
		/// </summary>
		public int RepeatIndex
		{
			get { return _repeatIndex; }
		}

		#endregion



		#region " Constructors "

		public RepeatItemEventArgs(IRepeatableList repeatControl, int repeatIndex)
		{
			_repeatControl = repeatControl;
			_repeatIndex = repeatIndex;
		}

		#endregion
	}
}
