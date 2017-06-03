using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Nucleo.Collections;


namespace Nucleo.Web.Repeating
{
	public abstract class RepeatLayoutManager
	{
		private readonly int _repeatColumnCount = 0;
		private readonly RepeatDirection _repeatingDirection = RepeatDirection.Horizontal;
		private readonly RepeatLayout _repeatingLayout = RepeatLayout.Flow;



		#region " Properties "

		public int RepeatColumnCount
		{
			get { return _repeatColumnCount; }
		}

		public RepeatDirection RepeatingDirection
		{
			get { return _repeatingDirection; }
		}

		public RepeatLayout RepeatingLayout
		{
			get { return _repeatingLayout; }
		}

		#endregion



		#region " Properties "

		protected RepeatLayoutManager(int repeatColumnCount, RepeatLayout repeatingLayout, RepeatDirection repeatingDirection)
		{
			_repeatColumnCount = repeatColumnCount;
			_repeatingLayout = repeatingLayout;
			_repeatingDirection = repeatingDirection;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the instance of the manager.
		/// </summary>
		/// <param name="repeatControl">The control implementing the repeating interface.</param>
		/// <returns>Returns the repeat manager class instance.</returns>
		public static RepeatLayoutManager GetManager(IRepeatableList repeatControl)
		{
			if (repeatControl.RepeatingLayout == RepeatLayout.Table)
				return new TableRepeatLayoutManager(
					repeatControl.RepeatColumnCount,
					repeatControl.RepeatingLayout,
					repeatControl.RepeatingDirection);
			else if (repeatControl.RepeatingLayout == RepeatLayout.Flow)
				return new FlowRepeatLayoutManager(
					repeatControl.RepeatColumnCount,
					repeatControl.RepeatingLayout,
					repeatControl.RepeatingDirection);
			else
				throw new NotImplementedException();
		}

		public abstract void RenderBeginningStructure(HtmlTextWriter writer);

		public abstract void RenderEndingStructure(HtmlTextWriter writer);

		public void RenderRow(HtmlTextWriter writer, IRepeatableList repeatControl, int[] indexes)
		{
			this.RenderRow(writer, repeatControl, (IEnumerable<int>) indexes);
		}

		public abstract void RenderRow(HtmlTextWriter writer, IRepeatableList repeatControl, IEnumerable<int> indexes);

		#endregion
	}
}
