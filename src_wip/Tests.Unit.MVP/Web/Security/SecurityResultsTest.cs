using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Security
{
    [TestClass]
    public class SecurityResultsTest
    {
        [TestMethod]
        public void CreatingResultsAssignsOK()
        {
            var result = new SecurityResults(SecurityAccessLevel.RestrictedAccess);

            Assert.AreEqual(SecurityAccessLevel.RestrictedAccess, result.Access);
        }
    }
}
