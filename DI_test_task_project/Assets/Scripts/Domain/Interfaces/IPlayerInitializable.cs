using System.Collections.Generic;

namespace Game.Domain
{
    /// <summary>
    /// Defines a narrow contract for controlled initialization of the player state.
    /// This interface exists to keep IPlayer clean and focused on runtime interactions.
    /// </summary>
    public interface IPlayerInitializable
    {
        void InitializeState(int health, int lives, string nickname, IEnumerable<string> skills);
    }
}
