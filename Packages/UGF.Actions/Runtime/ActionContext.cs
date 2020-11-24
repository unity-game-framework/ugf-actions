using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UGF.Actions.Runtime
{
    public class ActionContext : IActionContext
    {
        public IReadOnlyList<object> Values { get; }

        private readonly List<object> m_values = new List<object>();

        public ActionContext()
        {
            Values = new ReadOnlyCollection<object>(m_values);
        }

        public void Add(object value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            m_values.Add(value);
        }

        public bool Remove(object value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            return m_values.Remove(value);
        }

        public T Get<T>() where T : class
        {
            return (T)Get(typeof(T));
        }

        public object Get(Type type)
        {
            return TryGet(type, out object value) ? value : throw new ArgumentException($"Value not found by the specified type: '{type}'.");
        }

        public bool TryGet<T>(out T value) where T : class
        {
            if (TryGet(typeof(T), out object result))
            {
                value = (T)result;
                return true;
            }

            value = default;
            return false;
        }

        public bool TryGet(Type type, out object value)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            for (int i = 0; i < m_values.Count; i++)
            {
                value = m_values[i];

                if (type.IsInstanceOfType(value))
                {
                    return true;
                }
            }

            value = default;
            return false;
        }

        public List<object>.Enumerator GetEnumerator()
        {
            return m_values.GetEnumerator();
        }

        IEnumerator<object> IEnumerable<object>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
