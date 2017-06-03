using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.Commands
{
	public static class EditCommands
	{
		#region " Properties "

		public static CopyCommand Copy
		{
			get { return new CopyCommand(); }
		}

		public static CutCommand Cut
		{
			get { return new CutCommand(); }
		}

		public static PasteCommand Paste
		{
			get { return new PasteCommand(); }
		}

		#endregion
	}
}
