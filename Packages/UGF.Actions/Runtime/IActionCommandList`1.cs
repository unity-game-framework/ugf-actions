namespace UGF.Actions.Runtime
{
    public interface IActionCommandList<TCommand> : IActionCommandList where TCommand : IActionCommand
    {
        void Add(TCommand command);
        void Add(TCommand command, int index);
        new TCommand Get(int index);
        void CopyTo(IActionCommandList<TCommand> commands);
    }
}
