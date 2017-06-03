using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.Repeating;

#if DEBUG

#endif


namespace Nucleo.Web.ListControls.Builders
{
	public abstract class ListInterfaceBuilder
	{
		private LayoutStructure _stucture = null;
		private IRepeatableList _listControl = null;



		#region " Properties "

		/// <summary>
		/// Gets the list control reference to use when building the object.
		/// </summary>
		public IRepeatableList ListControl
		{
			get { return _listControl; }
		}

		internal LayoutStructure Structure
		{
			get
			{
				if (_stucture == null)
					_stucture = new LayoutStructure();
				return _stucture;
			}
		}

		#endregion



		#region " Constructors "

		public ListInterfaceBuilder(IRepeatableList listControl)
		{
			_listControl = listControl;
		}

		#endregion



		#region " Methods "

		public abstract void AddItem(ListItem item);
		public abstract void ClearItems(ListItem item);
		public abstract void CreateItem(HtmlTextWriter writer);

		protected virtual void Render()
		{
			
		}

		#endregion
	}
}
