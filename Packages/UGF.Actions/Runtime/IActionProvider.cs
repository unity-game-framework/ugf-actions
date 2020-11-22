namespace UGF.Actions.Runtime
{
    public interface IActionProvider
    {
        IActionCommandProvider Current { get; }
        IActionCommandProvider Queued { get; }

        void Add<T>(T command) where T : IActionCommand;
        void Add(IActionCommand command);
        void Apply();
        void Clear();
    }
}
