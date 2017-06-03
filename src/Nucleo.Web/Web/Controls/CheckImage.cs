using System;
using System.Web.UI;


namespace Nucleo.Web.Controls
{
	public class CheckImage
	{
		private bool? _associatedValue = null;
		private string _disabledImageUrl = null;
		private string _imageUrl = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the associated value for the check image.
		/// </summary>
		public bool? AssociatedValue
		{
			get { return _associatedValue; }
		}

		/// <summary>
		/// Gets or sets the image url when the check image is in a disabled state.
		/// </summary>
		[UrlProperty]
		public string DisabledImageUrl
		{
			get { return _disabledImageUrl; }
			set { _disabledImageUrl = value; }
		}

		/// <summary>
		/// Gets or sets the image url when the check image is in normal state.
		/// </summary>
		[UrlProperty]
		public string ImageUrl
		{
			get { return _imageUrl; }
			set { _imageUrl = value; }
		}

		#endregion



		#region " Constructors "

		public CheckImage(bool? associatedValue)
		{
			_associatedValue = associatedValue;
		}

		public CheckImage(string imageUrl, string disabledImageUrl, bool? associatedValue)
			: this(associatedValue)
		{
			_imageUrl = imageUrl;
			_disabledImageUrl = disabledImageUrl;
		}

		#endregion



		#region " Methods "

		public void CopyFrom(CheckImage image)
		{
			_imageUrl = image.ImageUrl;
			_disabledImageUrl = image.DisabledImageUrl;
			_associatedValue = image.AssociatedValue;
			
		}

		#endregion
	}
}
