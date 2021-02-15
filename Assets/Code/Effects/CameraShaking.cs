using Code.States;
using DG.Tweening;
using UnityEngine;

namespace Code.Effects
{
    public class CameraShaking : MonoBehaviour
    {
        [SerializeField] private float _shakePower;

        private void Start()
        {
            LevelStateHandler.Instance.OnGoal += OnGoal;
        }

        private void OnDestroy()
        {
            LevelStateHandler.Instance.OnGoal -= OnGoal;
        }

        private void OnGoal(PlayerType playerType)
        {
            if(playerType == PlayerType.Player)
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