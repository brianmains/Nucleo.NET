using System;
using System.Web;
using System.IO;
using System.Collections.Specialized;


namespace Nucleo.Services
{
	public class WebServerUtilityService : IServerUtilityService
	{
		private HttpContextBase _context = null;



		#region " Properties "

		private HttpContextBase Context
		{
			get { return _context; }
		}

		public string MachineName
		{
			get { return this.Context.Server.MachineName; }
		}

		public int ScriptTimeout
		{
			get { return this.Context.Server.ScriptTimeout; }
			set { this.Context.Server.ScriptTimeout = value; }
		}

		#endregion



		#region " Constructors "

		public WebServerUtilityService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebServerUtilityService(HttpContextBase context)
		{
			_context = context;
		}

		#endregion



		#region " Methods "

		public void ClearError()
		{
			this.Context.Server.ClearError();
		}

		public object CreateObject(string progID)
		{
			return this.Context.Server.CreateObject(progID);
		}

		public object CreateObject(Type type)
		{
			return this.Context.Server.CreateObject(type);
		}

		public object CreateObjectFromClsid(string clsid)
		{
			return this.Context.Server.CreateObjectFromClsid(clsid);
		}

		public void Execute(string path)
		{
			this.Context.Server.Execute(path);
		}

		public void Execute(string path, bool preserveForm)
		{
			this.Context.Server.Execute(path, preserveForm);
		}

		public void Execute(string path, System.IO.TextWriter writer)
		{
			this.Context.Server.Execute(path, writer);
		}

		public void Execute(string path, System.IO.TextWriter writer, bool preserveForm)
		{
			this.Context.Server.Execute(path, writer, preserveForm);
		}

		public void Execute(System.Web.IHttpHandler handler, System.IO.TextWriter writer, bool preserveForm)
		{
			this.Context.Server.Execute(handler, writer, preserveForm);
		}

		public Exception GetLastError()
		{
			return this.Context.Server.GetLastError();
		}

		public string HtmlDecode(string s)
		{
			return this.Context.Server.HtmlDecode(s);
		}

		public void HtmlDecode(string s, System.IO.TextWriter output)
		{
			this.Context.Server.HtmlDecode(s, output);
		}

		public string HtmlEncode(string s)
		{
			return this.Context.Server.HtmlEncode(s);
		}

		public void HtmlEncode(string s, System.IO.TextWriter output)
		{
			this.Context.Server.HtmlEncode(s, output);
		}

		public string MapPath(string path)
		{
			return this.Context.Server.MapPath(path);
		}

		public void Transfer(string path)
		{
			this.Context.Server.Transfer(path);
		}

		public void Transfer(string path, bool preserveForm)
		{
			this.Context.Server.Transfer(path, preserveForm);
		}

		public void Transfer(System.Web.IHttpHandler handler, bool preserveForm)
		{
			this.Context.Server.Transfer(handler, preserveForm);
		}

		public void TransferRequest(string path)
		{
			this.Context.Server.TransferRequest(path);
		}

		public void TransferRequest(string path, bool preserveForm)
		{
			this.Context.Server.TransferRequest(path, preserveForm);
		}

		public void TransferRequest(string path, bool preserveForm, string method, NameValueCollection headers)
		{
			this.Context.Server.TransferRequest(path, preserveForm, method, headers);
		}

		public string UrlDecode(string s)
		{
			return this.Context.Server.UrlDecode(s);
		}

		public void UrlDecode(string s, System.IO.TextWriter output)
		{
			this.Context.Server.UrlDecode(s, output);
		}

		public string UrlEncode(string s)
		{
			return this.Context.Server.UrlEncode(s);
		}

		public void UrlEncode(string s, System.IO.TextWriter output)
		{
			this.Context.Server.UrlEncode(s, output);
		}

		public string UrlPathEncode(string s)
		{
			return this.Context.Server.UrlPathEncode(s);
		}

		public byte[] UrlTokenDecode(string input)
		{
			return HttpServerUtility.UrlTokenDecode(input);
		}

		public string UrlTokenEncode(byte[] input)
		{
			return HttpServerUtility.UrlTokenEncode(input);
		}

		#endregion
	}
}
