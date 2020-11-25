namespace UGF.Actions.Runtime
{
    public interface IActionDescribed : IAction
    {
        IActionDescription Description { get; }
    }
}
