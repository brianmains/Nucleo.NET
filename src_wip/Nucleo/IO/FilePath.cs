using System;
using System.IO;
using System.Text.RegularExpressions;


namespace Nucleo.IO
{
	public static class FilePath
	{
		#region " Methods "

		public static string Combine(string path1, string path2)
		{
			return Path.Combine(path1, path2);
		}

		public static string Combine(string[] paths)
		{
			string finalPath = "";

			foreach (string path in paths)
				Path.Combine(finalPath, path);

			return finalPath;
		}

		public static string GetFileName(string path)
		{
			return Path.GetFileName(path);
		}

		public static string GetFileName(string path, bool includeExtension)
		{
			if (includeExtension)
				return Path.GetFileName(path);
			else
				return Path.GetFileNameWithoutExtension(path);
		}

		public static bool IsFullPath(string path)
		{
			return Regex.IsMatch(path, @"[A-Z](1,3)[:]\\");
		}

		#endregion
	}
}
