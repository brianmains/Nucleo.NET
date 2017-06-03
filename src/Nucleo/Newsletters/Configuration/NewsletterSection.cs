using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Newsletters.Configuration
{
	public class NewsletterSection : ConfigurationSectionBase
	{
		[ConfigurationProperty("defaultProvider", IsRequired=true)]
		public string DefaultProvider
		{
			get { return (string)this["defaultProvider"]; }
			set { this["defaultProvider"] = value; }
		}

		public static NewsletterSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/newsletters") as NewsletterSection; }
		}
	}
}