using System.Collections.Generic;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Actions.Runtime
{
    public interface IActionSystem : IEnumerable<IAction>
    {
        int Count { get; }

        void Add(IAction action);
        bool Remove(IAction action);
        void Clear();
        void Execute(IActionProvider provider, IContext context);
    }
}
