using System;
using System.Web.UI.WebControls;

using Nucleo.Web.AccordionControls;


namespace Nucleo.EventArguments
{
	public class AccordionItemEventArgs : CommandEventArgs
	{
		private AccordionItem _item = null;



		#region " Constructors "

		public AccordionItemEventArgs(AccordionItem item, string commandName, object commandArgument)
			: base(commandName, commandArgument)
		{
			_item = item;
		}

		#endregion
	}

	public delegate void AccordionItemEventHandler(object sender, AccordionItemEventArgs e);
}
