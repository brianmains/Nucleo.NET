using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.DataFields
{
	public class ImageRepresentationField : BaseSingleDataField
	{
		#region " Properties "

		public string DataImageUrlField
		{
			get
			{
				object o = ViewState["DataImageUrlField"];
				return (o == null) ? string.Empty : (string)o;
			}
			set { ViewState["DataImageUrlField"] = value; }
		}

		public string DataUnderlyingValueField
		{
			get
			{
				object o = ViewState["DataUnderlyingValueField"];
				return (o == null) ? string.Empty : (string)o;
			}
			set { ViewState["DataUnderlyingValueField"] = value; }
		}

		#endregion



		#region " Methods "

		public override void BindEditControl(object control, bool insertMode)
		{
			
		}

		protected override string GetDataItemFieldName(DataControlRowState state)
		{
			return null;
		}

		public override string GetEditControlValue(TableCell cell)
		{
			return null;
		}

		public override Control SetupEditControl()
		{
			return null;
		}

		#endregion
	}
}
