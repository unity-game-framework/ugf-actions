namespace UGF.Actions.Runtime
{
    public abstract class ActionBuilderBase : IActionBuilder
    {
        public T Build<T>() where T : class, IAction
        {
            return (T)OnBuild();
        }

        public IAction Build()
        {
            return OnBuild();
        }

        protected abstract IAction OnBuild();
    }
}
