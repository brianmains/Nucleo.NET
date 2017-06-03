using System;

using Nucleo.Windows.UI;
using Nucleo.Windows.Application;


namespace Nucleo.EventArguments
{
	public class ApplicationModelEventArgs
	{
		private ApplicationModel _application = null;
		private int _index = -1;
		private UIElement _item = null;
		private UIElement _parent = null;



		#region " Methods "

		/// <summary>
		/// Gets the application that raised the event.
		/// </summary>
		public ApplicationModel Application
		{
			get { return _application; }
		}

		/// <summary>
		/// Gets the index of the item to perform an action against.
		/// </summary>
		public int Index
		{
			get { return _index; }
		}

		/// <summary>
		/// Gets the item that was modified.
		/// </summary>
		public UIElement Item
		{
			get { return _item; }
		}

		/// <summary>
		/// Gets the parent of the item that was modified, as a child collection could be manipulated.
		/// </summary>
		public UIElement Parent
		{
			get { return _parent; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Instantiates an event argument object with the single-item event details.
		/// </summary>
		/// <param name="item">The item being added.</param>
		/// <param name="index"></param>
		/// <param name="application"></param>
		public ApplicationModelEventArgs(UIElement item, int index, ApplicationModel application)
		{
			_item = item;
			_index = index;
			_application = application;
		}

		public ApplicationModelEventArgs(UIElement parent, UIElement item, int index, ApplicationModel application)
			: this(item, index, application)
		{
			_parent = parent;
		}

		#endregion
	}


	public delegate void ApplicationModelEventHandler(object sender, ApplicationModelEventArgs e);
}
