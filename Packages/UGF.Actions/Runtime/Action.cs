using Unity.Profiling;

// ReSharper disable StaticMemberInGenericType

namespace UGF.Actions.Runtime
{
    public abstract class Action<TCommand> : ActionBase where TCommand : IActionCommand
    {
        private static readonly ProfilerMarker m_marker;

#if ENABLE_PROFILER
        static Action()
        {
            m_marker = new ProfilerMarker($"Action<{typeof(TCommand).Name}>");
        }
#endif

        protected override void OnExecute(IActionProvider provider, IActionContext context)
        {
            m_marker.Begin();

            if (provider.Current.TryGet(out IActionCommandList<TCommand> commands))
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    TCommand command = commands.Get(i);

                    OnExecute(provider, context, command);
                }
            }

            m_marker.End();
        }

        protected abstract void OnExecute(IActionProvider provider, IActionContext context, TCommand command);
    }
}
