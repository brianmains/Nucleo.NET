using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Security;
using Nucleo.Web.Views;


namespace Nucleo.Web.Security
{
    [TestClass]
    public class WebSecurableApplicatorTest
    {
        [TestMethod]
        public void SettingFullAccessToPageOpensPageUp()
        {
            var uc = Isolate.Fake.Instance<BaseViewPage>(Members.CallOriginal);
            uc.Controls.Add(new Label());
            uc.Controls.Add(new Panel());
            uc.Controls.Add(new TextBox());

            (new WebSecurableApplicator()).Apply(uc, new SecurityResults(SecurityAccessLevel.FullAccess));

            Assert.AreEqual(true, uc.Visible);
            Assert.IsTrue(uc.Controls.Cast<WebControl>().All(i => i.Enabled == true));
        }

        [TestMethod]
        public void SettingFullAccessToUserControlOpensPageUp()
        {
            var uc = Isolate.Fake.Instance<BaseViewUserControl>(Members.CallOriginal);
            uc.Controls.Add(new Label());
            uc.Controls.Add(new Panel());
            uc.Controls.Add(new TextBox());

            (new WebSecurableApplicator()).Apply(uc, new SecurityResults(SecurityAccessLevel.FullAccess));

            Assert.AreEqual(true, uc.Visible);
            Assert.IsTrue(uc.Controls.Cast<WebControl>().All(i => i.Enabled == true));
        }

        [TestMethod]
        public void SettingNoAccessToPageHidesIt()
        {
            var uc = Isolate.Fake.Instance<BaseViewPage>(Members.CallOriginal);

            (new WebSecurableApplicator()).Apply(uc, new SecurityResults(SecurityAccessLevel.NoAccess));

            Assert.AreEqual(false, uc.Visible);
        }

        [TestMethod]
        public void SettingNoAccessToUserControlHidesIt()
        {
            var uc = Isolate.Fake.Instance<BaseViewUserControl>(Members.CallOriginal);
            
            (new WebSecurableApplicator()).Apply(uc, new SecurityResults(SecurityAccessLevel.NoAccess));

            Assert.AreEqual(false, uc.Visible);
        }

        [TestMethod]
        public void SettingRestrictedAccessToPageDisablesChildren()
        {
            var uc = Isolate.Fake.Instance<BaseViewPage>(Members.CallOriginal);
            uc.Controls.Add(new Label());
            uc.Controls.Add(new Panel());
            uc.Controls.Add(new TextBox());

            (new WebSecurableApplicator()).Apply(uc, new SecurityResults(SecurityAccessLevel.RestrictedAccess));

            Assert.AreEqual(true, uc.Visible);
            Assert.IsTrue(uc.Controls.Cast<WebControl>().All(i => i.Enabled == false));
        }

        [TestMethod]
        public void SettingRestrictedAccessToUserControlDisablesChildren()
        {
            var uc = Isolate.Fake.Instance<BaseViewUserControl>(Members.CallOriginal);
            uc.Controls.Add(new Label());
            uc.Controls.Add(new Panel());
            uc.Controls.Add(new TextBox());

            (new WebSecurableApplicator()).Apply(uc, new SecurityResults(SecurityAccessLevel.RestrictedAccess));

            Assert.AreEqual(true, uc.Visible);
            Assert.IsTrue(uc.Controls.Cast<WebControl>().All(i => i.Enabled == false));
        }
    }
}
