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
        [SerializeField] private Texture _texture;

        public int Money => _money;

        public Sprite Icon => _icon;

        public Texture Texture => _texture;

        public string Name => _name;
    }
}