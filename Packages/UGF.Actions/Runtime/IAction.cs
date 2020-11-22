using System;
using System.Collections.Generic;

namespace UGF.Actions.Runtime
{
    public interface IAction
    {
        IReadOnlyList<Type> Types { get; }

        void Execute(IActionProvider provider, IActionContext context);
    }
}
