using System;
using System.Web.UI;


namespace Nucleo.Web.ButtonControls
{
	public class ButtonListControlCollection : ControlCollection
	{
		#region " Properties "

		new public Button this[int index]
		{
			get { return (Button) base[index]; }
		}

		#endregion



		#region " Constructors "

		public ButtonListControlCollection(ButtonList owner)
			: base(owner) { }

		#endregion



		#region " Methods "

		public override void Add(Control child)
		{
			if (!(child is Button))
				throw new InvalidCastException("Only controls of type Button can be used");

			((Button)child).ParentList = (ButtonList)this.Owner;
			base.Add(child);
		}

		public override void AddAt(int index, Control child)
		{
			if (!(child is Button))
				throw new InvalidCastException("Only controls of type Button can be used");

			((Button)child).ParentList = (ButtonList)this.Owner;
			base.AddAt(index, child);
		}

		#endregion
	}
}
