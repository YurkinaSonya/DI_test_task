using System.Collections.Generic;
using System.Linq;

namespace Game.Domain
{
    /// <summary>
    /// Concrete implementation of IEquipment.
    /// Maintains ownership of the internal collection to preserve invariants.
    /// </summary>
    public sealed class Equipment : IEquipment
    {
        private readonly List<Item> _items = new();

        public IReadOnlyList<Item> Items => _items;

        public void AddItem(Item item)
        {
            if (item == null) return;
            _items.Add(item);
        }

        public void SetItems(IEnumerable<Item> items)
        {
            _items.Clear();
            if (items == null) return;
            _items.AddRange(items.Where(i => i != null));
        }

        public void ClearItems ()
        {
            _items.Clear();
        }
    }
}
