using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Context;
using Nucleo.Framework;
using Nucleo.Web.Context.Services;


namespace Nucleo.Web.Context
{
	public partial class QuerystringServiceFirstLook : NameValueCollectionOutputPage
	{
		#region " Properties "

		public override Label OutputLabel
		{
			get { return this.lblOutput; }
		}

		#endregion



		#region " Methods "

		protected override NameValueCollection GetCollection()
		{
			var service = ApplicationContext.GetCurrent().GetService<IQuerystringService>();
			return service.GetAll();
		}

		#endregion
	}
}
