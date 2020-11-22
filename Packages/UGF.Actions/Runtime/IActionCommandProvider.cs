using System;
using System.Collections.Generic;

namespace UGF.Actions.Runtime
{
    public interface IActionCommandProvider
    {
        IReadOnlyDictionary<Type, IActionCommandStack> Commands { get; }
        IReadOnlyList<Type> Types { get; }

        void Add<T>(T command) where T : IActionCommand;
        void Add(IActionCommand command);
        void Add(Type type, IActionCommandStack commands);
        bool Remove(Type type);
        void Clear();
        void ClearCommands(Type type);
        void ClearCommandsAll();
        IActionCommandStack<T> Get<T>() where T : IActionCommand;
        IActionCommandStack Get(Type type);
        bool TryGet<T>(out IActionCommandStack<T> commands) where T : IActionCommand;
        bool TryGet(Type type, out IActionCommandStack commands);
    }
}
