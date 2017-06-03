using System;
using Nucleo.EventArguments;
using Nucleo.Windows.UI;

namespace Nucleo.Windows.Application
{
	public abstract class BaseApplicationController
	{
		private ApplicationModel _application = null;



		#region " Properties "

		/// <summary>
		/// An instance of the application model.
		/// </summary>
		public ApplicationModel Application
		{
			get { return _application; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Assigns the application model object directly, and taps into required events.
		/// </summary>
		/// <param name="application">The application to store a reference to.</param>
		public BaseApplicationController(ApplicationModel application)
		{
			_application = application;
			ApplicationEventsManager.EventTriggered += ApplicationEventsManager_EventTriggered;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a document window's window UI object.
		/// </summary>
		/// <param name="index">The index of the document window in the collection.</param>
		/// <param name="window">The window object to create the windows UI for.</param>
		protected abstract void AddDocumentWindow(int index, DocumentWindow window);

		/// <summary>
		/// Uses the abstract methods to add a specific item to the controller.
		/// </summary>
		/// <param name="index">The index position to add the item at.</param>
		/// <param name="item">The item to add.</param>
		/// <remarks>If the index value is below zero, it is reset to the last item in the index, so that it appears at the end.  This requires some extra work to perform the calculation.  If the item to add is null, an exception occurs.</remarks>
		/// <exception cref="ArgumentNullException">Occurs when the item parameter is null.</exception>
		private void AddItem(int index, UIElement item)
		{
			if (item == null)
				throw new ArgumentNullException("item");
			int count = 0;

			if (item is DocumentWindow)
			{
				count = this.Application.DocumentWindows.Count - 1;
				if (count < 0) count = 0;

				AddDocumentWindow(count, (DocumentWindow)item);
			}
			else if (item is ToolWindow)
			{
				ToolWindow window = (ToolWindow)item;
				count = this.Application.ToolWindows.GetCount(window.Location) - 1;
				if (count < 0) count = 0;
								
				AddToolWindow(count, window);
			}
			else if (item is MenuItem)
			{
				MenuItem menu = item as MenuItem;
				if (menu.Parent != null)
					count = menu.Parent.Items.Count - 1;
				else
					count = this.Application.Menus.Count - 1;
				if (count < 0) count = 0;

				AddMenuItem(count, (MenuItem)item);
			}
			else if (item is Toolbar)
			{
				count = this.Application.Toolbars.Count - 1;
				if (count < 0) count = 0;

				AddToolbar(count, (Toolbar)item);
			}
			else if (item is ToolbarItem)
			{
				ToolbarItem toolbarItem = (ToolbarItem)item;
				count = toolbarItem.Parent.Items.Count - 1;
				if (count < 0) count = 0;
				
				AddToolbarItem(count, (ToolbarItem)item);
			}
			else
				throw new NotImplementedException(string.Format("The type '{0}' has not been configured in the controller", item.GetType().Name));
		}

		protected abstract void AddMenuItem(int index, MenuItem menu);

		protected abstract void AddToolbar(int index, Toolbar toolbar);

		protected abstract void AddToolbarItem(int index, ToolbarItem toolbarItem);

		protected abstract void AddToolWindow(int index, ToolWindow window);

		/// <summary>
		/// Gets a common control reference for a windows forms control to add to the interface.
		/// </summary>
		/// <param name="originalReference">The original reference to verify.</param>
		/// <returns>A commonly used windows forms control.</returns>
		protected virtual System.Windows.Forms.Control GetControlReference(object originalReference)
		{
			return ControlUtility.GetWindowsControlReference(originalReference);
		}

		/// <summary>
		/// Handles performing some action raised by an element.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="action"></param>
		protected virtual bool HandleAction(Actions.IActionableElement element, Actions.IAction action)
		{
			if (element is MenuItem && action is Actions.ClickAction)
			{
				MenuItem item = (MenuItem)element;
				if (item.Command != null && item.Command.CanExecute())
				{
					item.Command.Execute();
					return true;
				}
			}

			return false;
		}

		protected abstract void RemoveDocumentWindow(DocumentWindow window);

		/// <summary>
		/// Handles calling the method to remove the element item from the respective collection.
		/// </summary>
		/// <param name="element">The element to remove.</param>
		private void RemoveItem(UIElement element)
		{
			if (element is DocumentWindow)
				RemoveDocumentWindow((DocumentWindow)element);
			else if (element is ToolWindow)
				RemoveToolWindow((ToolWindow)element);
			else if (element is Toolbar)
				RemoveToolbar((Toolbar)element);
			else if (element is MenuItem)
				RemoveMenuItem((MenuItem)element);
			else if (element is ToolbarItem)
				RemoveToolbarItem((ToolbarItem)element);
			else
				throw new NotImplementedException(string.Format("The type '{0}' has not been configured in the controller", element.GetType().Name));
		}

		protected abstract void RemoveMenuItem(MenuItem menu);

		protected abstract void RemoveToolbar(Toolbar toolbar);

		protected abstract void RemoveToolbarItem(ToolbarItem toolbarItem);

		protected abstract void RemoveToolWindow(ToolWindow window);

		#endregion



		#region " Event Handlers "

		/// <summary>
		/// Handled the event trigger event of the <see cref="ApplicationEventsManager" /> class.  This is the key to listening to events that occur in the object model, and must trigger appropriate actions within the controller.
		/// </summary>
		/// <param name="sender">The object that is raising the event.</param>
		/// <param name="e">The details regarding the event that was triggered.</param>
		void ApplicationEventsManager_EventTriggered(object sender, Nucleo.EventArguments.ApplicationEventEventArgs e)
		{
			IElementCollection collection = e.SourceObject as IElementCollection;

			if (e.Name == ApplicationEventKeys.AddedEventName)
				this.AddItem(-1, (UIElement)e.TargetObject);
			else if (e.Name == ApplicationEventKeys.InsertedEventName)
			{
				if (e.Index < 0)
					throw new ArgumentOutOfRangeException("e.Index");

				this.AddItem(e.Index, (UIElement)e.TargetObject);
			}
			else if (e.Name == ApplicationEventKeys.RemovedEventName)
				this.RemoveItem((UIElement)e.TargetObject);

			if (e.Action != null)
				this.HandleAction((Actions.IActionableElement)e.TargetObject, e.Action);
		}

		#endregion
	}
}