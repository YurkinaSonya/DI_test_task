using UnityEngine;
using Zenject;
using Game.Core.Events;

namespace Game.Core.Installers
{
    /// <summary>
    /// Defines scene-scoped bindings for MonoBehaviours in scene.
    /// </summary>
    public sealed class CoreSceneInstaller : MonoInstaller
    {
        [Header("Demo / Presentation")]
        [SerializeField] private MonoBehaviour[] _sceneServices;

        public override void InstallBindings()
        {
            if (_sceneServices == null) return;

            foreach (var service in _sceneServices)
            {
                if (service == null) continue;

                Container.Bind(service.GetType()) //casual binding of in-scene services.
                    .FromInstance(service)
                    .AsSingle();
            }
        }
    }
}
