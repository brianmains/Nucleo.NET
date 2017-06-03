using System;
using System.Drawing;
using System.Windows.Forms;


namespace Nucleo.Windows.Utilities
{
	/// <summary>
	/// Based upon an article I found, I created a utility that converts content/string alignments from/to each other.
	/// </summary>
	/// <remarks>See http://msdn2.microsoft.com/en-us/library/649xahhe.aspx for the idea of this utility.</remarks>
	public static class AlignmentUtility
	{
		/// <summary>
		/// Gets a content alignment based upon a string alignment, using the Middle vertical setting as the default.
		/// </summary>
		/// <param name="alignment">The alignment to convert.</param>
		/// <returns>A content alignment with a middle vertical setting, and the appropriate horizontal setting.</returns>
		public static ContentAlignment GetContentAlignment(StringAlignment alignment)
		{
			if (alignment == StringAlignment.Center)
				return ContentAlignment.MiddleCenter;
			else if (alignment == StringAlignment.Near)
				return ContentAlignment.MiddleLeft;
			else if (alignment == StringAlignment.Far)
				return ContentAlignment.MiddleRight;
			else
				throw new NotImplementedException();
		}

		/// <summary>
		/// Gets a string alignment based upon the content alignment, which leaves out the vertical setting.
		/// </summary>
		/// <param name="alignment">The alignment to convert.</param>
		/// <returns>A string alignment with the horizontal setting.</returns>
		public static StringAlignment GetStringAlignment(ContentAlignment alignment)
		{
			if (alignment == ContentAlignment.BottomCenter ||
				alignment == ContentAlignment.MiddleCenter ||
				alignment == ContentAlignment.TopCenter)
				return StringAlignment.Center;
			else if (alignment == ContentAlignment.BottomLeft ||
				alignment == ContentAlignment.MiddleLeft ||
				alignment == ContentAlignment.TopLeft)
				return StringAlignment.Near;
			else if (alignment == ContentAlignment.BottomRight ||
				alignment == ContentAlignment.MiddleRight ||
				alignment == ContentAlignment.TopRight)
				return StringAlignment.Far;
			else
				throw new NotImplementedException();
		}
	}
}
