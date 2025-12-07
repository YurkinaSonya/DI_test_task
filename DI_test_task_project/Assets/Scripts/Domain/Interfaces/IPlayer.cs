using System.Collections.Generic;

namespace Game.Domain
{
    /// <summary>
    /// Represents a single player entity.
    /// </summary>
    public interface IPlayer
    {
        int Health { get; }
        int Lives { get; }
        string Nickname { get; }
        IReadOnlyList<string> Skills { get; }

        IEquipment Equipment { get; }

        /// <summary>
        /// Next methods are created for better open-closed defense for class.
        /// </summary>

        /// <summary>
        /// Replaces the current skill set.
        /// </summary>
        void SetSkills(IEnumerable<string> skills);

        /// <summary>
        /// Deal the damage on player's health.
        /// </summary>
        void ApplyDamage(int damage);

        /// <summary>
        /// Increase current health size.
        /// </summary>
        void AddHealth(int amount);

        /// <summary>
        /// Increase current lives amount.
        /// </summary>
        void AddLives(int amount);

        /// <summary>
        /// Method for nickname changing.
        /// </summary>
        void SetNickname(string newName);
    }
}
