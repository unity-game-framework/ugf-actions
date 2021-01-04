namespace UGF.Actions.Runtime
{
    public delegate bool ActionContextPredicate<in TArguments, in TValue>(TArguments arguments, TValue value);
}
