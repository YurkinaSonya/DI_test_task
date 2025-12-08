using UnityEngine;
using Zenject;
using Game.Core;
using Game.Core.Feature;
using static Game.Core.Events.EventsProvider;

namespace Game.Services
{
    /// <summary>
    /// Scene-bound demo initializer.
    /// </summary>
    public sealed class PlayerMutationDemoSystem : MonoBehaviour, IGameFeatureInitializable
    {
        private IEventAggregator _events;
        private IPlayerAttributeService _attributes;
        private IEquipmentRuntimeService _equipment;
        private bool _done;

        [Inject]
        private void Construct(
            IPlayerAttributeService attributes,
            IEquipmentRuntimeService equipment,
            IEventAggregator events)
        {
            _attributes = attributes;
            _equipment = equipment;
            _events = events;
        }

        public void Initialize()
        {
            _events.Subscribe<PlayerInitializedEvent>(OnPlayerInitialized);
        }

        private void OnPlayerInitialized(PlayerInitializedEvent _)
        {
            if (_done) return;
            _done = true;

            _attributes.SetHealth(85, nameof(PlayerMutationDemoSystem));
            _attributes.SetLives(2, nameof(PlayerMutationDemoSystem));
            _equipment.SetRifleAmmo(30, nameof(PlayerMutationDemoSystem));
            _equipment.SetRocketCharges(5, nameof(PlayerMutationDemoSystem));
            _events.Unsubscribe<PlayerInitializedEvent>(OnPlayerInitialized);
        }
    }
}
