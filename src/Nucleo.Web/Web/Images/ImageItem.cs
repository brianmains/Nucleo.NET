using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Collections;


namespace Nucleo.Web.Images
{
	/// <summary>
	/// Represents an image that's an item within the list.
	/// </summary>
	public class ImageItem
	{
		private string _imageUrl = string.Empty;



		#region " Properties "

		/// <summary>
		/// Gets or sets the URL for the image.
		/// </summary>
		public string ImageUrl
		{
			get { return _imageUrl; }
			set { _imageUrl = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the image with the specified image url.
		/// </summary>
		/// <param name="imageUrl">The URL for the image.</param>
		public ImageItem(string imageUrl)
		{
			_imageUrl = imageUrl;
		}

		#endregion
	}
}
