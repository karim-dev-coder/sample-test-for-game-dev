public class ModuleSlot : ISlot<IModule>
{
    public IModule Module { get; private set; }

    public void Set(IModule module)
    {
        Module = module;
    }
}