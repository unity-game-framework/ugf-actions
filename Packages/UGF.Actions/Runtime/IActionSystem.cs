using System.Collections.Generic;
using UGF.Initialize.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Actions.Runtime
{
    public interface IActionSystem : IInitialize, IEnumerable<IAction>
    {
        int Count { get; }

        void Add(IAction action);
        bool Remove(IAction action);
        void Clear();
        void Execute(IActionProvider provider, IContext context);
    }
}
