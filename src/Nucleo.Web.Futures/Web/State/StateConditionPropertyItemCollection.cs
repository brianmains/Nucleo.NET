using System;
using System.Collections.Generic;
using System.Web.UI;
using Nucleo.Collections;


namespace Nucleo.Web.State
{
	public class StateConditionPropertyItemCollection : SimpleCollection<StateConditionPropertyItem>, IStateManager
	{
		private StateConditionItem _condition = null;
		private bool _isTrackingViewState = false;



		#region " Properties "

		bool IStateManager.IsTrackingViewState
		{
			get { return _isTrackingViewState; }
		}

		/// <summary>
		/// Gets a property by its name.
		/// </summary>
		/// <param name="name">The name of the property.</param>
		/// <returns>The reference to the property, or null if not found.</returns>
		public StateConditionPropertyItem this[string name]
		{
			get
			{
				foreach (StateConditionPropertyItem item in this)
				{
					if (item.PropertyName == name)
						return item;
				}

				return null;
			}
		}

		#endregion



		#region " Constructors "

		public StateConditionPropertyItemCollection(StateConditionItem condition)
		{
			if (condition == null)
				throw new ArgumentNullException("condition");

			_condition = condition;
		}

		#endregion



		#region " Methods "

		public override void Add(StateConditionPropertyItem item)
		{
			item.Condition = _condition;
			base.Add(item);
		}

		#endregion



		#region IStateManager Members

		void IStateManager.LoadViewState(object state)
		{
			if (state == null)
				return;

			object[] inputList = (object[]) state;

			foreach (object inputItem in inputList)
			{
				StateConditionPropertyItem property = new StateConditionPropertyItem();
				((IStateManager) property).LoadViewState(inputItem);
				this.Add(property);
			}
		}

		object IStateManager.SaveViewState()
		{
			if (this.Count == 0)
				return null;

			List<object> outputList = new List<object>();

			foreach (StateConditionPropertyItem property in this)
				outputList.Add(((IStateManager) property).SaveViewState());

			return outputList;
		}

		void IStateManager.TrackViewState()
		{
			_isTrackingViewState = true;
		}

		#endregion
	}
}
