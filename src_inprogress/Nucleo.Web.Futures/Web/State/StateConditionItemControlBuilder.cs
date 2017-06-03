using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web.State
{
	public class StateConditionItemControlBuilder : System.Web.UI.ControlBuilder
	{
		public override Type GetChildControlType(string tagName, System.Collections.IDictionary attribs)
		{
			if (tagName.Contains("StateConditionPropertyItem"))
				return typeof (StateConditionPropertyItem);

			return base.GetChildControlType(tagName, attribs);
		}
	}
}
