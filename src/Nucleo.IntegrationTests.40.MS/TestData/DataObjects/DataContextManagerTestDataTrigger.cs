using System;
using Nucleo.Orm;
using Nucleo.Orm.Triggers;


namespace Nucleo.TestData.DataObjects
{
	public class DataContextManagerTestDataTrigger : ITrigger
	{
		#region " Methods "

		public bool Fire(object obj, TriggerAction action)
		{
			((DataContextManagerTestData)obj).ModifiedDate = DateTime.Now;
			return true;
		}

		public bool IsForObject(object obj, TriggerAction action)
		{
			return (obj is DataContextManagerTestData);
		}

		#endregion
	}
}
