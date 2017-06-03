using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Security
{
    public class SecurityResults
    {
        public SecurityAccessLevel Access { get; private set; }



        public SecurityResults(SecurityAccessLevel access)
        {
            this.Access = access;
        }
    }
}
