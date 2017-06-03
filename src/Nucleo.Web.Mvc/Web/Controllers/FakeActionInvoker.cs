using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace Nucleo.Web.Controllers
{
	public class FakeActionInvoker : ControllerActionInvoker
	{
		private IDictionary<string, ActionResult> _actionResults = null;
		private bool _processResults = true;



		#region " Properties "

		public IDictionary<string, ActionResult> ActionResults
		{
			get
			{
				if (_actionResults == null)
					_actionResults = new Dictionary<string, ActionResult>();

				return _actionResults;
			}
		}

		public bool ProcessResults
		{
			get { return _processResults; }
			set { _processResults = value; }
		}

		#endregion



		#region " Methods "

		protected override ActionResult CreateActionResult(ControllerContext controllerContext, ActionDescriptor actionDescriptor, object actionReturnValue)
		{
			return this.ActionResults[actionDescriptor.ActionName];
		}

		public override bool InvokeAction(ControllerContext controllerContext, string actionName)
		{
			return (this.ActionResults.ContainsKey(actionName));
		}

		#endregion
	}
}
