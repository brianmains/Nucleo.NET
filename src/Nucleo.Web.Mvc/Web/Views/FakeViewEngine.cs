using System;
using System.Web.Mvc;


namespace Nucleo.Web.Views
{
	public class FakeViewEngine : IViewEngine
	{
		private ViewEngineResult _result = null;



		#region " Properties "

		public ViewEngineResult Result
		{
			get { return _result; }
			set { _result = value; }
		}

		#endregion



		#region " Methods "

		public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
		{
			if (this.Result.View != null && this.Result.View is FakePartialView)
			{
				FakePartialView view = (FakePartialView)this.Result.View;
				if (view.Name == null || view.Name == partialViewName)
					return this.Result;
			}
			else
				return this.Result;

			return null;
		}

		public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
		{
			if (this.Result.View != null && this.Result.View is FakeView)
			{
				FakeView view = (FakeView)this.Result.View;
				if (view.Name == null || view.Name == viewName)
					return this.Result;
			}
			else
				return this.Result;

			return null;
		}

		public void ReleaseView(ControllerContext controllerContext, IView view)
		{
			IDisposable viewItem = view as IDisposable;
			if (viewItem != null)
				viewItem.Dispose();
		}

		#endregion
	}
}
