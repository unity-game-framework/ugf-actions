namespace UGF.Actions.Runtime
{
    public abstract class Action<TCommand> : ActionBase where TCommand : IActionCommand
    {
        protected override void OnExecute(IActionProvider provider, IActionContext context)
        {
            if (provider.Current.TryGet(out IActionCommandStack<TCommand> commands))
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    ref TCommand command = ref commands.Get(i);

                    OnExecute(provider, context, in command);
                }
            }
        }

        protected abstract void OnExecute(IActionProvider provider, IActionContext context, in TCommand command);
    }
}
