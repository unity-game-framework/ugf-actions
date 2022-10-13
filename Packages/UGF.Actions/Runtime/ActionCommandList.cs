using System;
using System.Collections;
using System.Collections.Generic;

namespace UGF.Actions.Runtime
{
    public class ActionCommandList<TCommand> : IActionCommandList<TCommand> where TCommand : IActionCommand
    {
        public int Count { get { return m_commands.Count; } }

        private readonly List<TCommand> m_commands;

        public ActionCommandList(int capacity = 64)
        {
            m_commands = new List<TCommand>(capacity);
        }

        public void Add(TCommand command)
        {
            m_commands.Add(command);
        }

        public void Add(TCommand command, int index)
        {
            if (index < 0 || index >= m_commands.Count) throw new ArgumentOutOfRangeException(nameof(index));

            m_commands.Insert(index, command);
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= m_commands.Count) throw new ArgumentOutOfRangeException(nameof(index));

            m_commands.RemoveAt(index);
        }

        public void Clear()
        {
            m_commands.Clear();
        }

        public T Get<T>(int index) where T : IActionCommand
        {
            return (T)(object)Get(index);
        }

        public TCommand Get(int index)
        {
            if (index < 0 || index >= m_commands.Count) throw new ArgumentOutOfRangeException(nameof(index));

            return m_commands[index];
        }

        public void CopyTo(IActionCommandList<TCommand> commands)
        {
            if (commands == null) throw new ArgumentNullException(nameof(commands));

            for (int i = 0; i < m_commands.Count; i++)
            {
                TCommand command = m_commands[i];

                commands.Add(command);
            }
        }

        public List<TCommand>.Enumerator GetEnumerator()
        {
            return m_commands.GetEnumerator();
        }

        void IActionCommandList.Add(IActionCommand command)
        {
            Add((TCommand)command);
        }

        void IActionCommandList.Add(IActionCommand command, int index)
        {
            Add((TCommand)command, index);
        }

        IActionCommand IActionCommandList.Get(int index)
        {
            return Get(index);
        }

        void IActionCommandList.CopyTo(IActionCommandList commands)
        {
            CopyTo((IActionCommandList<TCommand>)commands);
        }

        IEnumerator<IActionCommand> IEnumerable<IActionCommand>.GetEnumerator()
        {
            for (int i = 0; i < m_commands.Count; i++)
            {
                yield return m_commands[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_commands.GetEnumerator();
        }
    }
}
