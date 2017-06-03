using System; 
using System.Configuration;


namespace Nucleo.Email.Configuration
{
	public class EmailSection : ConfigurationSection
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the type of provider to use to send emails with.
		/// </summary>
		[ConfigurationProperty("defaultProviderType", IsRequired=true)]
		public string DefaultProviderType
		{
			get { return (string)this["defaultProviderType"]; }
			set { this["defaultProviderType"] = value; }
		}

		/// <summary>
		/// Gets an instance of this configuration section.
		/// </summary>
		public static EmailSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/email") as EmailSection; }
		}

		#endregion
	}
}