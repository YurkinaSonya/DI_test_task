namespace Game.Domain
{
    /// <summary>
    /// Provides initial equipment parameters.
    /// </summary>
    public interface IEquipmentConfig
    {
        string RifleName { get; }
        int RifleAmmo { get; }

        bool HasParachute { get; }

        int RocketPackCharges { get; }
    }
}
