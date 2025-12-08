using UnityEngine;

namespace Game.Core.Visual
{
    /// <summary>
    /// A tiny on-screen debug overlay.
    /// </summary>
    public sealed class PlayerDebugOverlay : MonoBehaviour, IPlayerDebugView
    {
        [SerializeField] private int _maxLines = 14;

        private readonly System.Collections.Generic.Queue<string> _lines = new();

        public void ShowHeader(string text)
        {
            Enqueue($"<b>{text}</b>");
        }

        public void ShowLine(string text)
        {
            Enqueue(text);
        }

        private void Enqueue(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return;

            _lines.Enqueue(text);
            while (_lines.Count > Mathf.Max(1, _maxLines))
                _lines.Dequeue();
        }

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(10, 10, 600, 500));
            foreach (var line in _lines)
                GUILayout.Label(line);
            GUILayout.EndArea();
        }
    }
}
