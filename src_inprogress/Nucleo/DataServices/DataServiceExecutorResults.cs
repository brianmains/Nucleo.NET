using System;
using System.Collections.Generic;

using Nucleo.DataServices.Results;


namespace Nucleo.DataServices
{
	public class DataServiceExecutorResults
	{
		private IList<IDataServiceResult> _results = null;



		#region " Properties "

		private IList<IDataServiceResult> Results
		{
			get
			{
				if (_results == null)
					_results = new List<IDataServiceResult>();

				return _results;
			}
		}

		#endregion



		#region " Constructors "

		public DataServiceExecutorResults(IList<IDataServiceResult> results)
		{
			_results = results;
		}

		#endregion



		#region " Methods "

		public IList<IDataServiceResult> GetResults()
		{
			return _results;
		}

		#endregion
	}
}
