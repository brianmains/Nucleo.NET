using System;
using System.Drawing;

using Nucleo.EventArguments;
using Nucleo.Collections;
using Nucleo.Windows.Actions;
using Nucleo.Windows.Application;


namespace Nucleo.Windows.UI
{
	public class ToolbarDropDown : ToolbarTextImageItem, Actions.IActionableElement
	{
		private ToolbarDropDownDisplay _display = ToolbarDropDownDisplay.DropDown;
		private ObjectCollection _items = null;
		private object _selectedItem = null;



		#region " Events "

		public static EventAction SelectionChangedEvent = EventAction.Create("SelectionChanged", typeof(ToolbarDropDown));

		#endregion



		#region " Properties "

		/// <summary>
		/// How to display the drop down item in the list.
		/// </summary>
		new public ToolbarDropDownDisplay Display
		{
			get { return _display; }
			set
			{
				if (_display != value)
				{
					ToolbarDropDownDisplay oldValue = _display;
					_display = value;

					this.OnPropertyChanged(new PropertyChangedEventArgs("Display", oldValue, _display));
				}
			}
		}

		/// <summary>
		/// The collection of items that represent the drop down.
		/// </summary>
		public ObjectCollection Items
		{
			get
			{
				if (_items == null)
					_items = new ObjectCollection();
				return _items;
			}
		}

		/// <summary>
		/// The current item that is selected.
		/// </summary>
		public object SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				if (!this.Items.Contains(value))
					throw new Exception("The selected item is not in the collection");

				if (_selectedItem != value)
				{
					object oldValue = _selectedItem;
					_selectedItem = value;

					ApplicationEventsManager.FireEventNotification(ApplicationEventKeys.SelectEventName, _selectedItem, _selectedItem);
					this.OnPropertyChanged(new PropertyChangedEventArgs("SelectedItem", oldValue, _selectedItem));
				}
			}
		}

		#endregion



		#region " Constructors "

		public ToolbarDropDown(string name, string title, Toolbar parent)
			: base(name, title, parent) { }

		public ToolbarDropDown(string name, string title, string text, Image image, Toolbar parent)
			: base(name, title, text, image, parent) { }

		#endregion



		#region " Methods "

		public override EventActionCollection GetEvents()
		{
			return new EventActionCollection
			       	{
						SelectionChangedEvent
			       	};
		}

		void IActionableElement.PerformAction(IAction action, object target)
		{
			if (action is Actions.SelectionAction)
			{
				this.SelectedItem = target;
			}
			else
				throw new NotImplementedException();
		}

		#endregion
	}
}
