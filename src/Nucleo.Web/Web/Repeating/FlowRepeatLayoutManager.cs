using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;


namespace Nucleo.Web.Repeating
{
	public class FlowRepeatLayoutManager : RepeatLayoutManager
	{
		#region " Constructors "

		public FlowRepeatLayoutManager(int repeatColumnCount, RepeatLayout repeatingLayout, RepeatDirection repeatingDirection)
			: base(repeatColumnCount, repeatingLayout, repeatingDirection) { }

		#endregion



		#region " Methods "

		public override void RenderBeginningStructure(HtmlTextWriter writer)
		{
			writer.RenderBeginTag(HtmlTextWriterTag.Span);
		}

		public override void RenderEndingStructure(HtmlTextWriter writer)
		{
			writer.RenderEndTag(); //span
		}

		public override void RenderRow(HtmlTextWriter writer, IRepeatableList repeatControl, IEnumerable<int> indexes)
		{
			writer.RenderBeginTag(HtmlTextWriterTag.Span);

			foreach (int index in indexes)
				repeatControl.RenderItem(writer, index);

			writer.RenderEndTag(); //span
		}

		#endregion
	}
}
