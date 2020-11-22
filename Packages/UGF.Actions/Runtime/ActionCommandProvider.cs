using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UGF.Actions.Runtime
{
    public class ActionCommandProvider : IActionCommandProvider
    {
        public IReadOnlyDictionary<Type, IActionCommandStack> Commands { get; }
        public IReadOnlyList<Type> Types { get; }

        private readonly Dictionary<Type, IActionCommandStack> m_commands = new Dictionary<Type, IActionCommandStack>();
        private readonly List<Type> m_types = new List<Type>();

        public ActionCommandProvider()
        {
            Commands = new ReadOnlyDictionary<Type, IActionCommandStack>(m_commands);
            Types = new ReadOnlyCollection<Type>(m_types);
        }

        public void Add<T>(T command) where T : IActionCommand
        {
            IActionCommandStack<T> commands = Get<T>();

            commands.Add(command);
        }

        public void Add(IActionCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            Type type = command.GetType();
            IActionCommandStack commands = Get(type);

            commands.Add(command);
        }

        public void Add(Type type, IActionCommandStack commands)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (commands == null) throw new ArgumentNullException(nameof(commands));

            m_commands.Add(type, commands);
            m_types.Add(type);
        }

        public bool Remove(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            if (m_commands.Remove(type))
            {
                m_types.Remove(type);
            }

            return false;
        }

        public void Clear()
        {
            m_commands.Clear();
        }

        public void ClearCommands(Type type)
        {
            IActionCommandStack commands = Get(type);

            commands.Clear();
        }

        public void ClearCommandsAll()
        {
            foreach (KeyValuePair<Type, IActionCommandStack> pair in m_commands)
            {
                pair.Value.Clear();
            }
        }

        public IActionCommandStack<T> Get<T>() where T : IActionCommand
        {
            return TryGet(out IActionCommandStack<T> commands) ? commands : throw new ArgumentException($"Commands not found by the specified type: '{typeof(T)}'.");
        }

        public IActionCommandStack Get(Type type)
        {
            return TryGet(type, out IActionCommandStack commands) ? commands : throw new ArgumentException($"Commands not found by the specified type: '{type}'.");
        }

        public bool TryGet<T>(out IActionCommandStack<T> commands) where T : IActionCommand
        {
            if (TryGet(typeof(T), out IActionCommandStack value))
            {
                commands = (IActionCommandStack<T>)value;
                return true;
            }

            commands = null;
            return false;
        }

        public bool TryGet(Type type, out IActionCommandStack commands)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return m_commands.TryGetValue(type, out commands);
        }

        public Dictionary<Type, IActionCommandStack>.Enumerator GetEnumerator()
        {
            return m_commands.GetEnumerator();
        }
    }
}
