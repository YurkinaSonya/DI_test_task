namespace Game.Core.Visual
{
    /// <summary>
    /// Defines a debug surface for player-related events.
    /// </summary>
    public interface IPlayerDebugView
    {
        void ShowLine(string text);
        void ShowHeader(string text);
    }
}
