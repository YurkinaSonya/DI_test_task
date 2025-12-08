using UnityEngine;
using Zenject;
using Game.Core;
using static Game.Core.Events.EventsProvider;

namespace Game.Core.Visual
{
    public class PlayerDebugPresenter : IInitializable, System.IDisposable
    {
        private readonly IEventAggregator _events;
        private readonly IPlayerDebugView _view;

        public PlayerDebugPresenter(
            IEventAggregator events,
            IPlayerDebugView view)
        {
            _events = events;
            _view = view;
        }

        /// <summary>
        /// Registers project-scoped listeners for player-related events.
        /// </summary>
        public void Initialize()
        {
            _events.Subscribe<PlayerInitializedEvent>(OnPlayerInitialized);
            _events.Subscribe<PlayerAttributeChangedEvent>(OnPlayerAttributeChanged);
            _events.Subscribe<EquipmentParamsChangedEvent>(OnEquipmentParamsChanged);

            _view.ShowHeader("Player Debug Overlay");
            _view.ShowLine("Waiting for scene publishers...");
        }

        public void Dispose()
        {
            _events.Unsubscribe<PlayerInitializedEvent>(OnPlayerInitialized);
            _events.Unsubscribe<PlayerAttributeChangedEvent>(OnPlayerAttributeChanged);
            _events.Unsubscribe<EquipmentParamsChangedEvent>(OnEquipmentParamsChanged);
        }

        private void OnPlayerInitialized(PlayerInitializedEvent e)
        {
            _view.ShowHeader("Player Initialized");
            _view.ShowLine($"HP: {e.Health}, Lives: {e.Lives}, Nick: {e.Nickname}");
            _view.ShowLine($"Skills: {(e.Skills == null ? "-" : string.Join(", ", e.Skills))}");
        }

        private void OnPlayerAttributeChanged(PlayerAttributeChangedEvent e)
        {
            _view.ShowLine($"[ATTR] {e.Attribute} = {e.Value} (by {e.Source})");
        }

        private void OnEquipmentParamsChanged(EquipmentParamsChangedEvent e)
        {
            _view.ShowLine($"[EQUIP] RifleAmmo={e.RifleAmmo}, RocketCharges={e.RocketPackCharges}");
        }
    }
}
