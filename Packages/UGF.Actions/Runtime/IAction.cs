namespace UGF.Actions.Runtime
{
    public interface IAction
    {
        void Execute(IActionProvider provider, IActionContext context);
    }
}
