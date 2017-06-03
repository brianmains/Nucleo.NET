using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Collections
{
	[TestClass]
	public class SelectableCollectionBaseTest
	{
		private SelectableCollectionBase<Employee> _employees = null;

		private bool _selectionChanged = false;
		private bool _nullStatusChanged = false;



		#region " Test Classes "

		protected class Employee
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Identifier { get; set; }

			public Employee(string firstName, string lastName, string identifier)
			{
				this.FirstName = firstName;
				this.LastName = lastName;
				this.Identifier = identifier;
			}
		}

		#endregion



		#region " Tests "

		[TestInitialize]
		public void Initialize()
		{
			_employees = new SelectableCollectionBase<Employee>();
			_employees.SelectionChanged += new Nucleo.EventArguments.DataEventHandler<Employee>(Employees_SelectionChanged);
			_employees.SelectionNullStatusChanged += new EventHandler(Employees_SelectionNullStatusChanged);
		}

		[TestMethod]
		public void TestSelection()
		{
			_employees.Add(new Employee("Jay", "Jay", "asd3243"));
			_employees.Add(new Employee("Jay", "Jo", "34344321"));
			_employees.Add(new Employee("Bill", "Son", "12323"));
			_employees.Add(new Employee("Aaron", "Smith", "234234"));

			Assert.IsNull(_employees.Selected);
			Assert.IsFalse(_selectionChanged);

			_employees.Selected = _employees[2];
			Assert.IsNotNull(_employees.Selected);
			Assert.AreEqual("Bill", _employees.Selected.FirstName);
			Assert.AreEqual("Son", _employees.Selected.LastName);
			Assert.IsTrue(_selectionChanged);
			Assert.IsTrue(_nullStatusChanged);

			_selectionChanged = false;
			_nullStatusChanged = false;
			_employees.Selected = _employees[0];
			Assert.IsNotNull(_employees.Selected);
			Assert.AreEqual("Jay", _employees.Selected.FirstName);
			Assert.AreEqual("Jay", _employees.Selected.LastName);
			Assert.IsTrue(_selectionChanged);
			Assert.IsFalse(_nullStatusChanged);

			_selectionChanged = false;
			_employees.Selected = null;
			Assert.IsTrue(_selectionChanged);
			Assert.IsTrue(_nullStatusChanged);
		}

		#endregion



		#region " Event Handlers "

		void Employees_SelectionChanged(object sender, Nucleo.EventArguments.DataEventArgs<Employee> e)
		{
			_selectionChanged = true;
		}

		void Employees_SelectionNullStatusChanged(object sender, EventArgs e)
		{
			_nullStatusChanged = true;
		}

		#endregion
	}
}
