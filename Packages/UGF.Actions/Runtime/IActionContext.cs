using System;
using System.Collections.Generic;

namespace UGF.Actions.Runtime
{
    public interface IActionContext : IEnumerable<object>
    {
        void Add(object value);
        bool Remove(object value);
        T Get<T>() where T : class;
        object Get(Type type);
        bool TryGet<T>(out T value) where T : class;
        bool TryGet(Type type, out object value);
    }
}
