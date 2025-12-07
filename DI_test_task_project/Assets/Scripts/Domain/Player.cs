using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Domain
{
    /// <summary>
    /// Default domain implementation of the player entity.
    /// </summary>
    public sealed class Player : IPlayer
    {
        private int _health;
        private int _lives;
        private string _nickname = string.Empty;
        private List<string> _skills = new();

        public int Health => _health;
        public int Lives => _lives;
        public string Nickname => _nickname;
        public IReadOnlyList<string> Skills => _skills;

        public IEquipment Equipment { get; }

        public Player(IEquipmentFactory equipmentFactory, IEquipmentConfig equipmentConfig)
        {
            Equipment = equipmentFactory?.Create(equipmentConfig) ?? new Equipment();
        }

        /// <summary>
        /// Method for assigning the initial player state.
        /// </summary>
        internal void Initialize(int health, int lives, string nickname, IEnumerable<string> skills)
        {
            _health = Math.Max(0, health);
            _lives = Math.Max(0, lives);
            _nickname = NormalizeNickname(nickname);
            SetSkills(skills);
        }

        /// <summary>
        /// Replaces the current skill set.
        /// Empty, dublicated and whitespace values are ignored.
        /// </summary>
        public void SetSkills(IEnumerable<string> skills)
        {
            _skills = skills?
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList()
                ?? new List<string>();
        }

        /// <summary>
        /// Applies damage to player's health.
        /// </summary>
        public void ApplyDamage(int damage)
        {
            if (damage <= 0) return;

            _health -= damage;
            if (_health < 0) _health = 0;
        }

        /// <summary>
        /// Increases current health.
        /// </summary>
        public void AddHealth(int amount)
        {
            //checking for avoiding self-damage.
            if (amount <= 0) return;

            // There are no upper-bounds, but it can be added later.
            _health += amount;
        }

        /// <summary>
        /// Increases current health.
        /// </summary>
        public void AddLives(int amount)
        {
            //checking for avoiding self-destruction.
            if (amount <= 0) return;

            // There are no upper-bounds, but it can be added later.
            _lives += amount;
        }

        /// <summary>
        /// Updates player's nickname.
        /// The value is normalized to avoid invalid domain state.
        /// </summary>
        public void SetNickname(string newName)
        {
            _nickname = NormalizeNickname(newName);
        }

        private static string NormalizeNickname(string value)
        {
            var trimmed = value?.Trim();
            return string.IsNullOrWhiteSpace(trimmed) ? "Player" : trimmed;
        }
    }
}
