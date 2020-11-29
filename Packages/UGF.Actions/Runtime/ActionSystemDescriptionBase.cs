using System;

namespace UGF.Actions.Runtime
{
    public abstract class ActionSystemDescriptionBase : IActionSystemDescription
    {
        public string GroupId { get; }

        protected ActionSystemDescriptionBase(string groupId)
        {
            if (string.IsNullOrEmpty(groupId)) throw new ArgumentException("Value cannot be null or empty.", nameof(groupId));

            GroupId = groupId;
        }
    }
}
