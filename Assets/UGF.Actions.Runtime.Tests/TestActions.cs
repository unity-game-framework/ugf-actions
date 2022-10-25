using NUnit.Framework;
using UGF.RuntimeTools.Runtime.Contexts;

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

        public class ActionAdd : ActionBase<CommandAdd>
        {
            protected override void OnExecute(IActionProvider provider, IContext context, CommandAdd command)
            {
                var target = context.Get<Target>();

                target.Value += command.Value;
            }
        }

        public class ActionMultiply : ActionBase<CommandMultiply>
        {
            protected override void OnExecute(IActionProvider provider, IContext context, CommandMultiply command)
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
            var context = new Context { target };
            var system = new ActionSystem { new ActionAdd(), new ActionMultiply() };

            system.Execute(provider, context);

            Assert.AreEqual(0, target.Value);

            provider.Add(new CommandAdd(2));
            provider.Add(new CommandMultiply(2));
            provider.ApplyQueued();

            system.Execute(provider, context);

            Assert.AreEqual(4, target.Value);
        }
    }
}
