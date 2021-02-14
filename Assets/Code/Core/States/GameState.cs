using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Core
{
    [Serializable]
    public class GameState
    {
        [SerializeField]private Tournament _tournament;
        [SerializeField]private float _bonusValue;
        [SerializeField]private PlayerResources _playerResources;
        [SerializeField]private List<string> _availableSkins;
        [SerializeField]private bool _isBonusLevel;

        public Tournament Tournament => _tournament;

        public PlayerResources PlayerResources => _playerResources;

        public List<string> AvailableSkins => _availableSkins;

        public float BonusValue
        {
            get => _bonusValue;
            set => _bonusValue = value;
        }

        public bool IsBonusLevel
        {
            get => _isBonusLevel;
            set => _isBonusLevel = value;
        }
    }
}