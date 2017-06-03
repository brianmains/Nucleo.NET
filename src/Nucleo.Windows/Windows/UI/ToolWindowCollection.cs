using System;


namespace Nucleo.Windows.UI
{
	public class ToolWindowCollection : UIElementCollection<ToolWindow>
	{
		public int GetCount(ToolWindowLocation location)
		{
			int count = 0;

			foreach (ToolWindow window in this)
			{
				if (window.Location == location)
					count++;
			}

			return count;
		}
	}
}
