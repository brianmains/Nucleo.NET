using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Security;
using Nucleo.Views;


namespace Nucleo.Web.Security
{
    public class WebSecurableApplicator : ISecurableApplicator
    {
        public void Apply(IView view, SecurityResults results)
        {
            if (view is Control)
                this.ApplyToControl((Control)(object)view, results);
        }

        private void ApplyToControl(Control uc, SecurityResults results)
        {
            uc.Visible = (results.Access != SecurityAccessLevel.NoAccess);

            if (uc.Visible)
            {
                bool enabled = (results.Access == SecurityAccessLevel.FullAccess);

                foreach (var control in uc.Controls)
                {
                    if (control is WebControl)
                        ((WebControl)control).Enabled = enabled;
                }
            }
        }
    }
}
