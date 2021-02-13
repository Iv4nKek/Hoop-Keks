using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Core
{
    [Serializable]
    public class GameState
    {
        [SerializeField]private Tournament _tournament;
        private PlayerResources _playerResources;
        private List<string> _availableSkins;

        public Tournament Tournament => _tournament;

        public PlayerResources PlayerResources => _playerResources;

        public List<string> AvailableSkins => _availableSkins;
    }
}