﻿using NUnit.Framework;

namespace UGF.Actions.Runtime.Tests
{
    public class TestActions
    {
        public class Target
        {
            public int Value { get; set; }
        }

        public readonly struct CommandAdd : IActionCommand
        {
            public int Value { get; }

            public CommandAdd(int value)
            {
                Value = value;
            }
        }

        public readonly struct CommandMultiply : IActionCommand
        {
            public int Value { get; }

            public CommandMultiply(int value)
            {
                Value = value;
            }
        }

        public class ActionAdd : Action<CommandAdd>
        {
            protected override void OnExecute(IActionProvider provider, IActionContext context, CommandAdd command)
            {
                var target = context.Get<Target>();

                target.Value += command.Value;
            }
        }

        public class ActionMultiply : Action<CommandMultiply>
        {
            protected override void OnExecute(IActionProvider provider, IActionContext context, CommandMultiply command)
            {
                var target = context.Get<Target>();

                target.Value *= command.Value;
            }
        }

        [Test]
        public void Basic()
        {
            var target = new Target();
            var provider = new ActionProvider();
            var context = new ActionContext { target };
            var system = new ActionSystem();

            system.Add(new ActionAdd());
            system.Add(new ActionMultiply());

            system.Execute(provider, context);

            Assert.AreEqual(0, target.Value);

            provider.Add(new CommandAdd(1));
            provider.Add(new CommandMultiply(4));
            provider.ApplyQueued();

            system.Execute(provider, context);

            Assert.AreEqual(4, target.Value);
        }
    }
}
