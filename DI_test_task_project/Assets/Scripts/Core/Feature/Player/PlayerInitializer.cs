using UnityEngine;
using Game.Domain;
using static Game.Core.Events.EventsProvider;

namespace Game.Core.Feature.Player
{
    /// <summary>
    /// Orchestrates the initial Player state based on injected configuration.
    /// </summary>
    public sealed class PlayerInitializer : IGameFeatureInitializable
    {
        private readonly IPlayerInitializable _playerState;
        private readonly IPlayerConfig _playerConfig;
        private readonly IEventAggregator _events;

        public PlayerInitializer(IPlayerInitializable playerState, IPlayerConfig playerConfig, IEventAggregator events)
        {
            _playerState = playerState;
            _playerConfig = playerConfig;
            _events = events;
        }

        /// <summary>
        /// Assigns initial attributes to the player.
        /// </summary>
        public void Initialize()
        {
            if (_playerState == null || _playerConfig == null)
                return;

            _playerState.InitializeState(
                _playerConfig.InitialHealth,
                _playerConfig.InitialLives,
                _playerConfig.InitialNickname,
                _playerConfig.InitialSkills
            );

            if (_events == null)
                return;

            _events.Publish(new PlayerInitializedEvent(
                _playerConfig.InitialHealth,
                _playerConfig.InitialLives,
                _playerConfig.InitialNickname,
                _playerConfig.InitialSkills
            ));
        }

    }
}
