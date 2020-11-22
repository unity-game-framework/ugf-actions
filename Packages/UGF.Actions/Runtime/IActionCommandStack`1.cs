namespace UGF.Actions.Runtime
{
    public interface IActionCommandStack<TCommand> : IActionCommandStack where TCommand : IActionCommand
    {
        void Add(TCommand command);
        new ref TCommand Get(int index);
    }
}
