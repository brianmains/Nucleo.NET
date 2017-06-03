using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.DataMapper
{
	public class ListValue : IRangeValue
	{
		private IEnumerable _list = null;



		#region " Properties "

		/// <summary>
		/// Gets the list of items.
		/// </summary>
		public IEnumerable List
		{
			get { return _list; }
		}

		#endregion



		#region " Constructors "

		public ListValue(IEnumerable list)
		{
			_list = list;
		}

		#endregion



		#region " Methods "

		public object GetValue()
		{
			return (object)this.GetValues();
		}

		public object[] GetValues()
		{
			List<object> values = new List<object>();
			IEnumerator enumerator = this.List.GetEnumerator();

			while (enumerator.MoveNext())
				values.Add(enumerator.Current);

			return values.ToArray();
		}

		#endregion
	}
}
