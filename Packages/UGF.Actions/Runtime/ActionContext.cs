using System;
using System.Collections;
using System.Collections.Generic;

namespace UGF.Actions.Runtime
{
    public class ActionContext : IActionContext
    {
        private readonly Dictionary<Type, List<object>> m_values = new Dictionary<Type, List<object>>();

        public void Add(object value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            Type type = value.GetType();

            if (!m_values.TryGetValue(type, out List<object> values))
            {
                values = new List<object>();

                m_values.Add(type, values);
            }

            values.Add(value);
        }

        public bool Remove(object value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            Type type = value.GetType();

            if (m_values.TryGetValue(type, out List<object> values) && values.Remove(value))
            {
                if (values.Count == 0)
                {
                    m_values.Remove(type);
                }

                return true;
            }

            return false;
        }

        public T Get<TArguments, T>(TArguments arguments, Func<TArguments, T, bool> predicate)
        {
            return TryGet(arguments, predicate, out T value) ? value : throw new ArgumentException($"Value not found by the specified predicate: '{predicate}'.");
        }

        public object Get<TArguments>(TArguments arguments, Func<TArguments, object, bool> predicate)
        {
            return TryGet(arguments, predicate, out object value) ? value : throw new ArgumentException($"Value not found by the specified predicate: '{predicate}'.");
        }

        public T Get<T>() where T : class
        {
            return (T)Get(typeof(T));
        }

        public object Get(Type type)
        {
            return TryGet(type, out object value) ? value : throw new ArgumentException($"Value not found by the specified type: '{type}'.");
        }

        public bool TryGet<TArguments, T>(TArguments arguments, Func<TArguments, T, bool> predicate, out T value)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            foreach (KeyValuePair<Type, List<object>> pair in m_values)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    object element = pair.Value[i];

                    if (element is T target && predicate(arguments, target))
                    {
                        value = target;
                        return true;
                    }
                }
            }

            value = default;
            return false;
        }

        public bool TryGet<TArguments>(TArguments arguments, Func<TArguments, object, bool> predicate, out object value)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            foreach (KeyValuePair<Type, List<object>> pair in m_values)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    value = pair.Value[i];

                    if (predicate(arguments, value))
                    {
                        return true;
                    }
                }
            }

            value = default;
            return false;
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

            if (m_values.TryGetValue(type, out List<object> values))
            {
                value = values[0];
                return true;
            }

            value = default;
            return false;
        }

        public IEnumerator<object> GetEnumerator()
        {
            foreach (KeyValuePair<Type, List<object>> pair in m_values)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    object value = pair.Value[i];

                    yield return value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
