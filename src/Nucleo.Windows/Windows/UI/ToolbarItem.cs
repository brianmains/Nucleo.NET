using System;
using Nucleo.EventArguments;
using Nucleo.Windows.Application;


namespace Nucleo.Windows.UI
{
	public abstract class ToolbarItem : UIElement, IChildElement, Actions.IActionableElement
	{
		private Toolbar _parent = null;



		#region " Properties "

		public override ValuePath CurrentPath
		{
			get { return new ValuePath(this.Parent.Name, this.Name); }
		}

		public Toolbar Parent
		{
			get { return _parent; }
		}

		#endregion



		#region " Constructors "

		public ToolbarItem(string name, string title, Toolbar parent)
			: base(name, title)
		{
			_parent = parent;
		}

		#endregion



		#region IChildElement Members

		UIElement IChildElement.Parent
		{
			get { return this.Parent; }
		}

		#endregion



		#region IActionableElement Members

		void Actions.IActionableElement.PerformAction(Actions.IAction action, object target)
		{
			if (action == null)
				throw new ArgumentNullException("action");

			if (action is Actions.ClickAction)
				ApplicationEventsManager.FireEventNotification(ApplicationEventKeys.ClickEventName, this, target);
		}

		#endregion
	}
}
