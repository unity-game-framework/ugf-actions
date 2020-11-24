using System.Collections.Generic;

namespace UGF.Actions.Runtime
{
    public interface IActionCommandList : IEnumerable<IActionCommand>
    {
        int Count { get; }

        void Add(IActionCommand command);
        void Add(IActionCommand command, int index);
        void Remove(int index);
        void Clear();
        T Get<T>(int index) where T : IActionCommand;
        IActionCommand Get(int index);
        void CopyTo(IActionCommandList commands);
    }
}
