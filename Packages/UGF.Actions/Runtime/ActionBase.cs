using System;
using Unity.Profiling;

namespace UGF.Actions.Runtime
{
    public abstract class ActionBase : IAction
    {
        private readonly ProfilerMarker m_marker;

#if ENABLE_PROFILER
        protected ActionBase()
        {
            m_marker = new ProfilerMarker(GetType().ToString());
        }
#endif

        public void Execute(IActionProvider provider, IActionContext context)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (context == null) throw new ArgumentNullException(nameof(context));

            m_marker.Begin();

            OnExecute(provider, context);

            m_marker.End();
        }

        protected abstract void OnExecute(IActionProvider provider, IActionContext context);
    }
}
