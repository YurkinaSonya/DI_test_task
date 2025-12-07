namespace Game.Domain
{
    /// <summary>
    /// Produces equipment instances based on configuration.
    /// Created for logic of 12 point is test task.
    /// </summary>
    public interface IEquipmentFactory
    {
        IEquipment Create(IEquipmentConfig config);
    }
}
