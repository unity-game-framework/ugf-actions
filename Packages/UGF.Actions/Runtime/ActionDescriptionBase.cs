namespace UGF.Actions.Runtime
{
    public abstract class ActionDescriptionBase : IActionDescription
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
