using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Modules;


namespace Nucleo.Reflection
{
	[TestClass]
	public class AssemblySourceTest
	{
		[TestMethod]
		public void GettingAssembliesAssignsOK()
		{
			var assemblies = AssemblySource.GetAll();

			Assert.IsTrue(assemblies.ToList().Count > 0);
		}

		[TestMethod]
		public void HasAssemblyResourceFindsAssembly()
		{
			var assembly = Assembly.Load("Tests.Module");
			var result = AssemblySource.HasAssemblyResource<ModuleAttribute>(assembly);

			Assert.AreEqual(true, result);
		}

		[TestMethod]
		public void HasAssemblyResourceFindsAssemblyWithLambda()
		{
			var assembly = Assembly.Load("Tests.Module");
			var result = AssemblySource.HasAssemblyResourceWith(assembly, (m) => { return (m is ModuleAttribute); });

			Assert.AreEqual(true, result);
		}
	}
}
