namespace UGF.Actions.Runtime
{
    public class ActionSystemBuilder<TSystem> : ActionSystemBuilderBase where TSystem : class, IActionSystem, new()
    {
        protected override IActionSystem OnBuild()
        {
            return new TSystem();
        }
    }
}
