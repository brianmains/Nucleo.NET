using System;
using System.Web.UI.WebControls;


namespace Nucleo.Web.Controls
{
	public interface IRepeatableControl : IRepeatInfoUser
	{
		int RepeatColumns { get; set; }
		RepeatDirection RepeatDirection { get; set; }
		RepeatLayout RepeatLayout { get; set; }
	}
}
