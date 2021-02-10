using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Eco
{
    public class Shop : MonoBehaviour
    {
        private List<Skin> _skins;

        public event Action<Skin> OnSkinBuy;
        private void Awake()
        {
            LoadSkins();
            OnSkinBuy += HandleSkinBuy;

        }

        private void HandleSkinBuy(Skin skin)
        {
            
        }
        private void LoadSkins()
        {
            SkinContainer container = Resources.Load<SkinContainer>("Resources/Skins/SkinContainer");
            if (container != null)
            {
                _skins = container.Skins;
            }
            
        }
    }
}