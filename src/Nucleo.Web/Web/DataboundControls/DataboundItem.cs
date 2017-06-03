using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.DataboundControls
{
	public class DataboundItem : TableRow, IDataItemContainer
	{
		private object _dataItem = null;
		private int _dataItemIndex = -1;


		#region " Properties "

		public object DataItem
		{
			get { return _dataItem; }
		}

		public int DataItemIndex
		{
			get { return _dataItemIndex; }
		}

		public int DisplayIndex
		{
			get { return _dataItemIndex; }
		}

		#endregion



		#region " Constructors "

		public DataboundItem(object dataItem, int dataItemIndex)
		{
			_dataItem = dataItem;
			_dataItemIndex = dataItemIndex;
		}

		#endregion
	}
}
