using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UGF.Actions.Runtime
{
    public abstract class ActionSystemBase : IActionSystem
    {
        public IReadOnlyList<IAction> Actions { get; }

        private readonly List<IAction> m_actions = new List<IAction>();

        protected ActionSystemBase()
        {
            Actions = new ReadOnlyCollection<IAction>(m_actions);
        }

        public void Add(IAction action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            m_actions.Add(action);
        }

        public bool Remove(IAction action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            return m_actions.Remove(action);
        }

        public void Clear()
        {
            m_actions.Clear();
        }

        public void Execute(IActionProvider provider, IActionContext context)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (context == null) throw new ArgumentNullException(nameof(context));

            OnExecute(provider, context);
        }

        protected abstract void OnExecute(IActionProvider provider, IActionContext context);
    }
}
