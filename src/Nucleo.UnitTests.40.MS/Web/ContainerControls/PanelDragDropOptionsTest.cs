using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web.ContainerControls.ClientSettings;


namespace Nucleo.Web.ContainerControls
{
	[TestClass]
	public class PanelDragDropOptionsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingOptionsWorksOK()
		{
			//Arrange
			var options = new PanelDragDropOptions();

			//Act
			options.ClientEvents = new PanelDraggingClientEvents { OnClientDragEnding = "A" };
			options.Operation = DragDropPanelOperation.Drop;

			//Assert
			Assert.AreEqual("A", options.ClientEvents.OnClientDragEnding);
			Assert.AreEqual(DragDropPanelOperation.Drop, options.Operation);
		}

		#endregion
	}
}
