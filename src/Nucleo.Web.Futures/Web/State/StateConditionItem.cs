using System;
using System.ComponentModel;
using System.Web.UI;


namespace Nucleo.Web.State
{
	[
	ParseChildren(true, "Properties"),
	ControlBuilder(typeof(StateConditionItemControlBuilder))
	]
	public class StateConditionItem : Control
	{
		private StateConditionPropertyItemCollection _properties = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the condition.
		/// </summary>
		public string ConditionName
		{
			get { return (string) ViewState["ConditionName"]; }
			set { ViewState["ConditionName"] = value; }
		}

		/// <summary>
		/// Gets the collection of properties.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerDefaultProperty)
		]
		public StateConditionPropertyItemCollection Properties
		{
			get
			{
				if (_properties == null)
				{
					_properties = new StateConditionPropertyItemCollection(this);
					if (!((IStateManager)_properties).IsTrackingViewState)
						((IStateManager) _properties).TrackViewState();
				}

				return _properties;
			}
		}

		#endregion



		#region " Methods "

		protected override void AddParsedSubObject(object obj)
		{
			if (obj is StateConditionPropertyItem)
				this.Properties.Add((StateConditionPropertyItem) obj);
		}

		#endregion
	}
}
