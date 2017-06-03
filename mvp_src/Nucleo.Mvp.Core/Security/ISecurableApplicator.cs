using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Views;


namespace Nucleo.Security
{
    /// <summary>
    /// Manages the application of a securable check.  For instance, controls the visibility of the view UI.
    /// </summary>
    public interface ISecurableApplicator
    {
        void Apply(IView view, SecurityResults results);
    }
}
