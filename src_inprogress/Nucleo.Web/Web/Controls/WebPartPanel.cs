using System;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace Nucleo.Web.Controls
{
	public class WebPartPanel : Panel, IWebPart
	{
		#region IWebPart Members

		public string CatalogIconImageUrl
		{
			get
			{
				object o = ViewState["CatalogIconImageUrl"];
				return (o == null) ? string.Empty : (string)o;
			}
			set { ViewState["CatalogIconImageUrl"] = value; }
		}

		public string Description
		{
			get
			{
				object o = ViewState["Description"];
				return (o == null) ? string.Empty : (string)o;
			}
			set { ViewState["Description"] = value; }
		}

		public string Subtitle
		{
			get { return string.Empty; }
		}

		public string Title
		{
			get
			{
				object o = ViewState["Title"];
				return (o == null) ? string.Empty : (string)o;
			}
			set { ViewState["Title"] = value; }
		}

		public string TitleIconImageUrl
		{
			get
			{
				object o = ViewState["TitleIconImageUrl"];
				return (o == null) ? string.Empty : (string)o;
			}
			set { ViewState["TitleIconImageUrl"] = value; }
		}

		public string TitleUrl
		{
			get
			{
				object o = ViewState["TitleUrl"];
				return (o == null) ? string.Empty : (string)o;
			}
			set { ViewState["TitleUrl"] = value; }
		}

		#endregion
	}
}
