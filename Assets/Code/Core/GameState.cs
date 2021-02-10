using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Core
{
    [System.Serializable]
    public class GameState
    {
        [SerializeField]private Tournament _tournament;
        private PlayerResources _playerResources;
        private List<string> _availableSkins;
    }
}