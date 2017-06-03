using System;
using System.ComponentModel;
using System.Collections.Generic;

using Nucleo.EventArguments;
using Nucleo.Windows.Application;
using Nucleo.Windows.Commands;
using Nucleo.Windows.Actions;


namespace Nucleo.Windows.UI
{
	public class MenuItem : UIElement, IParentElement, IChildElement, Actions.IActionableElement
	{
		private ICommand _command = null;
		private MenuItemCollection _items = null;
		private MenuItem _parent = null;



		#region " Events "

		public static EventAction ClickEvent = EventAction.Create("Click", typeof(MenuItem));
		public static EventAction CommandEvent = EventAction.Create("Command", typeof(MenuItem));

		#endregion




		#region " Properties "

		/// <summary>
		/// The command that the menu item represents.
		/// </summary>
		public ICommand Command
		{
			get { return _command; }
			set { _command = value; }
		}

		/// <summary>
		/// The value path for the current menu item, which is the path from the root to the current item.
		/// </summary>
		public override ValuePath CurrentPath
		{
			get
			{
				ValuePath path = new ValuePath();
				path.AddValues(this.GetParentNames(this));
				return path;
			}
		}

		/// <summary>
		/// The collection of children that belong to the menu.
		/// </summary>
		public MenuItemCollection Items
		{
			get
			{
				if (_items == null)
					_items = new MenuItemCollection();

				return _items;
			}
		}

		/// <summary>
		/// The parent menu item that is the parent of the current item, or null if it is a root item.
		/// </summary>
		public MenuItem Parent
		{
			get { return _parent; }
		}

		#endregion



		#region " Constructors "
		
		/// <summary>
		/// Passes the menu item parameters to the local fields.
		/// </summary>
		/// <param name="name">The name of the element, sometimes referred to as the key.</param>
		/// <param name="title">The title of the element, which may appear in a title bar or somewhere else.</param>
		/// <param name="parent">The parent menu item that is the parent of the current item, or null if it is a root item.</param>
		public MenuItem(string name, string title, MenuItem parent)
			: base(name, title)
		{
			_parent = parent;
		}

		/// <summary>
		/// Passes the menu item parameters to the local fields.
		/// </summary>
		/// <param name="name">The name of the element, sometimes referred to as the key.</param>
		/// <param name="title">The title of the element, which may appear in a title bar or somewhere else.</param>
		/// <param name="command">The command that the menu item represents.</param>
		/// <param name="parent">The parent menu item that is the parent of the current item, or null if it is a root item.</param>
		public MenuItem(string name, string title, ICommand command, MenuItem parent)
			: this(name, title, parent)
		{
			_command = command;
		}

		#endregion



		#region " Methods "

		public override EventActionCollection GetEvents()
		{
			return new EventActionCollection
			       	{
						MenuItem.ClickEvent
			       	};
		}

		/// <summary>
		/// Gets the names of the parent items from the current item.
		/// </summary>
		/// <param name="item">The item to get the collection of parents from.</param>
		/// <returns>A collection of names.</returns>
		private string[] GetParentNames(MenuItem item)
		{
			List<string> names = new List<string>();

			if (item.Parent != null)
			{
				names.AddRange(this.GetParentNames(item.Parent));
				names.Add(item.Name);
				return names.ToArray();
			}
			else
				return new string[] { item.Name };
		}

		#endregion



		#region " IParentElement Members "

		IElementCollection IParentElement.Items
		{
			get { return this.Items; }
		}

		#endregion



		#region " IChildElement Members "

		UIElement IChildElement.Parent
		{
			get { return this.Parent; }
		}

		#endregion



		#region IActionableElement Members

		/// <summary>
		/// Receives an action, determines whether the action was acceptable, and performs it.
		/// </summary>
		/// <param name="action">The action to perform.</param>
		void Actions.IActionableElement.PerformAction(Actions.IAction action, object target)
		{
			if (action == null)
				throw new ArgumentNullException("action");

			if (action is Actions.ClickAction)
			{
				//If a command is present and available, then execute it
				if (this.Command != null && this.Command.CanExecute())
				{
					this.Command.Execute();
					ApplicationEventsManager.FireEventNotification(ApplicationEventKeys.CommandEventName, this.Parent, this, action);
				}
				else
					ApplicationEventsManager.FireEventNotification(ApplicationEventKeys.ClickEventName, this.Parent, this);
			}
		}

		#endregion
	}
}
