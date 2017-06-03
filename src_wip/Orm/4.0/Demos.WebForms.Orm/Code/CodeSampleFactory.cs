using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;


namespace Nucleo
{
	public class CodeSampleFactory
	{
		private static string FormatCode(string code)
		{
			return code;
		}

		public static IEnumerable<CodeSample> Get(Control control)
		{
			var server = HttpContext.Current.Server;
			string path = server.MapPath( 
				(control is Page) 
					? ((Page)control).AppRelativeVirtualPath 
					: ((UserControl)control).AppRelativeVirtualPath);
			string content = File.ReadAllText(path);

			yield return new CodeSample
			{
				FileDisplayName = Path.GetFileNameWithoutExtension(path) + "(Markup)",
				FileFullName = path,
				Code = FormatCode(content)
			};

			path = path + ".cs";
			content = File.ReadAllText(path);

			yield return new CodeSample
			{
				FileDisplayName = Path.GetFileName(path) + "(Code)",
				FileFullName = path,
				Code = FormatCode(content)
			};
		}

		public static IEnumerable<CodeSample> GetCode(string path)
		{
			var codePath = HttpContext.Current.Server.MapPath("~/Code/" + path);
			yield return new CodeSample
			{
				FileDisplayName = Path.GetFileName(codePath) + "(Comp.)",
				FileFullName = codePath,
				Code = File.ReadAllText(FormatCode(codePath))
			};
		}

		public static IEnumerable<CodeSample> GetForRelatedControl(Control control, string codeFileName)
		{
			var server = HttpContext.Current.Server;
			string path = server.MapPath(
				(control is Page)
					? ((Page)control).AppRelativeVirtualPath
					: ((UserControl)control).AppRelativeVirtualPath);

			path = Path.GetDirectoryName(path) + @"\" + codeFileName;
			string content = File.ReadAllText(path);

			yield return new CodeSample
			{
				FileDisplayName = codeFileName + "(Component)",
				FileFullName = path,
				Code = FormatCode(content)
			};
		}
	}
}