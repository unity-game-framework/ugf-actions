using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Actions.Runtime
{
    public abstract class Action<TCommand> : ActionBase where TCommand : IActionCommand
    {
        protected override void OnExecute(IActionProvider provider, IContext context)
        {
            if (provider.Current.TryGet(out IActionCommandList<TCommand> commands))
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    TCommand command = commands.Get(i);

                    OnExecute(provider, context, command);
                }
            }
        }

        protected abstract void OnExecute(IActionProvider provider, IContext context, TCommand command);
    }
}
