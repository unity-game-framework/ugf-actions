namespace UGF.Actions.Runtime
{
    public interface IActionCommandStack
    {
        int Count { get; }
        int Capacity { get; }

        void Add(IActionCommand command);
        void Clear();
        IActionCommand Get(int index);
    }
}
