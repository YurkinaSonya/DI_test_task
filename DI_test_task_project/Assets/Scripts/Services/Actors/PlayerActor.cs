using UnityEngine;
using Zenject;
using Game.Domain;

namespace Game.Services.Actors
{
    /// <summary>
    /// A scene-level adapter that exposes the injected domain player
    /// within Unity's object world.
    /// </summary>
    public class PlayerActor : MonoBehaviour
    {
        public IPlayer Player { get; private set; }

        [Inject]
        private void Construct(IPlayer player)
        {
            Player = player;
        }
    }
}
