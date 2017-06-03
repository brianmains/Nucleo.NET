using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Views;


namespace Nucleo.Security
{
    public interface ISecurableView
    {
        SecurityResults GetAccessLevel(IView view);
    }
}
