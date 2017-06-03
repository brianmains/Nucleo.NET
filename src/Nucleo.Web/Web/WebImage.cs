using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web
{
	public class WebImage : IStateManager
	{
		private string _alternateText;
		private bool _isTrackingViewState = false;
		private string _url;



		#region " Properties "

		public string AlternateText
		{
			get { return _alternateText; }
			set { _alternateText = value; }
		}

		bool IStateManager.IsTrackingViewState
		{
			get { return _isTrackingViewState; }
		}

		public string Url
		{
			get { return _url; }
			set { _url = value; }
		}

		#endregion



		#region " Constructors "

		public WebImage()
		{
			_url = string.Empty;
			_alternateText = string.Empty;
		}

		public WebImage(string url)
		{
			_url = url;
			_alternateText = string.Empty;
		}

		public WebImage(string url, string alternateText)
		{
			_url = url;
			_alternateText = alternateText;
		}

		#endregion



		#region " Methods "

		void IStateManager.LoadViewState(object state)
		{
			if (state == null)
				return;

			object[] savedState = (object[])state;
			if (savedState[0] != null)
				_url = (string)savedState[0];
			if (savedState[1] != null)
				_alternateText = (string)savedState[1];
		}

		object IStateManager.SaveViewState()
		{
			object[] state = new object[2];
			state[0] = !string.IsNullOrEmpty(this.Url) ? this.Url : null;
			state[1] = !string.IsNullOrEmpty(this.AlternateText) ? this.AlternateText : null;
			return state;
		}

		public Image ToImage()
		{
			Image image = new Image();
			image.ImageUrl = this.Url;
			if (!string.IsNullOrEmpty(this.AlternateText))
				image.AlternateText = this.AlternateText;
			else
				image.GenerateEmptyAlternateText = true;

			return image;
		}

		void IStateManager.TrackViewState()
		{
			_isTrackingViewState = true;
		}

		#endregion
	}
}
