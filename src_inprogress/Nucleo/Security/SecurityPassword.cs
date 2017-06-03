using System;
using Nucleo.Security.Configuration;


namespace Nucleo.Security
{
	public sealed class SecurityPassword
	{
		private PasswordStatusType _status = PasswordStatusType.None;
		internal string _value = string.Empty;



		#region " Properties "

		public PasswordStatusType Status
		{
			get { return _status; }
		}

		public string Value
		{
			get { return _value; }
		}

		#endregion



		#region " Constructors "

		internal SecurityPassword() { }

		#endregion



		#region " Methods "

		public static SecurityPassword CreatePassword(string password)
		{
			PasswordsElement element = null;

			if (SecuritySettingsSection.Instance == null)
				element = PasswordsElement.DefaultSetup;
			else
				element = SecuritySettingsSection.Instance.Passwords;

			PasswordStatusType status = PasswordStatusType.None;
			int upperCaseCount = 0;
			int numberCount = 0;
			int alphaCount = 0;
			int repeatCount = 0;
			bool reachedMaximumRepeatCount = false;
			char lastChar = char.MinValue;


			if (password.Length < element.MinimumLength)
				status = PasswordStatusType.IllegalLength;
			else
			{
				foreach (char letter in password)
				{
					if (Char.IsUpper(letter))
						upperCaseCount++;
					else if (Char.IsDigit(letter))
						numberCount++;
					else if (!Char.IsLetterOrDigit(letter))
						alphaCount++;

					if (letter == lastChar)
					{
						repeatCount++;
						if (repeatCount > element.MaximumRepeatingCharacterCount)
							reachedMaximumRepeatCount = true;
					}
					else
						repeatCount = 0;
				}
			}

			if (reachedMaximumRepeatCount)
				status = PasswordStatusType.TooManyRepeatingCharacters;
			else if (upperCaseCount < element.MinimumUpperCaseCharacters)
				status = PasswordStatusType.NoUpperCaseCharacters;
			else if (numberCount < element.MinimumNumericCharacters)
				status = PasswordStatusType.NoNumerics;
			else if (alphaCount < element.MinimumNonAlphaNumericCharacters)
				status = PasswordStatusType.NoSpecialCharacters;
			else
				status = PasswordStatusType.Ok;


			//If not a successful attempt or clear text password, leave the password as is and return 
			if (status != PasswordStatusType.Ok || element.PasswordFormat == SecurityPasswordFormatType.Clear)
			{
				SecurityPassword passwordObject = new SecurityPassword();
				passwordObject._value = password;
				passwordObject._status = status;
				return passwordObject;
			}
			//Encrypt 
			else
			{
				//TODO:process password value based upon the password type 
				return null;
			}
		}

		#endregion
	}
}
