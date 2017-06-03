using System;
using System.Configuration;
using System.CodeDom;
using System.Web.Compilation;

using Nucleo.Text;
using Nucleo.Text.Configuration;


namespace Nucleo.Web.Text
{
	/// <summary>
	/// Represents the expression builder for rendering static messages.
	/// </summary>
	public class StaticMessagesExpressionsBuilder : ExpressionBuilder
	{
		#region " Methods "

		/// <summary>
		/// Gets the code expression for the specified expression builder.
		/// </summary>
		/// <param name="entry">The entry information about the expression builder statement.</param>
		/// <param name="parsedData">The parsed data that was passed along.</param>
		/// <param name="context">The context of the expression builder.</param>
		/// <returns>The code expression representing what to output.</returns>
		public override CodeExpression GetCodeExpression(System.Web.UI.BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
		{
			if (parsedData != null && parsedData is string)
				return new CodePrimitiveExpression(GetMessage((string)parsedData));
			else
				return new CodePrimitiveExpression(string.Empty);
		}

		/// <summary>
		/// Gets the message for the specified key.
		/// </summary>
		/// <param name="key">The key of the message to get the value for.</param>
		/// <returns>The value matching the specified key.</returns>
		private static string GetMessage(string key)
		{
			StaticMessagesSection section = StaticMessagesSection.Instance;
			if (section == null)
				throw new NotImplementedException("The static messages configuration section was not implemented");

			NameValueConfigurationElement element = section.Messages[key];
			return (element != null) ? element.Value : null;
		}

		#endregion
	}
}
