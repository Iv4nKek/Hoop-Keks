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
        [SerializeField]private bool _isBonusLevel;
        //Skins
        [SerializeField]private List<string> _availableSkins;
        [SerializeField] private int _ballSkin;
        [SerializeField] private int _torusSkin;

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

        public int TorusSkin
        {
            get => _torusSkin;
            set => _torusSkin = value;
        }

        public int BallSkin
        {
            get => _ballSkin;
            set => _ballSkin = value;
        }
    }
}