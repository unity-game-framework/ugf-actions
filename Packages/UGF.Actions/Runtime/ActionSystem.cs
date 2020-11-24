using Unity.Profiling;

namespace UGF.Actions.Runtime
{
    public class ActionSystem : ActionSystemBase
    {
        private static readonly ProfilerMarker m_marker;

#if ENABLE_PROFILER
        static ActionSystem()
        {
            m_marker = new ProfilerMarker("ActionSystem");
        }
#endif

        protected override void OnExecute(IActionProvider provider, IActionContext context)
        {
            m_marker.Begin();

            for (int i = 0; i < Actions.Count; i++)
            {
                IAction action = Actions[i];

                action.Execute(provider, context);
            }

            m_marker.End();
        }
    }
}
