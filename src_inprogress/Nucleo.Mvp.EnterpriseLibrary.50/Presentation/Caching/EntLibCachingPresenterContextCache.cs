using Microsoft.Practices.EnterpriseLibrary.Caching;
using Nucleo.Presentation;
using Nucleo.Presentation.Caching;
using System;

namespace Nucleo.Presentation.Caching
{
	public class EntLibCachingPresenterContextCache : IPresenterContextCache
	{
		private ICacheManager _manager = null;

		#region " Constants "

		public const string CacheKey = "PresenterContext";

		#endregion

		#region " Properties "

		public bool CanCache
		{
			get
			{
				return true;
			}
		}

		#endregion

		#region " Constructors "

		public EntLibCachingPresenterContextCache()
		{
			_manager = (new CacheManagerFactory()).CreateDefault();
		}

		public EntLibCachingPresenterContextCache(ICacheManager manager)
		{
			if (manager == null)
				throw new ArgumentNullException("manager");

			_manager = manager;
		}

		#endregion

		#region " Methods "

		public PresenterContext GetCurrentContext()
		{
			return _manager.GetData(CacheKey) as PresenterContext;
		}

		public bool UpdateCurrentContext(PresenterContext context)
		{
			_manager.Add(CacheKey, context);
			return true;
		}
		#endregion
	}
}
