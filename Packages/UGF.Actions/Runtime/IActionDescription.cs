namespace UGF.Actions.Runtime
{
    public interface IActionDescription
    {
        T Build<T>() where T : class, IAction;
        IAction Build();
    }
}
