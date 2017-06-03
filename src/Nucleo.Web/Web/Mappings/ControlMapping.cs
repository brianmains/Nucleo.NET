using System;
using System.Collections.Generic;


namespace Nucleo.Web.Mappings
{
	public class ControlMapping
	{
		private string _controlID;
		private string _objectPropertyName;



		#region " Properties "

		public string ControlID
		{
			get { return _controlID; }
			set { _controlID = value; }
		}

		public string ObjectPropertyName
		{
			get { return _objectPropertyName; }
			set { _objectPropertyName = value; }
		}

		#endregion



		#region " Constructors "

		public ControlMapping() { }

		public ControlMapping(string controlID, string objectPropertyName)
		{
			_controlID = controlID;
			_objectPropertyName = objectPropertyName;
		}

		#endregion
	}
}
