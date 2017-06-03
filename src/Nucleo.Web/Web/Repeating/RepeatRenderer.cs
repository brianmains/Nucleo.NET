using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Math;


namespace Nucleo.Web.Repeating
{
	public class RepeatRenderer
	{
		private RepeatLayoutManager _manager = null;



		#region " Methods "
		
		public void Render(IRepeatableList repeatableControl, HtmlTextWriter writer)
		{
			_manager = RepeatLayoutManager.GetManager(repeatableControl);
			this.RenderRows(repeatableControl, writer);
		}

		private void RenderRows(IRepeatableList repeatableControl, HtmlTextWriter writer)
		{
			_manager.RenderBeginningStructure(writer);

			int columnCount = repeatableControl.RepeatColumnCount;
			if (columnCount < 0)
				throw new ArgumentOutOfRangeException("IRepeatableList.RepeatColumnCount");
			columnCount = (columnCount > 0) ? columnCount : 1;

			IndexRowCollection rows = IndexCounter.CreateRepeatableIndexes(0, repeatableControl.TotalCount - 1,
				columnCount, (repeatableControl.RepeatingDirection == RepeatDirection.Horizontal)
			    ? IndexRepeatDirection.Horizontal : IndexRepeatDirection.Vertical);

			foreach (IndexRow row in rows)
				_manager.RenderRow(writer, repeatableControl, row.Values.ToArray());

			_manager.RenderEndingStructure(writer);
		}

		#endregion
	}
}
