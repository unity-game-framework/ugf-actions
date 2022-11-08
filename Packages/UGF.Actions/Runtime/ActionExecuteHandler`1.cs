using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Actions.Runtime
{
    public delegate void ActionExecuteHandler<in TCommand>(IActionProvider provider, IContext context, TCommand command) where TCommand : IActionCommand;
}
