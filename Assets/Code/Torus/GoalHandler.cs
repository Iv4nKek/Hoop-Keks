using Code.States;
using UnityEngine;

namespace Code.Torus
{
    public class GoalHandler: MonoBehaviour
    {
        [SerializeField] private Torus _torus;
        [SerializeField] private BoxCollider2D _torusGoalCollider;
        [SerializeField] private CircleCollider2D _ballGoalCollider;

        private void Start()
        {
            _ballGoalCollider=  LevelStateHandler.Instance.Ball.GoalCollider;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other == _ballGoalCollider)
            {
                _torus.HandleGoalIntersection();
            }
        }

       

       
    }
}