using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Collections;


namespace Nucleo.Web.Images
{
	/// <summary>
	/// Represents the collection of images.
	/// </summary>
	public class ImageItemCollection : CollectionBase<ImageItem>, IStateManager
	{
		private bool _isTrackingViewState = false;



		#region " Properties "

		/// <summary>
		/// Gets whether the collection is tracking view state.
		/// </summary>
		bool IStateManager.IsTrackingViewState
		{
			get { return _isTrackingViewState; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Loads the view state.
		/// </summary>
		/// <param name="state">The state to load.</param>
		public void LoadViewState(object state)
		{
			if (state == null)
				return;
			this.Clear();

			string[] imageUrls = (string[])state;
			for (int i = 0; i < imageUrls.Length; i++)
				this.Add(new ImageItem(imageUrls[i]));
		}

		/// <summary>
		/// Saves the view state.
		/// </summary>
		/// <returns>The collection of state to save.</returns>
		public object SaveViewState()
		{
			List<string> imageUrls = new List<string>();
			foreach (ImageItem image in this)
			{
				imageUrls.Add(image.ImageUrl);
			}

			return imageUrls.ToArray();
		}

		/// <summary>
		/// Tracks view state.
		/// </summary>
		public void TrackViewState()
		{
			_isTrackingViewState = true;
		}

		#endregion
	}
}
