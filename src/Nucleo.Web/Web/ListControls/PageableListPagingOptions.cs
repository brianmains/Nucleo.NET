using System;
using System.Collections.Generic;


namespace Nucleo.Web.ListControls
{
	/// <summary>
	/// Represents the paging options for paging throughout the list.
	/// </summary>
	public class PageableListPagingOptions
	{
		private string _downImageUrl = null;
		private string _leftImageUrl = null;
		private string _rightImageUrl = null;
		private string _upImageUrl = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the image url to direct the list downward, for vertical lists.
		/// </summary>
		public string DownImageUrl
		{
			get { return _downImageUrl; }
			set { _downImageUrl = value; }
		}

		/// <summary>
		/// Gets or sets the image url to direct the list to the left, for horizontal lists.
		/// </summary>
		public string LeftImageUrl
		{
			get { return _leftImageUrl; }
			set { _leftImageUrl = value; }
		}

		/// <summary>
		/// Gets or sets the image url to direct the list to the right, for horizontal lists.
		/// </summary>
		public string RightImageUrl
		{
			get { return _rightImageUrl; }
			set { _rightImageUrl = value; }
		}

		/// <summary>
		/// Gets or sets the image url to direct the list upward, for vertical lists.
		/// </summary>
		public string UpImageUrl
		{
			get { return _upImageUrl; }
			set { _upImageUrl = value; }
		}

		#endregion



		#region " Constructors "

		public PageableListPagingOptions() { }

		#endregion
	}
}
