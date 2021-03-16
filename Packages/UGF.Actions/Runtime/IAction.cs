using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Actions.Runtime
{
    public interface IAction
    {
        void Execute(IActionProvider provider, IContext context);
    }
}
