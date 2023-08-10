namespace Interfaces
{
    public interface IItem : IItemSpawner, IItemDespawner, IClickable
    {
        int ItemAddScore { get; set; }
        int ItemPointLoss { get; set; }
        int ItemLifeSpan { get; set; }
    }
}