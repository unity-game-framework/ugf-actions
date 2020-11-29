namespace UGF.Actions.Runtime
{
    public abstract class ActionSystemBuilderBase : IActionSystemBuilder
    {
        public T Build<T>() where T : class, IActionSystem
        {
            return (T)OnBuild();
        }

        public IActionSystem Build()
        {
            return OnBuild();
        }

        protected abstract IActionSystem OnBuild();
    }
}
