using System;
using System.Collections.Generic;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Actions.Runtime
{
    public class ActionExecuteList : ActionBase
    {
        public List<ActionExecuteHandler> Handlers { get; } = new List<ActionExecuteHandler>();

        public void Add<T>(ActionExecuteHandler<T> handler) where T : IActionCommand
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            Handlers.Add((provider, context) => provider.Execute(context, handler));
        }

        protected override void OnExecute(IActionProvider provider, IContext context)
        {
            for (int i = 0; i < Handlers.Count; i++)
            {
                Handlers[i].Invoke(provider, context);
            }
        }
    }
}
