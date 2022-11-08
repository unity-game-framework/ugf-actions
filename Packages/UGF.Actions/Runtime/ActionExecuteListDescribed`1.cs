using System;
using UGF.Description.Runtime;

namespace UGF.Actions.Runtime
{
    public abstract class ActionExecuteListDescribed<TDescription> : ActionExecuteList, IDescribed<IActionDescription> where TDescription : class, IActionDescription
    {
        public TDescription Description { get; }

        IActionDescription IDescribed<IActionDescription>.Description { get { return Description; } }

        protected ActionExecuteListDescribed(TDescription description)
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
