using System;
using System.Drawing;
using Nucleo.EventArguments;


namespace Nucleo.Windows.UI
{
	public abstract class ToolbarTextImageItem : ToolbarTextItem
	{
		private ToolbarDisplay _display = ToolbarDisplay.TextOnly;
		private Image _image = null;



		#region " Properties "

		public ToolbarDisplay Display
		{
			get { return _display; }
			set
			{
				if (_display != value)
				{
					ToolbarDisplay oldValue = _display;
					_display = value;

					this.OnPropertyChanged(new PropertyChangedEventArgs("Display", oldValue, _display));
				}
			}
		}

		public Image Image
		{
			get { return _image; }
			set
			{
				if (_image != value)
				{
					Image oldValue = _image;
					_image = value;

					this.OnPropertyChanged(new PropertyChangedEventArgs("Image", oldValue, _image));
				}
			}
		}

		#endregion



		#region " Constructors "

		public ToolbarTextImageItem(string name, string title, Toolbar parent)
			: base(name, title, parent) { }

		public ToolbarTextImageItem(string name, string title, string text, Image image, Toolbar parent)
			: base(name, title, text, parent)
		{
			_image = image;
		}

		#endregion
	}
}
