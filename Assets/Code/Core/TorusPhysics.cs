using System;
using UnityEngine;

namespace Code.Core
{
    public class TorusPhysics : MonoBehaviour
    {
        [SerializeField] private float _distance;
        [SerializeField] private float _lerp;
        [SerializeField] private float eps;
        [SerializeField] private Transform _left;
        [SerializeField] private Transform _right;
        [SerializeField] private Transform _main;

        private void Update()
        {
            float currentDistance = Vector2.Distance(_left.position, _right.position);
            if(Mathf.Abs(currentDistance-_distance)>eps)
            {
                float difference = currentDistance - _distance;
                Vector2 direction = _right.position - _left.position;
                direction.Normalize();
                MoveNode(_left,direction,difference/2);
                MoveNode(_right,-direction,difference/2);
                Vector2 mainPosition = _left.position+ (_right.position - _left.position) / 2;
                direction = _right.position - _left.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
                _main.position = mainPosition;
                _left.eulerAngles = new Vector3(0f, 0f, angle);
            }
        }

        private void MoveNode(Transform transform, Vector2 to, float value)
        {
           
            transform.Translate( Vector3.Lerp(new Vector3(), to * value, _lerp));
        }
    }
}