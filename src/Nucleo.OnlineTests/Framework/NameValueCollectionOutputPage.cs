using System;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Framework
{
	public abstract class NameValueCollectionOutputPage : Nucleo.Framework.TestPage
	{
		#region " Properties "

		public abstract Label OutputLabel { get; }

		#endregion



		#region " Methods "

		protected abstract NameValueCollection GetCollection();

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			var collection = this.GetCollection();

			for (int index = 0; index < collection.Count; index++)
			{
				this.OutputLabel.Text += string.Format("<div>{0}={1}</div>",
					collection.Keys[index], collection[index]);
			}
		}

		#endregion
	}
}
