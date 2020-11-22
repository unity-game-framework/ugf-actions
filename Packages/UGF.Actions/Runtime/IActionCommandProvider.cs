using System;
using System.Collections.Generic;

namespace UGF.Actions.Runtime
{
    public interface IActionCommandProvider
    {
        IReadOnlyDictionary<Type, IActionCommandStack> Commands { get; }

        void Refresh();
    }
}
