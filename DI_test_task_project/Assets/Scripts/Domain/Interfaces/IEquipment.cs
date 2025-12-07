using System.Collections.Generic;

namespace Game.Domain
{
    /// <summary>
    /// Defines a player equipment container.
    /// </summary>
    public interface IEquipment
    {
        IReadOnlyList<Item> Items { get; }

        /// <summary>
        /// Adds an item to the equipment collection.
        /// The collection is owned by the equipment implementation.
        /// </summary>
        void AddItem(Item item);

        /// <summary>
        /// Clears and replaces the current set of items.
        /// </summary>
        void SetItems(IEnumerable<Item> items);

        /// <summary>
        /// Clears all items.
        /// Could be useful for specific death logic.
        /// </summary>
        void ClearItems();
    }
}
