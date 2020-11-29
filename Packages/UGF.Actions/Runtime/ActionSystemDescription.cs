using System;

namespace UGF.Actions.Runtime
{
    public class ActionSystemDescription : IActionSystemDescription
    {
        public string GroupId { get; }

        protected ActionSystemDescription(string groupId)
        {
            if (string.IsNullOrEmpty(groupId)) throw new ArgumentException("Value cannot be null or empty.", nameof(groupId));

            GroupId = groupId;
        }
    }
}
