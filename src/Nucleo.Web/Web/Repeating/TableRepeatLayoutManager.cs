using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;


namespace Nucleo.Web.Repeating
{
	public class TableRepeatLayoutManager : RepeatLayoutManager
	{
		#region " Constructors "

		public TableRepeatLayoutManager(int repeatColumnCount, RepeatLayout repeatingLayout, RepeatDirection repeatingDirection)
			: base(repeatColumnCount, repeatingLayout, repeatingDirection) { }

		#endregion


		#region " Methods "

		public override void RenderBeginningStructure(HtmlTextWriter writer)
		{
			writer.RenderBeginTag(HtmlTextWriterTag.Table);
			writer.RenderBeginTag(HtmlTextWriterTag.Thead);
			writer.RenderEndTag(); //thead
			writer.RenderBeginTag(HtmlTextWriterTag.Tbody);
		}

		public override void RenderEndingStructure(HtmlTextWriter writer)
		{
			writer.RenderEndTag(); //tbody
			writer.RenderEndTag(); //table
		}

		public override void RenderRow(HtmlTextWriter writer, IRepeatableList repeatControl, IEnumerable<int> indexes)
		{
			writer.RenderBeginTag(HtmlTextWriterTag.Tr);


			foreach (int index in indexes)
			{
				writer.RenderBeginTag(HtmlTextWriterTag.Td);

				//RenderControl already does the work of rendering the UI
				repeatControl.RenderItem(writer, index);

				writer.RenderEndTag(); //td
			}

			writer.RenderEndTag(); //tr
		}

		#endregion
	}
}
