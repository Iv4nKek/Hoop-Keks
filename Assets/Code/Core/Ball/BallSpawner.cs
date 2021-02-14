using System;
using EZ_Pooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Core
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private EZ_PoolManager _poolManager;
        [SerializeField] private Transform _ballObject;
        [SerializeField] private Transform _from;
        [SerializeField] private Transform _to;

        private Transform _current;
        private void Start()
        {
            //Spawn();
            LevelStateHandler.Instance.OnGoal += Translate;
            LevelStateHandler.Instance.OnReset += DeSpawn;
            LevelStateHandler.Instance.OnStart += Spawn;
        }

        private void Translate(Belongs winner)
        {
            
            _current.transform.position = GetBallPosition();
        }
        private void OnDestroy()
        {
            DeSpawn();
        }

        private void DeSpawn()
        {
            EZ_PoolManager.Despawn(_current);
        }
        private void Respawn(Belongs winner)
        {
            DeSpawn();;
            Spawn();
        }
        private void Spawn()
        {
           
            _current =  EZ_PoolManager.Spawn(_ballObject, GetBallPosition(), new Quaternion());
        }

        private Vector2 GetBallPosition()
        {
            float x = Mathf.Lerp(_from.position.x, _to.position.x, Random.value);
            float y = Mathf.Lerp(_from.position.y, _to.position.y, Random.value);
            Vector2 point = new Vector2(x,y);
            return point;
        }
    }
}