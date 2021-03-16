using System;
using System.Collections;
using System.Collections.Generic;
using UGF.RuntimeTools.Runtime.Contexts;
using Unity.Profiling;

namespace UGF.Actions.Runtime
{
    public abstract class ActionSystemBase : IActionSystem
    {
        public abstract int Count { get; }

        private readonly ProfilerMarker m_marker;

#if ENABLE_PROFILER
        protected ActionSystemBase()
        {
            m_marker = new ProfilerMarker(GetType().ToString());
        }
#endif

        public void Add(IAction action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            OnAdd(action);
        }

        public bool Remove(IAction action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            return OnRemove(action);
        }

        public void Clear()
        {
            OnClear();
        }

        public void Execute(IActionProvider provider, IContext context)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (context == null) throw new ArgumentNullException(nameof(context));

            m_marker.Begin();

            OnExecute(provider, context);

            m_marker.End();
        }

        protected abstract void OnAdd(IAction action);
        protected abstract bool OnRemove(IAction action);
        protected abstract void OnClear();
        protected abstract void OnExecute(IActionProvider provider, IContext context);
        protected abstract IEnumerator<IAction> OnGetEnumerator();

        IEnumerator<IAction> IEnumerable<IAction>.GetEnumerator()
        {
            return OnGetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return OnGetEnumerator();
        }
    }
}
