using System;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Actions.Runtime
{
    public static class ActionProviderExtensions
    {
        public static void Execute<TCommand>(this IActionProvider provider, IContext context, ActionExecuteHandler<TCommand> handler) where TCommand : IActionCommand
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            if (provider.Current.TryGet(out IActionCommandList<TCommand> commands))
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    TCommand command = commands.Get(i);

                    handler.Invoke(provider, context, command);
                }
            }
        }
    }
}
