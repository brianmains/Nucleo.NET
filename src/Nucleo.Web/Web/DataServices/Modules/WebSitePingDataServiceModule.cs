using System;
using System.Text;
using System.Collections.Generic;
using System.Net.NetworkInformation;

using Nucleo.DataServices;
using Nucleo.DataServices.Modules;
using Nucleo.DataServices.Results;


namespace Nucleo.Web.DataServices.Modules
{
	public class WebSitePingDataServiceModule : BaseDataServiceModule
	{
		private int _retryCount = 1;
		private int _timeout = 120;



		#region " Properties "

		/// <summary>
		/// Gets the display name for the module.
		/// </summary>
		public override string DisplayName
		{
			get { return "Web Site Ping Check"; }
		}

		/// <summary>
		/// Gets the total number of retries for the ping that should occur before giving in.
		/// </summary>
		public int RetryCount
		{
			get { return _retryCount; }
		}

		/// <summary>
		/// Gets the total number of time that a ping should take to expect information back from the server.
		/// </summary>
		public int Timeout
		{
			get { return _timeout; }
		}

		#endregion



		#region " Constructors "

		public WebSitePingDataServiceModule() : base() { }

		#endregion



		#region " Methods "

		public override IDataServiceResult Execute()
		{
			ICollection<string> keys = this.Parameters.Keys;
			IDataServiceResult result = null;
			int urlCount = 0;

			foreach (string key in keys)
			{
				if (string.Compare(key, "retry", StringComparison.CurrentCultureIgnoreCase) == 0)
					_retryCount = Convert.ToInt32(this.Parameters[key]);
				else if (string.Compare(key, "retrycount", StringComparison.CurrentCultureIgnoreCase) == 0)
					_retryCount = Convert.ToInt32(this.Parameters[key]);
				else if (string.Compare(key, "timeout", StringComparison.CurrentCultureIgnoreCase) == 0)
					_timeout = Convert.ToInt32(this.Parameters[key]);				
				else
				{
					object value = this.Parameters[key];
					if (!(value is string))
						continue;

					string url = (string)value;
					if (url.StartsWith("http:") || url.StartsWith("https:"))
					{
						urlCount++;

						if (!this.PingResource(url, ref result))
							return result;
					}
				}
			}

			return new SuccessDataServiceResult(this, "All " + urlCount.ToString() +" of the URL's pinged were able to communicate with the server.");
		}

		private bool PingResource(string url, ref IDataServiceResult result)
		{
			using (Ping ping = new Ping())
			{
				PingOptions options = new PingOptions();

				// Create a buffer of 32 bytes of data to be transmitted.
				string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
				byte[] buffer = Encoding.ASCII.GetBytes(data);

				IPStatus lastReplyStatus = IPStatus.Success;

				for (int index = 1, len = this.RetryCount; index < this.RetryCount; index++)
				{
					PingReply reply = ping.Send(url, this.Timeout, buffer, new PingOptions { DontFragment = true });

					if (reply.Status == IPStatus.Success)
					{
						result = null;
						return true;
					}
				}

				result = new FailureDataServiceResult(this, string.Format("The pinging of the web site '{0}' failed, returning the following error code: {1}", url, lastReplyStatus));
				return false;
			}
		}

		#endregion
	}
}
