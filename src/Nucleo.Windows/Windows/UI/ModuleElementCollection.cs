using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.UI
{
	public class ModuleElementCollection :IEnumerable<UIElement>, IElementCollection
	{
		private List<UIElement> _items = null;



		#region " Properties "

		public int Count
		{
			get { return this.Items.Count; }
		}

		public List<UIElement> Items
		{
			get
			{
				if (_items == null)
					_items = new List<UIElement>();
				return _items;
			}
		}

		public UIElement this[int i]
		{
			get { return this.Items[i]; }
		}

		public UIElement this[string name]
		{
			get { throw new NotImplementedException(); }
		}

		public UIElement this[ValuePath path]
		{
			get { throw new NotImplementedException(); }
		}

		#endregion



		#region " Methods "

		public void Add(UIElement element)
		{
			if (!(element is MenuItem) && !(element is Toolbar) && !(element is ToolbarItem))
				throw new InvalidCastException("The element can only be a MenuItem or Toolbar/item");

			this.Items.Add(element);
		}

		public bool Contains(UIElement element)
		{
			return this.Items.Contains(element);
		}

		public bool Contains(ValuePath path)
		{
			UIElement parent = null;
			UIElement child = null;

			ValuePathUtility.GetChildElement(path, this, ref parent, ref child);
			return (child != null);
		}

		public IEnumerator<UIElement> GetEnumerator()
		{
			return this.Items.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.Items.GetEnumerator();
		}

		public void Insert(int index, UIElement element)
		{
			if (!(element is MenuItem) && !(element is Toolbar) && !(element is ToolbarItem))
				throw new InvalidCastException("The element can only be a MenuItem or Toolbar/item");

			this.Items.Insert(index, element);
		}

		public bool Remove(UIElement element)
		{
			return this.Items.Remove(element);
		}

		public bool Remove(ValuePath path)
		{
			UIElement parent = null;
			UIElement child = null;

			ValuePathUtility.GetChildElement(path, this, ref parent, ref child);
			if (parent != null)
				return ((IParentElement)parent).Items.Remove(child);
			else
				return this.Items.Remove(child);
		}

		#endregion
	}
}
