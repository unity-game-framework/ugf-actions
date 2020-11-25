namespace UGF.Actions.Runtime
{
    public class ActionDescription<TAction> : ActionDescriptionBase where TAction : class, IAction, new()
    {
        protected override IAction OnBuild()
        {
            return new TAction();
        }
    }
}
