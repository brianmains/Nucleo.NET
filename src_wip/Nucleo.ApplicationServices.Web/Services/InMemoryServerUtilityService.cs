using System;
using System.Collections.Generic;


namespace Nucleo.Services
{
	public class InMemoryServerUtilityService : IServerUtilityService
	{
		#region IServerUtilityService Members

		public string MachineName
		{
			get { throw new NotImplementedException(); }
		}

		public int ScriptTimeout
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public void ClearError()
		{
			throw new NotImplementedException();
		}

		public object CreateObject(string progID)
		{
			throw new NotImplementedException();
		}

		public object CreateObject(Type type)
		{
			throw new NotImplementedException();
		}

		public object CreateObjectFromClsid(string clsid)
		{
			throw new NotImplementedException();
		}

		public void Execute(string path)
		{
			throw new NotImplementedException();
		}

		public void Execute(string path, bool preserveForm)
		{
			throw new NotImplementedException();
		}

		public void Execute(string path, System.IO.TextWriter writer)
		{
			throw new NotImplementedException();
		}

		public void Execute(string path, System.IO.TextWriter writer, bool preserveForm)
		{
			throw new NotImplementedException();
		}

		public void Execute(System.Web.IHttpHandler handler, System.IO.TextWriter writer, bool preserveForm)
		{
			throw new NotImplementedException();
		}

		public Exception GetLastError()
		{
			throw new NotImplementedException();
		}

		public string HtmlDecode(string s)
		{
			throw new NotImplementedException();
		}

		public void HtmlDecode(string s, System.IO.TextWriter output)
		{
			throw new NotImplementedException();
		}

		public string HtmlEncode(string s)
		{
			throw new NotImplementedException();
		}

		public void HtmlEncode(string s, System.IO.TextWriter output)
		{
			throw new NotImplementedException();
		}

		public string MapPath(string path)
		{
			throw new NotImplementedException();
		}

		public void Transfer(string path)
		{
			throw new NotImplementedException();
		}

		public void Transfer(string path, bool preserveForm)
		{
			throw new NotImplementedException();
		}

		public void Transfer(System.Web.IHttpHandler handler, bool preserveForm)
		{
			throw new NotImplementedException();
		}

		public void TransferRequest(string path)
		{
			throw new NotImplementedException();
		}

		public void TransferRequest(string path, bool preserveForm)
		{
			throw new NotImplementedException();
		}

		public void TransferRequest(string path, bool preserveForm, string method, System.Collections.Specialized.NameValueCollection headers)
		{
			throw new NotImplementedException();
		}

		public string UrlDecode(string s)
		{
			throw new NotImplementedException();
		}

		public void UrlDecode(string s, System.IO.TextWriter output)
		{
			throw new NotImplementedException();
		}

		public string UrlEncode(string s)
		{
			throw new NotImplementedException();
		}

		public void UrlEncode(string s, System.IO.TextWriter output)
		{
			throw new NotImplementedException();
		}

		public string UrlPathEncode(string s)
		{
			throw new NotImplementedException();
		}

		public byte[] UrlTokenDecode(string input)
		{
			throw new NotImplementedException();
		}

		public string UrlTokenEncode(byte[] input)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
