using Game.Domain;
using Game.Configs;
using UnityEngine;
using Zenject;

namespace Game.Core.Feature.Player
{
    /// <summary>
    /// Binds the Player feature dependencies.
    /// This installer remains focused on a single feature slice:
    /// configuration, factories, player instance, and feature initialization.
    /// </summary>
    public sealed class PlayerFeatureInstaller : MonoInstaller
    {
        [Header("Player Configuration (Scriptable Objects)")]
        [SerializeField] private PlayerConfigSO _playerConfig;
        [SerializeField] private EquipmentConfigSO _equipmentConfig;

        public override void InstallBindings()
        {
            //Configs
            Container.Bind<IPlayerConfig>()
                .FromInstance(_playerConfig)
                .AsSingle();

            Container.Bind<IEquipmentConfig>()
                .FromInstance(_equipmentConfig)
                .AsSingle();

            //Factories
            Container.Bind<IEquipmentFactory>()
                .To<EquipmentFactory>()
                .AsSingle();

            //Player
            Container.Bind<IPlayer>()
                .To<Domain.Player>()
                .AsSingle();

            Container.Bind<IPlayerInitializable>()
                .To<Domain.Player>()
                .FromResolve()
                .AsSingle();
            
            //Feature initialization
            Container.Bind<IGameFeatureInitializable>()
                .To<PlayerInitializer>()
                .AsSingle();
        }
    }
}
