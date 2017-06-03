using Nucleo.Presentation;
using Nucleo.Presentation.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Presentation.Caching
{
	public class PresenterCacheOptions
	{
		private IPresenterContextCache _contextCache = null;

		#region " Properties "

		/// <summary>
		/// Gets or sets the context cache to use; null can be passed.
		/// </summary>
		public IPresenterContextCache ContextCache
		{
			get
			{
				return _contextCache;
			}
			set
			{
				_contextCache = value;
			}
		}
		#endregion
	}
}
