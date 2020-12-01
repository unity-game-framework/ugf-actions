using System;
using UGF.Description.Runtime;

namespace UGF.Actions.Runtime
{
    public abstract class ActionDescribed<TDescription> : ActionBase, IActionDescribed where TDescription : class, IActionDescription
    {
        public TDescription Description { get; }

        IActionDescription IDescribed<IActionDescription>.Description { get { return Description; } }

        protected ActionDescribed(TDescription description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public T GetDescription<T>() where T : class, IDescription
        {
            return (T)GetDescription();
        }

        public IDescription GetDescription()
        {
            return Description;
        }
    }
}
