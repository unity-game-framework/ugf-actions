namespace UGF.Actions.Runtime
{
    public interface IActionSystemBuilder
    {
        T Build<T>() where T : class, IActionSystem;
        IActionSystem Build();
    }
}
