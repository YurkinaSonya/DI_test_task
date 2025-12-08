using UnityEngine;
using Zenject;
using Game.Core.Feature;

namespace Game.Services
{
    /// <summary>
    /// Scene-bound demo initializer.
    /// </summary>
    public sealed class PlayerMutationDemoSystem : MonoBehaviour, IGameFeatureInitializable
    {
        private IPlayerAttributeService _attributes;
        private IEquipmentRuntimeService _equipment;

        [Inject]
        private void Construct(
            IPlayerAttributeService attributes,
            IEquipmentRuntimeService equipment)
        {
            _attributes = attributes;
            _equipment = equipment;
        }

        public void Initialize()
        {
            _attributes.SetHealth(85, nameof(PlayerMutationDemoSystem));
            _attributes.SetLives(2, nameof(PlayerMutationDemoSystem));
            _equipment.SetRifleAmmo(30, nameof(PlayerMutationDemoSystem));
            _equipment.SetRocketCharges(5, nameof(PlayerMutationDemoSystem));
        }
    }
}
