using System.Collections.Generic;
using UnityEngine;
using Game.Domain;

namespace Game.Configs
{
    /// <summary>
    /// Source of initial player attributes.
    /// Serves as a data-driven implementation of IPlayerConfig.
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Configs/Player Config", fileName = "PlayerConfig")]
    public sealed class PlayerConfigSO : ScriptableObject, IPlayerConfig
    {
        [Header("Base Attributes")]
        [Min(1)] [SerializeField] private int _initialHealth = 100;
        [Min(1)] [SerializeField] private int _initialLives = 3;
        [SerializeField] private string _initialNickname = "John";

        [Header("Skills")]
        [SerializeField] private List<string> _initialSkills = new() { "Skill1", "Skill2", "Skill3" };

        public int InitialHealth => _initialHealth;
        public int InitialLives => _initialLives;
        public string InitialNickname => _initialNickname;
        public IReadOnlyList<string> InitialSkills => _initialSkills;
    }
}
