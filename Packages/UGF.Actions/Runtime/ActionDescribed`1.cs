using System;

namespace UGF.Actions.Runtime
{
    public abstract class ActionDescribed<TDescription> : ActionBase, IActionDescribed<TDescription> where TDescription : class, IActionDescription
    {
        public TDescription Description { get; }

        IActionDescription IActionDescribed.Description { get { return Description; } }

        protected ActionDescribed(TDescription description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}
