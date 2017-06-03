using System;
using System.Web;
using System.Web.UI;

using Nucleo.State;
using Nucleo.Context;
using Nucleo.Web.Context;
using Nucleo.Web.Core;


namespace Nucleo.Web.State
{
	public class SessionStateValuesProvider : StateValuesProvider
	{
		#region " Methods "

		private string GetRegionKey(StateProperty property, string regionName)
		{
			return regionName + "_" + property.Name;
		}

		public override object GetRegionValue(StateUser user, StateProperty property, string regionName)
		{
			object value = WebContext.GetCurrent().Session.Get(GetRegionKey(property, regionName));

			if (value != null)
				return value;
			else
				return property.DefaultValue;
		}

		public override object GetValue(StateUser user, StateProperty property)
		{
			object value = WebContext.GetCurrent().Session.Get(property.Name);
			
			if (value != null)
				return value;
			else
				return property.DefaultValue;
		}

		public override bool SetRegionValue(StateUser user, StateProperty property, string regionName, object propertyValue)
		{
			object value = WebContext.GetCurrent().Session.Get(GetRegionKey(property, regionName));

			if (value != propertyValue)
			{
				WebContext.GetCurrent().Session[GetRegionKey(property, regionName)] = propertyValue;
				return true;
			}
			else
				return false;		
		}

		public override bool SetValue(StateUser user, StateProperty property, object propertyValue)
		{
			object value = WebContext.GetCurrent().Session.Get(property.Name);

			if (value != propertyValue)
			{
				WebContext.GetCurrent().Session[property.Name] = propertyValue;
				return true;
			}
			else
				return false;
		}

		#endregion
	}
}
