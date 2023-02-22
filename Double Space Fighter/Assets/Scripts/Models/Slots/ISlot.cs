public interface ISlot<in TSlotItem>
{
    public void Set(TSlotItem item);
}