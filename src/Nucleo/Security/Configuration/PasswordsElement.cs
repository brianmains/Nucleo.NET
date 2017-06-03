using System;
using System.Configuration;

using Nucleo.Security;


namespace Nucleo.Security.Configuration
{
	public class PasswordsElement : ConfigurationElement
	{
		#region " Properties "

		public static PasswordsElement DefaultSetup
		{
			get { return new PasswordsElement(); }
		}

		[ConfigurationProperty("maximumRepeatingCharacterCount", DefaultValue = 2)]
		public int MaximumRepeatingCharacterCount
		{
			get { return (int)this["maximumRepeatingCharacterCount"]; }
			set
			{
				if (value < -1)
					throw new ArgumentOutOfRangeException("value");
				this["maximumRepeatingCharacterCount"] = value;
			}
		}

		[ConfigurationProperty("minimumLength", DefaultValue = 6)]
		public int MinimumLength
		{
			get { return (int)this["minimumLength"]; }
			set
			{
				if (value < -1)
					throw new ArgumentOutOfRangeException("value");
				this["minimumLength"] = value;
			}
		}

		[ConfigurationProperty("minimumNonAlphaNumericCharacters", DefaultValue = 1)]
		public int MinimumNonAlphaNumericCharacters
		{
			get { return (int)this["minimumNonAlphaNumericCharacters"]; }
			set
			{
				if (value < -1)
					throw new ArgumentOutOfRangeException("value");
				this["minimumNonAlphaNumericCharacters"] = value;
			}
		}

		[ConfigurationProperty("minimumNumericCharacters", DefaultValue = 1)]
		public int MinimumNumericCharacters
		{
			get { return (int)this["minimumNumericCharacters"]; }
			set
			{
				if (value < -1)
					throw new ArgumentOutOfRangeException("value");
				this["minimumNumericCharacters"] = value;
			}
		}

		[ConfigurationProperty("minimumUpperCaseCharacters", DefaultValue = 1)]
		public int MinimumUpperCaseCharacters
		{
			get { return (int)this["minimumUpperCaseCharacters"]; }
			set
			{
				if (value < -1)
					throw new ArgumentOutOfRangeException("value");
				this["minimumUpperCaseCharacters"] = value;
			}
		}

		[ConfigurationProperty("passwordFormat", DefaultValue = SecurityPasswordFormatType.Clear)]
		public SecurityPasswordFormatType PasswordFormat
		{
			get { return (SecurityPasswordFormatType)this["passwordFormat"]; }
			set { this["passwordFormat"] = value; }
		}

		#endregion



		#region " Constructors "

		public PasswordsElement() : this(SecurityPasswordFormatType.Clear, 6, 1, 1, 0, 2) { }

		public PasswordsElement(SecurityPasswordFormatType passwordFormat, int minimumLength, int minimumUpperCaseCharacters, int minimumNumericCharacters, int minimumNonAlphanumericCharacters, int maximumRepeatingCharacterCount)
		{
			this.PasswordFormat = passwordFormat;
			this.MinimumLength = minimumLength;
			this.MinimumUpperCaseCharacters = minimumUpperCaseCharacters;
			this.MinimumNumericCharacters = minimumNumericCharacters;
			this.MinimumNonAlphaNumericCharacters = minimumNonAlphanumericCharacters;
			this.MaximumRepeatingCharacterCount = maximumRepeatingCharacterCount;
		}

		#endregion
	}
}
