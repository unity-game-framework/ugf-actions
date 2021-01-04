using System;
using System.Collections.Generic;

namespace UGF.Actions.Runtime
{
    public interface IActionContext : IEnumerable<object>
    {
        void Add(object value);
        bool Remove(object value);
        T Get<TArguments, T>(TArguments arguments, ActionContextPredicate<TArguments, T> predicate);
        object Get<TArguments>(TArguments arguments, ActionContextPredicate<TArguments, object> predicate);
        T Get<T>() where T : class;
        object Get(Type type);
        bool TryGet<TArguments, T>(TArguments arguments, ActionContextPredicate<TArguments, T> predicate, out T value);
        bool TryGet<TArguments>(TArguments arguments, ActionContextPredicate<TArguments, object> predicate, out object value);
        bool TryGet<T>(out T value) where T : class;
        bool TryGet(Type type, out object value);
    }
}
