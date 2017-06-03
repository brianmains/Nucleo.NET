using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nucleo.Framework
{
	public static class SiteMapGeneration
	{
		public static SiteMapCategoryCollection Categories { get; set; }
	}



	public class SiteMapGenerator
	{
		private string _folder = null;
		private string _rootUrl = null;



		#region " Constructors "

		private SiteMapGenerator() { }

		#endregion



		#region " Methods "

		public static SiteMapGenerator Create(string folder, string rootUrl)
		{
			if (string.IsNullOrEmpty(folder))
				throw new ArgumentNullException("folder");

			SiteMapGenerator gen = new SiteMapGenerator();
			gen._folder = folder;
			gen._rootUrl = rootUrl;

			return gen;
		}

		public SiteMapCategoryCollection GenerateSitemapHierarchy()
		{
	
			var directories = Directory.GetDirectories(_folder);
			var output = new SiteMapCategoryCollection();

			foreach (var directory in directories)
			{
				var cat = new SitemapCategory 
				{
					Name = GetLabel(directory.Replace(_folder + @"\", "")),
					Items = new List<SitemapItem>()
				};
				var files = Directory.GetFiles(directory, "*.aspx");

				cat.Items.AddRange(from file in files
								   select new SitemapItem
								   {
									   Category = cat,
									   File = file,
									   Name = GetLabel(Path.GetFileNameWithoutExtension(file)),
									   Url = GenerateUrl(file),
									   Aspx = GetContent(file),
									   Code = GetContent(file + ".cs")
								   });

				output.Add(cat);
			}

			return output;
		}

		private string GenerateUrl(string file)
		{
			string partialFile = file.Replace(_folder, "").Replace(@"\", @"/");
			return _rootUrl + partialFile;
		}

		private string GetContent(string file)
		{
			string content = "";

			using (var reader = new StreamReader(file))
				content = reader.ReadToEnd();

			return content;
		}

		private string GetLabel(string text)
		{
			string output = "";
			bool previousUpper = false;

			for (int i = 0, len = text.Length; i < len; i++)
			{
				if (Char.IsUpper(text[i]))
				{
					if (!previousUpper)
					{
						output += " ";
						previousUpper = true;
					}
				}
				else
					previousUpper = false;

				output += text[i];
			}

			return output;
		}

		#endregion
	}

	public class SitemapCategory
	{
		public List<SitemapItem> Items { get; set; }
		public string Name { get; set; }
	}

	public class SiteMapCategoryCollection : List<SitemapCategory>
	{
		
	}

	public class SitemapItem
	{
		public SitemapCategory Category { get; set; }

		public string Aspx { get; set; }
		public string Code { get; set; }
		public string File { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
	}
}