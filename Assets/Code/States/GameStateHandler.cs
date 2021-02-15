using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Code.States
{
    public class GameStateHandler : MonoBehaviour
    {
        [SerializeField] private string _filename = "/Data.dat";
        [SerializeField] private GameState _gameState;
        [SerializeField] private float _bonusLevelIncome;

        private static GameStateHandler _gameInstance;
        private string _fullPath;

        public GameState State => _gameState;

        public static GameStateHandler Instance => _gameInstance;

        private void Awake()
        {
            if (_gameInstance == null)
            {
                _gameInstance = this;
            }

            _fullPath = Application.persistentDataPath + _filename;
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

        public void SaveGameState()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(_fullPath, FileMode.Create))
            {
                formatter.Serialize(fs, _gameState);
            }
        }

        private void LoadGameState()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if (System.IO.File.Exists(_fullPath))
            {
                using (FileStream fs = new FileStream(_fullPath, FileMode.Open))
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