using System;

using Nucleo.Core;
using Nucleo.Presentation;


namespace Nucleo.Presentation.Caching
{
	public class PresenterCacheManager
	{
		private IPresenterContextCache _contextCache = null;



		#region " Properties "

		public bool CanCache
		{
			get
			{
				return (_contextCache != null && _contextCache.CanCache);
			}
		}

		#endregion



		#region " Methods "

		public PresenterContext GetCurrentContext()
		{
			if (!this.CanCache)
				return null;

			return _contextCache.GetCurrentContext();
		}

		public static PresenterCacheManager Create()
		{
			return Create(new PresenterCacheOptions
			{ 
				ContextCache = FrameworkSettings.ContextCache
			});
		}

		public static PresenterCacheManager Create(PresenterCacheOptions options)
		{
			if (options == null)
				throw new ArgumentNullException("options");

			PresenterCacheManager mgr = new PresenterCacheManager();
			mgr._contextCache = options.ContextCache;

			return mgr;
		}

		public static bool HasContextCachingEnabled()
		{
			return (FrameworkSettings.ContextCache != null);
		}

		public bool UpdateCurrentContext(PresenterContext context)
		{
			if (!this.CanCache)
				return false;

			return _contextCache.UpdateCurrentContext(context);
		}
		#endregion
	}
}
