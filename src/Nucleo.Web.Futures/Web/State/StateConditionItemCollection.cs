using System;
using System.Web.UI;


namespace Nucleo.Web.State
{
	public class StateConditionItemCollection : ControlCollection
	{
		#region " Constructors "

		public StateConditionItemCollection(Control owner) 
			: base(owner) { }

		#endregion



		#region " Methods "

		public override void Add(Control child)
		{
			if (!(child is StateConditionItem))
				throw new InvalidCastException("Only state condition controls can be added to the collection");

			base.Add(child);
		}

		public override void AddAt(int index, Control child)
		{
			if (!(child is StateConditionItem))
				throw new InvalidCastException("Only state condition controls can be added to the collection");

			base.AddAt(index, child);
		}

		public override void Remove(Control value)
		{
			if (!(value is StateConditionItem))
				throw new InvalidCastException("Only state condition controls can be added to the collection");

			base.Remove(value);
		}

		#endregion
	}
}
