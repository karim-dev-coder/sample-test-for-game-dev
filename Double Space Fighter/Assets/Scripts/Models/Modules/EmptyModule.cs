public class EmptyModule : IModule
{
    public const string ID = "empty";
    public string Id { get; } = ID;

    public override string ToString()
    {
        return "Empty";
    }
}