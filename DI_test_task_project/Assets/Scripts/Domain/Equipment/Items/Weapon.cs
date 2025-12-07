namespace Game.Domain
{
    /// <summary>
    /// Represents a weapon with configurable ammo.
    /// </summary>
    public sealed class Weapon : Item
    {
        public int Ammo { get; private set; }

        public Weapon(string name, int ammo) : base(name)
        {
            Ammo = ammo;
        }

        /// <summary>
        /// Updates ammo count.
        /// Exposed to demonstrate that equipment parameters can be adjusted at runtime.
        /// </summary>
        public void SetAmmo(int ammo)
        {
            Ammo = ammo;
        }
    }
}
