using System.Collections.Generic;

namespace UGF.Actions.Runtime
{
    public class ActionSystemDescription : ActionSystemDescriptionBase
    {
        public ActionSystemDescription(string groupId) : base(groupId)
        {
        }

        protected override IActionSystem OnBuild()
        {
            var system = new ActionSystem();

            foreach (KeyValuePair<string, IActionDescription> pair in Actions)
            {
                IActionDescription description = pair.Value;
                IAction action = description.Build();

                system.Add(action);
            }

            return system;
        }
    }
}
