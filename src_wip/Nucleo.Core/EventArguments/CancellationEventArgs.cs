using System;


namespace Nucleo.EventArguments
{
	[CLSCompliant(true)]
	public class CancellationEventArgs : EventArgs
	{
		private bool _cancel = false;



		#region " Properties "

		public bool Cancel
		{
			get { return _cancel; }
			set { _cancel = value; }
		}

		#endregion



		#region " Constructors "

		public CancellationEventArgs()
			: base() { }

		public CancellationEventArgs(bool cancel)
			: base() 
		{
			this.Cancel = cancel;
		}

		#endregion
	}

	[CLSCompliant(true)]
	public delegate void CancellationEventHandler(object sender, CancellationEventArgs e);
}
