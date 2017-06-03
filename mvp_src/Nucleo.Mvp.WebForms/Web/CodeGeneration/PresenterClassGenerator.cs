using System;
using System.Text;

using Nucleo.Web.Core;
using Nucleo.Web.Context;
using Nucleo.Presentation;


namespace Nucleo.Web.CodeGeneration
{
	/// <summary>
	/// Generates a presenter proxy wrapper.
	/// </summary>
	public class PresenterClassGenerator : IClassGenerator
	{
		private IServicesContext _service = null;



		#region " Constructors "

		public PresenterClassGenerator(IServicesContext service)
		{
			_service = service;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Generates a proxy class to work with the presenter class on the server, through the handler.
		/// </summary>
		/// <param name="definition">The definition of the class.</param>
		/// <returns>The outputted generated class.</returns>
		public string Generate(ClassDefinition definition)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("(function() {");
			builder.AppendLine("return {");
			bool comma = false;

			foreach (ClassMethodMember method in definition.Methods)
			{
				if (comma)
					builder.Append(",");
				else
					comma = true;

				string url = "'" + _service.Urls.GetClientBasedUrl("PresenterAjax.axd") +
					string.Format("?presenter={0}&operation={1}",
					_service.Server.HtmlEncode(definition.SourceType.AssemblyQualifiedName), method.Name);

				foreach (string key in method.Parameters)
					url += string.Format("&{0}=' + {1} + '", key, key);

				url += "'";

				builder.AppendLine(method.Name + ": function(" + GetParameters(method) + ") {");

				builder.AppendLine("var request = new Sys.Net.WebRequest();");
				builder.AppendLine("request.set_httpVerb('POST');");
				builder.AppendLine("request.set_url(" + url + ");");
				//builder.AppendLine("request.get_headers()['PARAMS'] = " + url + ";");
				builder.AppendLine(@"request.add_completed(function(sender, e) {
					if (!!failedCallback && sender.get_statusCode() != 200 || !!sender.get_aborted() || !!sender.get_timedOut()) {
						failedCallback.apply(request, [{ aborted: sender.get_aborted(), timedOut: sender.get_timedOut(), code: sender.get_statusCode(), text: sender.get_statusText() }]);
					}
					else {
						if (!!successCallback)
							successCallback.apply(request, [{ data: n$.JsonParse(sender.get_responseData()) }]);
					}
				});");
				builder.AppendLine("request.invoke();");

				builder.AppendLine("}");
			}

			builder.AppendLine("};");
			builder.AppendLine("})();");

			return builder.ToString();
		}

		private string GetParameters(ClassMethodMember method)
		{
			string parms = "";

			foreach (string key in method.Parameters)
				parms += key + ", ";

			return parms + "successCallback, failedCallback";
		}

		#endregion
	}
}
