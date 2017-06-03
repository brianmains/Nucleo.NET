using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.StandardizationControls
{
	public class ContentListItemCollection : ControlCollectionList<ContentListItem>
	{
		#region " Constructors "

		public ContentListItemCollection(ContentList list)
			: base(list) { }

		#endregion
	}
}
