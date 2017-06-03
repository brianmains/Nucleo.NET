using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.DataMapper
{
	public class FieldMapping
	{
		private string _field = null;
		private IValue _value = null;



		#region " Properties "

		public string Field
		{
			get { return _field; }
		}

		public IValue Value
		{
			get { return _value; }
		}

		#endregion



		#region " Constructors "

		public FieldMapping(string field, IValue value) 
		{
			_field = field;
			_value = value;
		}

		#endregion
	}
}
