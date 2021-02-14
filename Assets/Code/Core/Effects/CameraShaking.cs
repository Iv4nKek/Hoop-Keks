using System;
using DG.Tweening;
using UnityEngine;

namespace Code.Core.Effects
{
    public class CameraShaking : MonoBehaviour
    {
        [SerializeField] private float _shakePower;

        private void Start()
        {
            LevelStateHandler.Instance.OnGoal += OnGoal;
        }

        private void OnGoal(Belongs belongs)
        {
            if(belongs == Belongs.Player)
                Shake();
        }
        private void Shake()
        {
            transform.DORewind();
            transform.DOKill();
            transform.DOShakePosition(1,new Vector3(1,1,0)*_shakePower,5);
           
        }
    }
}