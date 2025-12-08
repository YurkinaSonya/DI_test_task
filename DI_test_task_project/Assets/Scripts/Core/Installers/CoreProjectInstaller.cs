using UnityEngine;
using Zenject;
using Game.Core.Events;

namespace Game.Core.Installers
{
    /// <summary>
    /// Defines global, domain-agnostic bindings.
    /// This installer represents the root of infrastructure composition.
    /// </summary>
    public sealed class CoreProjectInstaller : MonoInstaller
    {
        [Header("Optional Scene Services")]
        [SerializeField] private CoroutineRunner _coroutineRunner;

        public override void InstallBindings()
        {
            //Runtime utilities (optional, only if used in the scene)
            if (_coroutineRunner != null)
            {
                Container.Bind<CoroutineRunner>()
                    .FromInstance(_coroutineRunner)
                    .AsSingle()
                    .NonLazy();
            }

            //Event system
            Container.Bind<IEventAggregator>()
                .To<EventAggregator>()
                .AsSingle()
                .NonLazy();
        }
    }
}
