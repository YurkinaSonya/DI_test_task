using UnityEngine;
using Zenject;
using Game.Core.Events;
using Game.Core.Visual;

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

        [Header("Debug Presentation")]
        [SerializeField] private PlayerDebugOverlay _debugOverlay;

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

            //Debug
            if (_debugOverlay != null)
            {
                Container.Bind<IPlayerDebugView>()
                    .FromInstance(_debugOverlay)
                    .AsSingle()
                    .NonLazy();

                Container.BindInterfacesAndSelfTo<PlayerDebugPresenter>()
                    .AsSingle()
                    .NonLazy();
            }
        }
    }
}
