using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventsManagement;
using Nucleo.EventsManagement.Listeners;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;

using Nucleo.Models;
using Nucleo.Models.Cache;


namespace Nucleo.Demos.MvpSamples.ModelInjectionSamples
{
	public class DemoModelInjectionCache : IModelInjectionCache
	{
		public CacheInformation GetCacheAvailability(ModelInspectorOptions options)
		{
			var ctx = HttpContext.Current;
			if (ctx == null)
				return new CacheInformation { CanCache = false };

			return new CacheInformation { CanCache = true, Key = options.Model.GetType().FullName + "$$" + options.Property.Name };
		}

		public ModelCacheResults GetFromCache(ModelInspectorOptions metadata, string key)
		{
			var ctx = HttpContext.Current;

			return new ModelCacheResults(true, true);
		}

		public void SaveToCache(ModelInspectorOptions metadata, string key, object value)
		{
			var ctx = HttpContext.Current;

		}
	}

	public class CachingModel
	{

	}

	public interface ICachingView : IView<CachingModel>
	{

	}

	public class CachingPresenter : BasePresenter<ICachingView>
	{
		public CachingPresenter(ICachingView view)
			: base(view)
		{

		}



	}

	[PresenterBinding(typeof(CachingPresenter))]
	public partial class Caching : DemoViewPage<CachingModel>, ICachingView
	{
		public override string Description
		{
			get { return "The model injection manager can use caching by using an IModelInjectionCache instance."; }
		}
	}
}