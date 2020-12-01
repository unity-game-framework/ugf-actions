using UGF.Description.Runtime;

namespace UGF.Actions.Runtime
{
    public interface IActionDescribed : IAction, IDescribed<IActionDescription>
    {
    }
}
