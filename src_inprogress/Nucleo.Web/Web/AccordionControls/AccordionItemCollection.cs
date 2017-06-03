using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nucleo.Collections;


namespace Nucleo.Web.AccordionControls
{
	public class AccordionItemCollection : ControlCollection
	{
		#region " Properties "

		new public AccordionItem this[int index]
		{
			get { return (AccordionItem)base[index]; }
		}

		#endregion



		#region " Constructors "

		public AccordionItemCollection(Accordion owner)
			: base(owner) { }

		#endregion



		#region " Methods "

		public override void Add(Control child)
		{
			if (!(child is AccordionItem))
				throw new InvalidCastException("Only accordion items are allowed.");

			base.Add(child);
		}

		public override void AddAt(int index, Control child)
		{
			if (!(child is AccordionItem))
				throw new InvalidCastException("Only accordion items are allowed.");

			base.AddAt(index, child);
		}

		public void ClearSelection()
		{
			foreach (AccordionItem item in this)
				item.IsSelected = false;
		}

		#endregion
	}
}
