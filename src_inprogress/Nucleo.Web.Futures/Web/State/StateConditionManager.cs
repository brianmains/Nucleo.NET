using System;
using System.Web.UI;

using Nucleo.EventArguments;
using Nucleo.State;


namespace Nucleo.Web.State
{
	public class StateConditionManager : Control
	{
		private StateManager _manager = null;



		#region " Events "

		public event StateConditionManagerConditionResultEventHandler ConditionExecuted;
		public event StateConditionManagerConditionEventHandler ConditionExecuting;

		/// <summary>
		/// Fires whenever the user has to supply a value to be passed to a condition.
		/// </summary>
		public event StateConditionManagerConditionPropertyEventHandler NeedPropertyValue;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets the collection of conditions to process in the page.
		/// </summary>
		public StateConditionItemCollection Conditions
		{
			get { return (StateConditionItemCollection)this.Controls; }
		}

		/// <summary>
		/// Gets or sets whether to execute the conditions on every page loading cycle.
		/// </summary>
		public bool ExecuteOnEveryLoad
		{
			get { return (bool)(ViewState["ExecuteOnEveryLoad"] ?? false); }
			set { ViewState["ExecuteOnEveryLoad"] = value; }
		}

		/// <summary>
		/// Gets the reference to the manager.
		/// </summary>
		private StateManager Manager
		{
			get
			{
				if (_manager == null)
					_manager = StateManager.GetInstance();
				return _manager;
			}
		}

		#endregion



		#region " Methods "

		protected override ControlCollection CreateControlCollection()
		{
			return new StateConditionItemCollection(this);
		}

		/// <summary>
		/// Returns whether the value passed in is not null.
		/// </summary>
		/// <param name="value">The value to evaluate.</param>
		/// <returns>Whether the value is not null.</returns>
		private bool IsNotNull(object value)
		{
			if (value is string)
				return !string.IsNullOrEmpty((string)value);
			else
				return (value != null);
		}

		/// <summary>
		/// Fires the <see cref="ConditionExecuted" /> event.
		/// </summary>
		/// <param name="e">The information about the event.</param>
		protected virtual void OnConditionExecuted(StateConditionManagerConditionResultEventArgs e)
		{
			if (ConditionExecuted != null)
				ConditionExecuted(this, e);
		}

		/// <summary>
		/// Fires the <see cref="ConditionExecuting" /> event.
		/// </summary>
		/// <param name="e">The information about the event.</param>
		protected virtual void OnConditionExecuting(StateConditionManagerConditionEventArgs e)
		{
			if (ConditionExecuting != null)
				ConditionExecuting(this, e);
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			if (!Page.IsPostBack || this.ExecuteOnEveryLoad)
				this.ProcessRules();
		}

		/// <summary>
		/// Fires the <see cref="NeedPropertyValue" /> event, if a handler exists.
		/// </summary>
		/// <param name="e">The details for that event.</param>
		protected virtual void OnNeedPropertyValue(StateConditionManagerConditionPropertyEventArgs e)
		{
			if (NeedPropertyValue != null)
				NeedPropertyValue(this, e);
		}

		private void ProcessCondition(StateConditionItem conditionItem)
		{
			StateCondition condition = this.Manager.GetCondition(conditionItem.ConditionName);
			if (condition == null)
				throw new ArgumentException(string.Format("The condition '{0}' doesn't exist", conditionItem.ConditionName), "conditionItem");

			this.OnConditionExecuting(new StateConditionManagerConditionEventArgs(condition));

			try
			{
				foreach (StateConditionProperty property in condition.Properties)
				{
					if (property.IsStateProperty)
						this.SetPropertyStateValue(property);
					else
					{
						//Try to get the property value from the condition's properties
						StateConditionPropertyItem propertyItem = conditionItem.Properties[property.Name];
						this.SetPropertyValue(propertyItem, property);
					}
				}

				ExecutionResults results = condition.Executor.ExecuteCondition(condition, this);
				this.OnConditionExecuted(new StateConditionManagerConditionResultEventArgs(condition, results));
			}
			catch (Exception ex)
			{
				this.OnConditionExecuted(new StateConditionManagerConditionResultEventArgs(condition,
																						   new ExecutionResults(ex)));
			}
		}

		private void ProcessRules()
		{
			foreach (StateConditionItem condition in this.Conditions)
				this.ProcessCondition(condition);
		}

		/// <summary>
		/// Sets the property's value with the value from the state property.
		/// </summary>
		/// <param name="property">The property to assign a value for.</param>
		private void SetPropertyStateValue(StateConditionProperty property)
		{
			if (property == null)
				throw new ArgumentNullException("property");

			property.Value = this.Manager.GetStateValue(property.Name);
		}

		/// <summary>
		/// Sets the property's value depending on whether the property has already been provided.
		/// </summary>
		/// <param name="propertyItem">The property item definition in the control.</param>
		/// <param name="property">The core property definition.</param>
		private void SetPropertyValue(StateConditionPropertyItem propertyItem, StateConditionProperty property)
		{
			if (property == null)
				throw new ArgumentNullException("property");

			if (propertyItem != null)
			{
				if (propertyItem.PropertyName != property.Name)
					throw new ArgumentException("The property names do not match");
			}

			if (propertyItem != null && this.IsNotNull(propertyItem.Value))
					property.Value = propertyItem.Value;

			//If no value has been assigned, the <see cref="NeedPropertyValue" /> event is fired.
			if (property.Value == null)
			{
				StateConditionManagerConditionPropertyEventArgs args = new StateConditionManagerConditionPropertyEventArgs(
					property.Condition, property);
				this.OnNeedPropertyValue(args);
			}
		}

		#endregion
	}
}
