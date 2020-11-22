using System;

namespace UGF.Actions.Runtime
{
    public class ActionProvider : IActionProvider
    {
        public IActionCommandProvider Current { get; }
        public IActionCommandProvider Queued { get; }

        public ActionProvider() : this(new ActionCommandProvider(), new ActionCommandProvider())
        {
        }

        public ActionProvider(IActionCommandProvider current, IActionCommandProvider queued)
        {
            Current = current ?? throw new ArgumentNullException(nameof(current));
            Queued = queued ?? throw new ArgumentNullException(nameof(queued));
        }

        public void Add<T>(T command) where T : IActionCommand
        {
            Queued.Add(command);
        }

        public void Add(IActionCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            Queued.Add(command);
        }

        public void ApplyQueued()
        {
            Current.ClearCommandsAll();

            for (int i = 0; i < Queued.Types.Count; i++)
            {
                Type type = Queued.Types[i];
                IActionCommandStack current = Current.Get(type);
                IActionCommandStack queued = Queued.Get(type);

                current.CopyFrom(queued);
            }

            Queued.ClearCommandsAll();
        }

        public void ClearCommands()
        {
            Current.ClearCommandsAll();
            Queued.ClearCommandsAll();
        }

        public void Clear()
        {
            Current.Clear();
            Queued.Clear();
        }
    }
}
