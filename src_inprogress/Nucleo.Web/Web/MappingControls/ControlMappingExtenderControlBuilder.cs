using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web.MappingControls
{
	public class ControlMappingExtenderControlBuilder : ControlBuilder
	{
		public override Type GetChildControlType(string tagName, System.Collections.IDictionary attribs)
		{
			//if (tagName == "Operations")
			//    return typeof(ControlMappingExtenderOperationCollection);
			//else 
			if (tagName.EndsWith("ControlMappingExtenderOperation"))
				return typeof(ControlMappingExtenderOperation);
			else
				return base.GetChildControlType(tagName, attribs);
		}
	}
}
