using System;
using System.Web.UI.WebControls;


namespace Nucleo.Web.DataboundControls
{
	public class EditableDataboundItem : DataboundItem
	{
		private DataControlRowState _rowState = DataControlRowState.Normal;



		#region " Properties "

		public DataControlRowState RowState
		{
			get { return _rowState; }
		}

		#endregion



		#region " Constructors "

		public EditableDataboundItem(object dataItem, int dataItemIndex, DataControlRowState rowState) : base(dataItem, dataItemIndex)
		{
			_rowState = rowState;
		}

		#endregion
	}
}
