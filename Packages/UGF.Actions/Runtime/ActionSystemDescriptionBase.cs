using System;
using System.Collections.Generic;

namespace UGF.Actions.Runtime
{
    public abstract class ActionSystemDescriptionBase : IActionSystemDescription
    {
        public string GroupId { get; }
        public Dictionary<string, IActionDescription> Actions { get; } = new Dictionary<string, IActionDescription>();

        IReadOnlyDictionary<string, IActionDescription> IActionSystemDescription.Actions { get { return Actions; } }

        protected ActionSystemDescriptionBase(string groupId)
        {
            if (string.IsNullOrEmpty(groupId)) throw new ArgumentException("Value cannot be null or empty.", nameof(groupId));

            GroupId = groupId;
        }

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
