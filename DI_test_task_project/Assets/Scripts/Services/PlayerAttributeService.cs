using UnityEngine;
using Zenject;
using Game.Domain;
using Game.Core;
using static Game.Core.Events.EventsProvider;

namespace Game.Services
{
    /// <summary>
    /// Provides controlled mutation of player attributes.
    /// The service exists to demonstrate that state can be modified
    /// from multiple parts of the program via DI.
    /// </summary>
    public class PlayerAttributeService : MonoBehaviour, IPlayerAttributeService
    {
        private IPlayer _player;
        private IEventAggregator _events;

        [Inject]
        private void Construct(IPlayer player, IEventAggregator events)
        {
            _player = player;
            _events = events;
        }

        public void SetHealth(int value, string source = "Unknown")
        {
            _player.AddHealth(value);
            _events.Publish(new PlayerAttributeChangedEvent("Health", value.ToString(), source));
        }

        public void SetLives(int value, string source = "Unknown")
        {
            _player.AddLives(value);
            _events.Publish(new PlayerAttributeChangedEvent("Lives", value.ToString(), source));
        }

        public void SetNickname(string value, string source = "Unknown")
        {
            _player.SetNickname(value);
            _events.Publish(new PlayerAttributeChangedEvent("Nickname", value, source));
        }
    }
}
