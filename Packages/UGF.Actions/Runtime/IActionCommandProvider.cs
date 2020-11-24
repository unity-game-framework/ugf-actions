using System;
using System.Collections.Generic;

namespace UGF.Actions.Runtime
{
    public interface IActionCommandProvider
    {
        IReadOnlyDictionary<Type, IActionCommandList> Commands { get; }
        IReadOnlyList<Type> Types { get; }

        void Add<T>(T command) where T : IActionCommand;
        void Add(IActionCommand command);
        void Add(Type type, IActionCommandList commands);
        bool Remove(Type type);
        void Clear();
        void ClearCommands(Type type);
        void ClearCommandsAll();
        IActionCommandList<T> Get<T>() where T : IActionCommand;
        IActionCommandList Get(Type type);
        bool TryGet<T>(out IActionCommandList<T> commands) where T : IActionCommand;
        bool TryGet(Type type, out IActionCommandList commands);
    }
}
