namespace Game.Domain
{
    /// <summary>
    /// Represents a rocket pack with configurable charges.
    /// </summary>
    public sealed class RocketPack : Item
    {
        public int Charges { get; private set; }

        public RocketPack(int charges) : base("RocketPack")
        {
            Charges = charges;
        }

        /// <summary>
        /// Updates charge count.
        /// </summary>
        public void SetCharges(int charges)
        {
            Charges = charges;
        }
    }
}
