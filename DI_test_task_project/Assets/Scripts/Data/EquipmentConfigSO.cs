using UnityEngine;
using Game.Domain;

namespace Game.Configs
{
    /// <summary>
    /// Source of initial equipment parameters.
    /// Serves as a data-driven implementation of IEquipmentConfig.
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Configs/Equipment Config", fileName = "EquipmentConfig")]
    public sealed class EquipmentConfigSO : ScriptableObject, IEquipmentConfig
    {
        [Header("Rifle")]
        [SerializeField] private string _rifleName = "Rifle";
        [Min(0)] [SerializeField] private int _rifleAmmo = 50;

        [Header("Parachute")]
        [SerializeField] private bool _hasParachute = true;

        [Header("Rocket Pack")]
        [Min(0)] [SerializeField] private int _rocketPackCharges = 3;

        public string RifleName => _rifleName;
        public int RifleAmmo => _rifleAmmo;
        public bool HasParachute => _hasParachute;
        public int RocketPackCharges => _rocketPackCharges;
    }
}
