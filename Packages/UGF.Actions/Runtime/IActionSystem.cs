using System.Collections.Generic;

namespace UGF.Actions.Runtime
{
    public interface IActionSystem
    {
        IReadOnlyList<IAction> Actions { get; }

        void Execute(IActionProvider provider, IActionContext context);
    }
}
