using System;

namespace UGF.Actions.Runtime
{
    public class ActionCommandStack<TCommand> : IActionCommandStack<TCommand> where TCommand : unmanaged, IActionCommand
    {
        public int Count { get; private set; }
        public int Capacity { get { return m_commands.Length; } }

        private readonly TCommand[] m_commands;

        public ActionCommandStack(int capacity = 64)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));

            m_commands = new TCommand[capacity];
        }

        public void Add(TCommand command)
        {
            if (Count >= Capacity) throw new InvalidOperationException("Capacity of internal collection is exceeded.");

            m_commands[++Count] = command;
        }

        public void Clear()
        {
            Count = 0;
        }

        public ref TCommand Get(int index)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));

            return ref m_commands[index];
        }

        void IActionCommandStack.Add(IActionCommand command)
        {
            Add((TCommand)command);
        }

        IActionCommand IActionCommandStack.Get(int index)
        {
            return Get(index);
        }
    }
}
