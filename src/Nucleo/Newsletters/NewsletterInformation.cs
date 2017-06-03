using System;


namespace Nucleo.Newsletters
{
	public class NewsletterInformation
	{
		private string _description = string.Empty;
		private string _name = string.Empty;



		#region " Properties "

		public string Description
		{
			get { return _description; }
		}

		public string Name
		{
			get { return _name; }
		}

		#endregion



		#region " Constructors "

		public NewsletterInformation(string name, string description)
		{
			_name = name;
			_description = description;
		}

		#endregion
	}
}
