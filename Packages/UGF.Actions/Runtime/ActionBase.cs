using System;

namespace UGF.Actions.Runtime
{
    public abstract class ActionBase : IAction
    {
        public void Execute(IActionProvider provider, IActionContext context)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (context == null) throw new ArgumentNullException(nameof(context));

            OnExecute(provider, context);
        }

        protected abstract void OnExecute(IActionProvider provider, IActionContext context);
    }
}
