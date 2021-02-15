using Code.States;
using EZ_Pooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.CentralBall
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private EZ_PoolManager _poolManager;
        [SerializeField] private Transform _ballObject;
        [SerializeField] private Transform _from;
        [SerializeField] private Transform _to;

        private Transform _current;
        private void OnEnable()
        {
            LevelStateHandler.Instance.OnGoal += Translate;
            LevelStateHandler.Instance.OnReset += DeSpawn;
            LevelStateHandler.Instance.OnStart += Spawn;
        }
        private void OnDisable()
        {
            LevelStateHandler.Instance.OnGoal -= Translate;
            LevelStateHandler.Instance.OnReset -= DeSpawn;
            LevelStateHandler.Instance.OnStart -= Spawn;
        }

        private void Translate(PlayerType winner)
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
        private void Respawn(PlayerType winner)
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
            var from = _from.position;
            var to = _to.position;
            float x = Mathf.Lerp(from.x, to.x, Random.value);
            float y = Mathf.Lerp(from.y, to.y, Random.value);
            Vector2 point = new Vector2(x,y);
            return point;
        }
    }
}