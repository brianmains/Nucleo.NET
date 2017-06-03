using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Tests.DataSource
{
	public class PagesFirstLookPresenter : BasePresenter
	{
		public PagesFirstLookPresenter(IView view)
			: base(view) { }
	}


	public partial class PagesFirstLook : BaseViewPage
	{
		protected override IPresenter CreatePresenter()
		{
			return new PagesFirstLookPresenter(this);
		}

		public System.Collections.IEnumerable GetData()
		{
			return new[]
			{
				new { Key = 1, Name = "A" },
				new { Key = 2, Name = "B" },
				new { Key = 3, Name = "C" },
				new { Key = 4, Name = "D" }
			};
		}
	}
}