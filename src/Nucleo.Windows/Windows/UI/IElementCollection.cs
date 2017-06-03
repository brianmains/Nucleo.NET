using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.UI
{
	public interface IElementCollection
	{
		#region " Properties "

		int Count { get; }
		UIElement this[int i] { get; }
		UIElement this[string name] { get; }
		UIElement this[ValuePath path] { get; }

		#endregion



		#region " Methods "

		void Add(UIElement element);
		bool Contains(UIElement element);
		bool Contains(ValuePath path);
		void Insert(int index, UIElement element);
		bool Remove(UIElement element);
		bool Remove(ValuePath path);

		#endregion
	}
}
