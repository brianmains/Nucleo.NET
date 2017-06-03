using System;

using Nucleo.Presentation;
using Nucleo.Views;


namespace Nucleo.Views
{
	public class ViewAppHost
	{
		private static ViewAppHost _instance = new ViewAppHost();



		#region " Methods "

		public ViewAppHost GetInstance()
		{
			return _instance;
		}

		#endregion
	}
}
