namespace Interfaces
{
    public interface IItem : IItemSpawner, IItemDespawner, IClickable
    {
        int ClicksNeeded { get; set; }
        int ItemAddScore { get; set; }
        int ItemPointLoss { get; set; }
        int ItemLifeSpan { get; set; }
    }
}