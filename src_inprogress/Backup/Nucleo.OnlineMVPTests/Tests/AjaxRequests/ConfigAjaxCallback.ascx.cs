using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.Ajax;
using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Tests.AjaxRequests
{
	public class ConfigAjaxCallbackModel
	{

	}

	public interface IConfigAjaxCallbackView : IView<ConfigAjaxCallbackModel>
	{
		
	}

	public class ConfigAjaxCallbackPresenter : BasePresenter<IConfigAjaxCallbackView>
	{
		public static void AddItem(string item)
		{
			List<string> items = HttpContext.Current.Cache.Get("Items") as List<string>;
			if (items == null)
				items = new List<string> { };

			items.Add(item);

			HttpContext.Current.Cache["Items"] = items;
		}

		public static List<string> GetItems()
		{
			List<string> items = HttpContext.Current.Cache.Get("Items") as List<string>;
			if (items != null)
				return items;

			return new List<string> { "A", "B", "C", "D", "E" };
		}

		public static void PresentError()
		{
			throw new Exception();
		}

		public ConfigAjaxCallbackPresenter(IConfigAjaxCallbackView view)
			: base(view) { }
	}

	[PresenterBinding(typeof(ConfigAjaxCallbackPresenter))]
	public partial class ConfigAjaxCallback : BaseViewUserControl<ConfigAjaxCallbackModel>, IConfigAjaxCallbackView
	{
		
	}
}