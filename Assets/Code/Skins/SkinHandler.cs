using System;
using System.Collections.Generic;
using Code.States;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Eco.SkinShop
{
    public class SkinHandler : MonoBehaviour
    {
        [SerializeField] private SkinContainer _skinContainer;
        private static SkinHandler _skinHandler;

        public static SkinHandler Instance => _skinHandler;

        public List<Skin> PlayerSkins => _skinContainer.PlayerSkins; 
        public List<Skin> BallSkins => _skinContainer.BallSkins; 

        public Skin GetBonusSkin()
        {
            return _skinContainer.BonusBallSkin;
        }

        public Skin GetBallSkin()
        {
            return _skinContainer.BallSkins[GameStateHandler.Instance.State.BallSkin];
        }

        public Skin GetBotSkin()
        {
            return PickRandom(_skinContainer.BotSkins);
        }
        
        public Skin GetPlayerSkin()
        {
            return _skinContainer.PlayerSkins[GameStateHandler.Instance.State.TorusSkin];
        }
        private Skin PickRandom(List<Skin> skins)
        {
            return skins[Random.Range(0, skins.Count)];
        }
       
        private void Awake()
        {
            if (_skinHandler == null)
            {
                _skinHandler = this;
            }
            
        }
       
    }
}