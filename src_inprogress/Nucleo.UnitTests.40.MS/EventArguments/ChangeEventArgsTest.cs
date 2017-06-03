using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class ChangeEventArgsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingChangeArgsWithEqualValuesWorksCorrectly()
		{
			ChangeEventArgs args = new ChangeEventArgs("Some Source", 1, 1);
			
		}

		#endregion
	}
}
