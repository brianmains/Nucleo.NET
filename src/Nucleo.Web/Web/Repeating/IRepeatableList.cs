using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.Repeating
{
	public interface IRepeatableList
	{
		int RepeatColumnCount { get; set; }
		RepeatDirection RepeatingDirection { get; set; }
		RepeatLayout RepeatingLayout { get; set; }
		bool ShowFooter { get; }
		bool ShowHeader { get; }
		int TotalCount { get; }

		void RenderItem(HtmlTextWriter writer, int index);
	}
}
