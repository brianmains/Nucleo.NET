using System;
using Nucleo.Windows.UI;


namespace Nucleo.Windows
{
	internal class ValuePathUtility
	{
		internal static void GetChildElement(ValuePath path, IElementCollection collection, ref UIElement parent, ref UIElement child)
		{
			if (path.Values.Count == 0)
				return;
			if (path.Values.Count == 1)
				return;

			for (int i = 0; i < path.Values.Count; i++)
			{
				if (i != 0)
					parent = child;

				if (parent != null)
				{
					IParentElement parentItem = parent as IParentElement;
					if (parentItem == null)
						return;

					child = parentItem.Items[path.Values[i]];
				}
				else
					child = collection[path.Values[i]];
			}
		}
	}
}
