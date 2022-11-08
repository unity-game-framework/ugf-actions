using System;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Actions.Runtime
{
    public static class ActionProviderExtensions
    {
        public static void Execute<T>(this IActionProvider provider, IContext context, ActionExecuteHandler<T> handler) where T : IActionCommand
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            if (provider.Current.TryGet(out IActionCommandList<T> commands))
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    T command = commands.Get(i);

                    handler.Invoke(provider, context, command);
                }
            }
        }
    }
}
