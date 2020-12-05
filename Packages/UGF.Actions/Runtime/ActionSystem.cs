using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UGF.Actions.Runtime
{
    public class ActionSystem : ActionSystemBase
    {
        public override int Count { get { return m_actions.Count; } }
        public IReadOnlyList<IAction> Actions { get; }

        private readonly List<IAction> m_actions = new List<IAction>();

        public ActionSystem()
        {
            Actions = new ReadOnlyCollection<IAction>(m_actions);
        }

        public List<IAction>.Enumerator GetEnumerator()
        {
            return m_actions.GetEnumerator();
        }

        protected override void OnAdd(IAction action)
        {
            m_actions.Add(action);
        }

        protected override bool OnRemove(IAction action)
        {
            return m_actions.Remove(action);
        }

        protected override void OnClear()
        {
            m_actions.Clear();
        }

        protected override void OnExecute(IActionProvider provider, IActionContext context)
        {
            for (int i = 0; i < m_actions.Count; i++)
            {
                IAction action = m_actions[i];

                action.Execute(provider, context);
            }
        }

        protected override IEnumerator<IAction> OnGetEnumerator()
        {
            return m_actions.GetEnumerator();
        }
    }
}
