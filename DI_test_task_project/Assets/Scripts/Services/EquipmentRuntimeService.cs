using UnityEngine;
using Zenject;
using System.Linq;
using Game.Domain;
using Game.Core;
using static Game.Core.Events.EventsProvider;

namespace Game.Services
{
    /// <summary>
    /// Demonstrates runtime equipment parameter changes driven by DI.
    /// </summary>
    public class EquipmentRuntimeService : MonoBehaviour, IEquipmentRuntimeService
    {
        private IPlayer _player;
        private IEventAggregator _events;

        [Inject]
        public void Construct(IPlayer player, IEventAggregator events)
        {
            _player = player;
            _events = events;
        }

        public void SetRifleAmmo(int ammo, string source = "Unknown")
        {
            var weapon = _player.Equipment.Items.OfType<Weapon>().FirstOrDefault();
            if (weapon == null) return;

            weapon.SetAmmo(ammo);

            _events.Publish(new PlayerAttributeChangedEvent("RifleAmmo", ammo.ToString(), source));
            _events.Publish(new EquipmentParamsChangedEvent(weapon.Ammo, GetRocketCharges()));
        }

        public void SetRocketCharges(int charges, string source = "Unknown")
        {
            var rocket = _player.Equipment.Items.OfType<RocketPack>().FirstOrDefault();
            if (rocket == null) return;

            rocket.SetCharges(charges);

            _events.Publish(new PlayerAttributeChangedEvent("RocketPackCharges", charges.ToString(), source));
            _events.Publish(new EquipmentParamsChangedEvent(GetRifleAmmo(), rocket.Charges));
        }

        private int GetRifleAmmo()
        {
            return _player.Equipment.Items.OfType<Weapon>().FirstOrDefault()?.Ammo ?? 0;
        }

        private int GetRocketCharges()
        {
            return _player.Equipment.Items.OfType<RocketPack>().FirstOrDefault()?.Charges ?? 0;
        }
    }
}
