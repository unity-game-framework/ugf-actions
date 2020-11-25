namespace UGF.Actions.Runtime
{
    public interface IActionDescribed<out TDescription> : IActionDescribed where TDescription : class, IActionDescription
    {
        new TDescription Description { get; }
    }
}
