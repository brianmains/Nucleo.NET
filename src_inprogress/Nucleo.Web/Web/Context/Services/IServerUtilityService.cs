using System;
using System.Web;
using System.IO;
using System.Collections.Specialized;

using Nucleo.Context;


namespace Nucleo.Web.Context.Services
{
	/// <summary>
	/// Represents the server utility function that processes server-based requests.
	/// </summary>
	public interface IServerUtilityService : IService
	{
		#region " Properties "

		/// <summary>
		/// Gets the name of the machine.
		/// </summary>
		string MachineName { get; }

		/// <summary>
		/// Gets or sets the timeout to limit running scripts to.
		/// </summary>
		int ScriptTimeout { get; set; }

		#endregion



		#region " Methods "

		/// <summary>
		/// Clears any exception that may have occurred within the page.
		/// </summary>
		void ClearError();

		/// <summary>
		/// Creates an object using its program ID.
		/// </summary>
		/// <param name="progID">The ID of the program.</param>
		/// <returns>Gets the object.</returns>
		object CreateObject(string progID);

		/// <summary>
		/// Creates an object using its type.
		/// </summary>
		/// <param name="type">The type of the program.</param>
		/// <returns>Gets the object.</returns>
		object CreateObject(Type type);

		/// <summary>
		/// Creates an object using its class ID.
		/// </summary>
		/// <param name="type">The class ID of the program.</param>
		/// <returns>Gets the object.</returns>
		object CreateObjectFromClsid(string clsid);

		/// <summary>
		/// Executes a specific path within the current request.
		/// </summary>
		/// <param name="path">The path to execute.</param>
		void Execute(string path);

		/// <summary>
		/// Executes a specific path within the current request.
		/// </summary>
		/// <param name="path">The path to execute.</param>
		/// <param name="preserveForm">Whether to preserve the original form.</param>
		void Execute(string path, bool preserveForm);

		/// <summary>
		/// Executes a specific path within the current request.
		/// </summary>
		/// <param name="path">The path to execute.</param>
		/// <param name="writer">A writer to use for the execution.</param>
		void Execute(string path, TextWriter writer);

		/// <summary>
		/// Executes a specific path within the current request.
		/// </summary>
		/// <param name="path">The path to execute.</param>
		/// <param name="writer">A writer to use for the execution.</param>
		/// <param name="preserveForm">Whether to preserve the original form.</param>
		void Execute(string path, TextWriter writer, bool preserveForm);

		/// <summary>
		/// Executes a specific path within the current request.
		/// </summary>
		/// <param name="handler">The process to execute, using the handler directly.</param>
		/// <param name="writer">A writer to use for the execution.</param>
		/// <param name="preserveForm">Whether to preserve the original form.</param>
		void Execute(IHttpHandler handler, TextWriter writer, bool preserveForm);

		/// <summary>
		/// Gets the last error that was thrown and not caught by a try/catch block.
		/// </summary>
		/// <returns>The unhandled exception, or null if all exceptions handled.</returns>
		Exception GetLastError();

		/// <summary>
		/// Decodes an HTML string.  This makes the string live potentially (javascript within the script can run).
		/// </summary>
		/// <param name="s">The string to decode.</param>
		/// <returns>The decoded string.</returns>
		string HtmlDecode(string s);

		/// <summary>
		/// Decodes an HTML string.
		/// </summary>
		/// <param name="s">The string to decode.</param>
		/// <param name="output">The output.</param>
		/// <returns>The decoded string.</returns>
		void HtmlDecode(string s, TextWriter output);

		/// <summary>
		/// Encodes an HTML string.  This prevents text from being active in the browser (deactivates javascript).
		/// </summary>
		/// <param name="s">The string to encode.</param>
		/// <returns>The encode string.</returns>
		string HtmlEncode(string s);

		/// <summary>
		/// Encodes an HTML string.  This prevents text from being active in the browser (deactivates javascript).
		/// </summary>
		/// <param name="s">The string to encode.</param>
		/// <param name="output">The output.</param>
		/// <returns>The encoded string.</returns>
		void HtmlEncode(string s, TextWriter output);

		/// <summary>
		/// Maps a server-side specific path.  Takes a relative reference (ie. ~/Content/file.aspx) and makes it absolute.
		/// </summary>
		/// <param name="path">The path to make absolute.</param>
		/// <returns>The absolute path.</returns>
		string MapPath(string path);

		/// <summary>
		/// Transfers to a new page within the application.  Shows the URL of the previous page.
		/// </summary>
		/// <param name="path">The path to transfer.</param>
		void Transfer(string path);

		/// <summary>
		/// Transfers to a new page within the application.  Shows the URL of the previous page.
		/// </summary>
		/// <param name="path">The path to transfer.</param>
		/// <param name="preserveForm">Whether to preserve the original form.</param>
		void Transfer(string path, bool preserveForm);

		/// <summary>
		/// Transfers to a new page within the application.  Shows the URL of the previous page.
		/// </summary>
		/// <param name="handler">The HTTP handler to transfer.</param>
		/// <param name="preserveForm">Whether to preserve the original form.</param>
		void Transfer(IHttpHandler handler, bool preserveForm);

		/// <summary>
		/// Transfers the request to the new page.
		/// </summary>
		/// <param name="path">The path to the page to transfer the request.</param>
		void TransferRequest(string path);

		/// <summary>
		/// Transfers the request to the new page.
		/// </summary>
		/// <param name="path">The path to the page to transfer the request.</param>
		/// <param name="preserveForm">Whether to preserve the original form.</param>
		void TransferRequest(string path, bool preserveForm);

		/// <summary>
		/// Transfers the request to the new page.
		/// </summary>
		/// <param name="path">The path to the page to transfer the request.</param>
		/// <param name="preserveForm">Whether to preserve the original form.</param>
		/// <param name="method">The method.</param>
		/// <param name="headers">The header collection.</param>
		void TransferRequest(string path, bool preserveForm, string method, NameValueCollection headers);

		/// <summary>
		/// Decodes a specific URL.
		/// </summary>
		/// <param name="s">The url to decode.</param>
		/// <returns>The final URL.</returns>
		string UrlDecode(string s);

		/// <summary>
		/// Decodes a specific URL.
		/// </summary>
		/// <param name="s">The url to decode.</param>
		/// <param name="output">The output stream.</param>
		/// <returns>The final URL.</returns>
		void UrlDecode(string s, TextWriter output);

		/// <summary>
		/// Encodes a specific URL.
		/// </summary>
		/// <param name="s">The url to encode.</param>
		/// <returns>The final URL.</returns>
		string UrlEncode(string s);

		/// <summary>
		/// Encodes a specific URL.
		/// </summary>
		/// <param name="s">The url to encode.</param>
		/// <param name="output">The output stream.</param>
		/// <returns>The final URL.</returns>
		void UrlEncode(string s, TextWriter output);

		/// <summary>
		/// Encodes the URL path.
		/// </summary>
		/// <param name="s">The path to encode.</param>
		/// <returns>The final URL.</returns>
		string UrlPathEncode(string s);

		/// <summary>
		/// Decodes an URL token.
		/// </summary>
		/// <param name="input">The input to decode.</param>
		/// <returns>The output.</returns>
		byte[] UrlTokenDecode(string input);

		/// <summary>
		/// Encodes an URL token.
		/// </summary>
		/// <param name="input">The input to encode.</param>
		/// <returns>The output.</returns>
		string UrlTokenEncode(byte[] input);

		#endregion
	}
}
