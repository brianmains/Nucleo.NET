using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;

namespace Nucleo.WebServices
{
	/// <summary>
	/// Summary description for TestService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[ScriptService]
	public class TestService : WebService
	{
		[WebMethod]
		public void AddCustomer(int key, string name)
		{
			var customer = new {Key = key, Name = name};
		}

		[WebMethod]
		public void AddCustomerFailure(int key, string name)
		{
			throw new Exception();
		}

		[WebMethod]
		public void DeleteCustomer(int key)
		{

		}

		[WebMethod]
		public void DeleteCustomerFailure(int key)
		{
			throw new Exception();
		}

		[WebMethod]
		public object GetCustomer(int key)
		{
			return new {Key = key, Name = "Test Person"};
		}

		[WebMethod]
		public void GetCustomerFailure(int key)
		{
			throw new Exception();
		}

		[WebMethod]
		public object GetCustomers()
		{
			return new[] {
				new { Key = 1, Name = "Test Person" },
				new { Key = 2, Name = "Some Person" },
				new { Key = 3, Name = "Another Person" }
			}
			;
		}

		[WebMethod]
		public void GetCustomersFailure()
		{
			throw new Exception();
		}

		[WebMethod]
		public void UpdateCustomer(int key, string name)
		{

		}

		[WebMethod]
		public void UpdateCustomerFailure(int key, string name)
		{
			throw new Exception();
		}
	}
}
