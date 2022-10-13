using UGF.Initialize.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Actions.Runtime
{
    public interface IAction : IInitialize
    {
        void Execute(IActionProvider provider, IContext context);
    }
}
