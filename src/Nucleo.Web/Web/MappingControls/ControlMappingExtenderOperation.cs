using System;
using System.ComponentModel;
using System.Collections.Generic;


namespace Nucleo.Web.MappingControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class ControlMappingExtenderOperation
	{
		private string _operationKey = null;
		private int _order = 0;

		

		#region " Properties "

		[NotifyParentProperty(true)]
		public string OperationKey
		{
			get { return _operationKey; }
			set { _operationKey = value; }
		}

		[NotifyParentProperty(true)]
		public int Order
		{
			get { return _order; }
			set { _order = value; }
		}

		#endregion



		#region " Constructors "

		public ControlMappingExtenderOperation() { }

		public ControlMappingExtenderOperation(string operationKey, int order)
		{
			_operationKey = operationKey;
			_order = order;
		}

		#endregion
	}
}
