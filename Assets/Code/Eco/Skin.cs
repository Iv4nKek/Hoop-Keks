using UnityEngine;
using System;
namespace Code.Eco
{
    [Serializable]
    public class Skin
    {
        [SerializeField] private String _name;
        [SerializeField] private int _money;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Material _material;

        public int Money => _money;

        public Sprite Icon => _icon;

        public Material Material => _material;

        public string Name => _name;
    }
}