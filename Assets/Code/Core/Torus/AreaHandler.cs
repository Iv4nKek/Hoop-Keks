using System;
using UnityEngine;

namespace Code.Core
{
    public class AreaHandler : MonoBehaviour
    {
        [SerializeField] private Torus _torus;
        [SerializeField] private BoxCollider2D _torusAreaCollider;
        [SerializeField] private CircleCollider2D _ballAreaCollider;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other == _ballAreaCollider)
            {
                _torus.UnlockGoal();
            }
        }

      
    }
}