using System;


namespace Nucleo.Windows
{
	public interface IDatabaseConnectionWindow
	{
		#region " Events "

		event EventHandler Cancelled;
		event EventHandler Submitted;

		#endregion



		#region " Properties "

		string DatabaseName { get; }
		string Description { get; set; }
		bool IsAttached { get; }
		bool IsWindowsAuthentication { get; }
		string ServerName { get; }
		string UserID { get; }
		string Password { get; }
		string Title { get; set; }


		#endregion
	}
}
