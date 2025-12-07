using System.Collections.Generic;

namespace Game.Domain
{
    /// <summary>
    /// Provides initial player attributes.
    /// </summary>
    public interface IPlayerConfig
    {
        int InitialHealth { get; }
        int InitialLives { get; }
        string InitialNickname { get; }
        IReadOnlyList<string> InitialSkills { get; }
    }
}
