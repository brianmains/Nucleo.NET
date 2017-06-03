using System;
using System.Web.UI;


namespace Nucleo.Web.State
{
	public class StateConditionPropertyItem : IStateManager
	{
		private StateConditionItem _condition = null;
		private bool _isTrackingViewState = false;
		private string _propertyName = null;
		private object _value = null;



		#region " Properties "

		public StateConditionItem Condition
		{
			get { return _condition; }
			internal set { _condition = value; }
		}

		bool IStateManager.IsTrackingViewState
		{
			get { return _isTrackingViewState; }
		}

		/// <summary>
		/// Gets the name of the property for a specified condition.
		/// </summary>
		public string PropertyName
		{
			get { return _propertyName; }
			set { _propertyName = value; }
		}

		/// <summary>
		/// Gets the valeu for the property.
		/// </summary>
		public object Value
		{
			get { return _value; }
			set { _value = value; }
		}

		#endregion



		#region " Methods "

		void IStateManager.LoadViewState(object state)
		{
			if (state == null)
				return;

			Pair pair = (Pair)state;
			this.PropertyName = (string)pair.First;
			this.Value = pair.Second;
		}

		object IStateManager.SaveViewState()
		{
			return new Pair(this.PropertyName, this.Value);
		}

		void IStateManager.TrackViewState()
		{
			_isTrackingViewState = true;
		}

		#endregion
	}
}
