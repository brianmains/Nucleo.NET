using System;
using System.Web;
using System.IO;

using Nucleo.Web.Handlers.Configuration;


namespace Nucleo.Web.Handlers
{
	public class FileMonitoringHttpHandler : HttpHandlerBase
	{
		#region " Properties "

		public override bool IsReusable
		{
			get { return true; }
		}

		#endregion



		#region " Methods "

		private string CreateJavaScriptObject(string path)
		{
			return string.Format("{ FullName: {0}, Name: {1} }", path, Path.GetFileName(path));
		}

		protected virtual string GetPath(HttpContextBase context)
		{
			if (!string.IsNullOrEmpty(context.Request.Headers["FileMonitoringPath"]))
				return context.Request.Headers["FileMonitoringPath"];

			FileMonitoringSettingsSection section = FileMonitoringSettingsSection.Instance;
			if (section == null) return null;
			string pathName = context.Request.Headers["FileMonitoringPathName"];
			if (string.IsNullOrEmpty(pathName)) return null;

			return section.Paths[pathName].Value;
		}

		protected virtual bool IsGettingCount(HttpContextBase context)
		{
			return (context.Request.Headers["FileMonitoringCount"] == "Count");
		}

		public override void ProcessRequest(HttpContextBase context)
		{
			var response = context.Response;
			string path = this.GetPath(context);
			if (string.IsNullOrEmpty(path)) return;

			try
			{
				response.ContentType = "text/javascript";
				string[] files = Directory.GetFiles(path);
				bool comma = false;

				//Create updated list of files, or get the file count only
				if (this.IsGettingCount(context))
				{
					response.Write(string.Format("var monitoredCount = {0};", files.Length));
				}
				else
				{
					string objs = "var monitoredFiles = [";

					foreach (string file in files)
					{
						if (comma)
							objs += ", ";

						objs += this.CreateJavaScriptObject(file);
					}

					objs += "];";

					response.Write(objs);
				}
			}
			catch (Exception ex)
			{
				response.Write(string.Format("var monitorError = { error: '{0}' };", ex.Message));
			}
		}

		#endregion
	}
}
