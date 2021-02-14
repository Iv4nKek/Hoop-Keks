using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Eco
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
            return PickRandom(_skinContainer.BallSkins);
        }

        public Skin GetBotSkin()
        {
            return PickRandom(_skinContainer.BotSkins);
        }
        
        public Skin GetPlayerSkin()
        {
            return PickRandom(_skinContainer.PlayerSkins);
        }
        private Skin PickRandom(List<Skin> skins)
        {
            return skins[Random.Range(0, skins.Count)];
        }
        public event Action<Skin> OnSkinBuy;
       
        private void Awake()
        {
            if (_skinHandler == null)
            {
                _skinHandler = this;
            }
            LoadSkins();
            OnSkinBuy += HandleSkinBuy;
            
        }
        private void HandleSkinBuy(Skin skin)
        {
            
        }
        private void LoadSkins()
        {
            
            if (_skinContainer != null)
            {
                
            }
            
        }
    }
}