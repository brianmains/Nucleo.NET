using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Context;
using Nucleo.Web.Context.Services;
using Nucleo.Framework;


namespace Nucleo.Web.Context
{
	public partial class ServerVariablesServiceFirstLook : NameValueCollectionOutputPage
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
			var service = ApplicationContext.GetCurrent().GetService<IServerVariablesService>();
			return service.GetAll();
		}

		#endregion
	}
}
