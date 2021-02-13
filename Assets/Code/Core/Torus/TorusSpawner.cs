using System;
using UnityEngine;

namespace Code.Core
{
    public class TorusSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPosition;
        [SerializeField] private Transform _botSpawnPosition;
        [SerializeField] private Transform _playerTorus;
        [SerializeField] private Transform _botTorus;

        private void Start()
        {
            LevelStateHandler.LevelState.OnStart += Spawn;
            LevelStateHandler.LevelState.OnReset += Despawn;
        }

        private void Despawn()
        {
            _playerTorus.gameObject.SetActive(false);
            _botTorus.gameObject.SetActive(false);
        }
        private void Spawn()
        {
            _playerTorus.position = _playerSpawnPosition.position;
            _botTorus.position = _botSpawnPosition.position;
            _playerTorus.gameObject.SetActive(true);
            _botTorus.gameObject.SetActive(true);
        }
    }
}