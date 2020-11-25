using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UGF.Actions.Runtime
{
    public class ActionCommandProvider : IActionCommandProvider
    {
        public IReadOnlyDictionary<Type, IActionCommandList> Commands { get; }

        private readonly Dictionary<Type, IActionCommandList> m_commands = new Dictionary<Type, IActionCommandList>();

        public ActionCommandProvider()
        {
            Commands = new ReadOnlyDictionary<Type, IActionCommandList>(m_commands);
        }

        public void Add<T>(T command) where T : IActionCommand
        {
            IActionCommandList<T> commands = Get<T>();

            commands.Add(command);
        }

        public void Add(IActionCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            Type type = command.GetType();
            IActionCommandList commands = Get(type);

            commands.Add(command);
        }

        public void Add(Type type, IActionCommandList commands)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (commands == null) throw new ArgumentNullException(nameof(commands));

            m_commands.Add(type, commands);
        }

        public bool Remove(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return m_commands.Remove(type);
        }

        public void Clear()
        {
            m_commands.Clear();
        }

        public void ClearCommands(Type type)
        {
            IActionCommandList commands = Get(type);

            commands.Clear();
        }

        public void ClearCommandsAll()
        {
            foreach (KeyValuePair<Type, IActionCommandList> pair in m_commands)
            {
                pair.Value.Clear();
            }
        }

        public void CopyTo(IActionCommandProvider provider)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));

            foreach (KeyValuePair<Type, IActionCommandList> pair in m_commands)
            {
                if (provider.TryGet(pair.Key, out IActionCommandList commands))
                {
                    pair.Value.CopyTo(commands);
                }
            }
        }

        public IActionCommandList<T> Get<T>() where T : IActionCommand
        {
            return TryGet(out IActionCommandList<T> commands) ? commands : throw new ArgumentException($"Commands not found by the specified type: '{typeof(T)}'.");
        }

        public IActionCommandList Get(Type type)
        {
            return TryGet(type, out IActionCommandList commands) ? commands : throw new ArgumentException($"Commands not found by the specified type: '{type}'.");
        }

        public bool TryGet<T>(out IActionCommandList<T> commands) where T : IActionCommand
        {
            if (TryGet(typeof(T), out IActionCommandList value))
            {
                commands = (IActionCommandList<T>)value;
                return true;
            }

            commands = null;
            return false;
        }

        public bool TryGet(Type type, out IActionCommandList commands)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return m_commands.TryGetValue(type, out commands);
        }

        public Dictionary<Type, IActionCommandList>.Enumerator GetEnumerator()
        {
            return m_commands.GetEnumerator();
        }
    }
}
