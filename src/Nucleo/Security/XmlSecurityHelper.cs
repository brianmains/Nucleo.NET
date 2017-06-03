using System;
using System.IO;
using System.Xml;


namespace Nucleo.Security
{
	internal static class XmlSecurityHelper
	{
		public static void CheckForFileExistence(string filePath)
		{
			if (File.Exists(filePath))
				return;

			using (StreamWriter writer = new StreamWriter(File.Create(filePath)))
				writer.Write("<Security><Items /><Relationships /></Security>");
		}

		public static XmlNodeList GetItemsByID(XmlElement parentElement, Guid id)
		{
			return parentElement.SelectNodes(string.Format(".//Item[ID = '{0}']", id.ToString()));
		}
	}
}
