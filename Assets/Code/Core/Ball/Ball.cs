using System;
using Code.Eco;
using UnityEngine;

namespace Code.Core
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _areaCollider;
        [SerializeField] private CircleCollider2D _goalCollider;

        [SerializeField] private MeshRenderer _renderer;

        public CircleCollider2D AreaCollider => _areaCollider;

        public CircleCollider2D GoalCollider => _goalCollider;

        private void Start()
        {
            LevelStateHandler.Instance.OnStart += UpdateSkin;
            UpdateSkin();
        }

        private void OnEnable()
        {
            LevelStateHandler.Instance.Ball = this;
        }

        private void UpdateSkin()
        {
            Skin skin;
            if (LevelStateHandler.Instance.IsBonusLevel)
            {
                skin = SkinHandler.Instance.GetBonusSkin();
            }
            else
            {
                skin = SkinHandler.Instance.GetBallSkin();
            }
            _renderer.material = skin.Material;


        }
        
    }
}