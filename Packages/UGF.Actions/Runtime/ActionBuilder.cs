namespace UGF.Actions.Runtime
{
    public class ActionBuilder<TAction> : ActionBuilderBase where TAction : class, IAction, new()
    {
        protected override IAction OnBuild()
        {
            return new TAction();
        }
    }
}
