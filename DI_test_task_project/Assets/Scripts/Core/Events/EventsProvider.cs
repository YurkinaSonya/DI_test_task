using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.Events
{
    /// <summary>
    /// Specific container of event-like classes for EventAggregator.
    /// There defines this classes as basical containers of data, 
    /// transferring cross parts of system by events.
    /// </summary>
    public static class EventsProvider
    {
        /// <summary>
        /// Signals that the Player initial state has been applied.
        /// </summary>
        public readonly struct PlayerInitializedEvent
        {
            public readonly int Health;
            public readonly int Lives;
            public readonly string Nickname;
            public readonly IReadOnlyList<string> Skills;

            public PlayerInitializedEvent(
                int health,
                int lives,
                string nickname,
                IReadOnlyList<string> skills)
            {
                Health = health;
                Lives = lives;
                Nickname = nickname;
                Skills = skills;
            }
        }

        /// <summary>
        /// Signals that a player attribute has been mutated by a system,
        /// created for point №9 of test task.
        /// </summary>
        public readonly struct PlayerAttributeChangedEvent
        {
            public readonly string Attribute;
            public readonly string Value;
            public readonly string Source;

            public PlayerAttributeChangedEvent(string attribute, string value, string source)
            {
                Attribute = attribute;
                Value = value;
                Source = source;
            }
        }

        /// <summary>
        /// Signals that equipment parameters were changed at runtime.
        /// </summary>
        public readonly struct EquipmentParamsChangedEvent
        {
            public readonly int RifleAmmo;
            public readonly int RocketPackCharges;

            public EquipmentParamsChangedEvent(int rifleAmmo, int rocketPackCharges)
            {
                RifleAmmo = rifleAmmo;
                RocketPackCharges = rocketPackCharges;
            }
        }
    }
}