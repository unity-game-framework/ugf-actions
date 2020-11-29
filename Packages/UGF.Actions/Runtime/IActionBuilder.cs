namespace UGF.Actions.Runtime
{
    public interface IActionBuilder
    {
        T Build<T>() where T : class, IAction;
        IAction Build();
    }
}
