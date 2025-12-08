namespace Game.Services
{
    public interface IEquipmentRuntimeService
    {
        void SetRifleAmmo(int ammo, string source = "Unknown");
        void SetRocketCharges(int charges, string source = "Unknown");
    }
}