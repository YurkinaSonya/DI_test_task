using System.Collections.Generic;

namespace Game.Domain
{
    /// <summary>
    /// Default equipment composition strategy.
    /// </summary>
    public sealed class EquipmentFactory : IEquipmentFactory
    {
        public IEquipment Create(IEquipmentConfig config)
        {
            var equipment = new Equipment();

            if (config == null)
                return equipment;

            var items = new List<Item>
            {
                new Weapon(string.IsNullOrWhiteSpace(config.RifleName) ? "Rifle" : config.RifleName,
                           config.RifleAmmo),
                new RocketPack(config.RocketPackCharges)
            };

            if (config.HasParachute)
                items.Add(new Parachute());

            equipment.SetItems(items);
            return equipment;
        }
    }
}
