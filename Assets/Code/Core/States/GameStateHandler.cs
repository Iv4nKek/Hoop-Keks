using System;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Code.Core
{
    public class GameStateHandler : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        [SerializeField] private float _bonusLevelIncome;

        private static GameStateHandler _gameInstance;

        public GameState State => _gameState;
        public static PlayerResources Resources => _gameInstance._gameState.PlayerResources;

        public static GameStateHandler Instance => _gameInstance;

        private void Awake()
        {
            if (_gameInstance == null)
            {
                _gameInstance = this;
            }

            LoadGameState();
        }

        public void AddToBonusLevel()
        {
            _gameState.BonusValue += _bonusLevelIncome;
            if (_gameState.BonusValue >= 1f)
            {
                _gameState.IsBonusLevel = true;
            }
        }

        private void OnDestroy()
        {
            SaveGameState();
        }

        private void SaveGameState()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("gameState.dat", FileMode.Create))
            {
                formatter.Serialize(fs, _gameState);
                Debug.Log("Объект сериализован");
            }
        }

        private void LoadGameState()
        {
            //_gameState = new GameState();
            BinaryFormatter formatter = new BinaryFormatter();
            if (System.IO.File.Exists("gameState.dat"))
            {
                using (FileStream fs = new FileStream("gameState.dat", FileMode.Open))
                {
                    GameState gameState = (GameState) formatter.Deserialize(fs);
                    if (gameObject != null)
                    {
                        _gameState = gameState;
                    }
                    else
                    {
                        throw new Exception("opa gg");
                    }
                }
            }
            else
            {
                GameState gameState = new GameState();
                _gameState = gameState;
                SaveGameState();
            }
        }
    }
}