using System;


namespace Nucleo.Windows.UI
{
	public class StatusLabel : ToolbarLabel, IChildElement
	{
		public const string DefaultText = "Ready";



		#region " Constructors "

		public StatusLabel(string name, string title, Toolbar parent)
			: base(name, title, parent)
		{
			base.Text = DefaultText;
		}

		#endregion



		#region IChildElement Members

		UIElement IChildElement.Parent
		{
			get { return this.Parent; }
		}

		#endregion
	}
}
