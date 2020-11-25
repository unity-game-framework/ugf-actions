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
            IActionSystem system = OnBuildSystem();

            OnBuildActions(system);

            return system;
        }

        protected virtual IActionSystem OnBuildSystem()
        {
            return new ActionSystem();
        }

        protected virtual void OnBuildActions(IActionSystem system)
        {
            foreach (KeyValuePair<string, IActionDescription> pair in Actions)
            {
                IActionDescription description = pair.Value;
                IAction action = description.Build();

                system.Add(action);
            }
        }
    }
}
