using Game.Domain;

namespace Game.Core.Feature.Player
{
    /// <summary>
    /// Orchestrates the initial Player state based on injected configuration.
    /// </summary>
    public sealed class PlayerInitializer : IGameFeatureInitializable
    {
        private readonly IPlayerInitializable _playerState;
        private readonly IPlayerConfig _config;

        public PlayerInitializer(IPlayerInitializable playerState, IPlayerConfig config)
        {
            _playerState = playerState;
            _config = config;
        }

        /// <summary>
        /// Assigns initial attributes to the player.
        /// </summary>
        public void Initialize()
        {
            if (_playerState == null || _config == null)
                return;

            _playerState.InitializeState(
                _config.InitialHealth,
                _config.InitialLives,
                _config.InitialNickname,
                _config.InitialSkills
            );
        }
    }
}
