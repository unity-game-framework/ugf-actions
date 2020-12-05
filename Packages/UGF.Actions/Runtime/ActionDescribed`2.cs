namespace UGF.Actions.Runtime
{
    public abstract class ActionDescribed<TDescription, TCommand> : ActionDescribed<TDescription>
        where TDescription : class, IActionDescription
        where TCommand : IActionCommand
    {
        protected ActionDescribed(TDescription description) : base(description)
        {
        }

        protected override void OnExecute(IActionProvider provider, IActionContext context)
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

        protected abstract void OnExecute(IActionProvider provider, IActionContext context, TCommand command);
    }
}
