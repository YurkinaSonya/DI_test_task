namespace Game.Domain
{
    /// <summary>
    /// Base class for all equipment items.
    /// </summary>
    public abstract class Item
    {
        public string Name { get; }

        protected Item(string name)
        {
            Name = name;
        }
    }
}
