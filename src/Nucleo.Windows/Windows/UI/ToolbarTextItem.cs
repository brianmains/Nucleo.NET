using System;
using Nucleo.EventArguments;
using Nucleo.Windows.Application;


namespace Nucleo.Windows.UI
{
	public abstract class ToolbarTextItem : ToolbarItem
	{
		private string _text = string.Empty;



		#region " Properties "

		public string Text
		{
			get { return _text; }
			set
			{
				if (_text != value)
				{
					string _oldValue = _text;
					_text = value;

					this.OnPropertyChanged(new PropertyChangedEventArgs("Text", _oldValue, _text));
				}
			}
		}

		#endregion



		#region " Constructors "

		public ToolbarTextItem(string name, string title, Toolbar parent)
			: base(name, title, parent) { }

		public ToolbarTextItem(string name, string title, string text, Toolbar parent)
			: this(name, title, parent)
		{
			_text = text;
		}

		#endregion
	}
}
