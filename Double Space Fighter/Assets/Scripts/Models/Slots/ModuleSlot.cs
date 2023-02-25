public class ModuleSlot : ISlot<IModule>
{
    public IModule Module { get; private set; } = new EmptyModule();

    public void Set(IModule module)
    {
        Module = module;
    }
}