using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.UI
{
	public class ToolbarGroup : UIElement
	{
		private ToolbarItemCollection _items = null;
		private Toolbar _parent = null;



		#region " Properties "

		public override ValuePath CurrentPath
		{
			get { return new ValuePath(this.Parent.Name, this.Name); }
		}

		public ToolbarItemCollection Items
		{
			get
			{
				if (_items == null)
					_items = new ToolbarItemCollection();
				return _items;
			}
		}

		public Toolbar Parent
		{
			get { return _parent; }
		}

		#endregion



		#region " Constructors "

		public ToolbarGroup(string name, string title, Toolbar parent) 
			: base(name, title)
		{
			_parent = parent;
		}

		#endregion
	}
}
