using System.Collections.Generic;
using UnityEngine;

namespace Code.Eco
{
    [CreateAssetMenu(fileName = "SkinContainer",menuName = "HoopKeks/SkinContainer")]
    public class SkinContainer : ScriptableObject
    {
        [SerializeField] private Skin _bonusBallSkin;
        [SerializeField] private List<Skin> _playerSkins;
        [SerializeField] private List<Skin> _botSkins;
        [SerializeField] private List<Skin> _ballSkins;


        public Skin BonusBallSkin
        {
            get => _bonusBallSkin;
            set => _bonusBallSkin = value;
        }

       

        public List<Skin> BallSkins
        {
            get => _ballSkins;
            set => _ballSkins = value;
        }

        public List<Skin> PlayerSkins
        {
            get => _playerSkins;
            set => _playerSkins = value;
        }

        public List<Skin> BotSkins
        {
            get => _botSkins;
            set => _botSkins = value;
        }
    }
}