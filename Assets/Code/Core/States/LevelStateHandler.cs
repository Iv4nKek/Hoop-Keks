using System;
using UnityEngine;

namespace Code.Core
{
    public class LevelStateHandler : MonoBehaviour
    {
        [SerializeField] private int winScore;
        [SerializeField] private int levelTime;
        private static LevelStateHandler _levelStateHandler;
        private int _playerScore;
        private int _botScore;
        public event Action<Belongs> OnGoal;
        public event Action<Belongs> OnEndMatch = delegate(Belongs belongs) {  };
        public static LevelStateHandler LevelState=> _levelStateHandler;

        public int BotScore => _botScore;

        public int PlayerScore => _playerScore;

        public int WinScore => winScore;

        public int LevelTime => levelTime;

        private void Awake()
        {
            Debug.Log("aw");
            if (_levelStateHandler is null)
            {
                _levelStateHandler = this;
            }
        }

        public void AddPoint(Belongs belongs)
        {
            Debug.Log("Add");
            if (belongs == Belongs.Player)
            {
                AddPointToPlayer();
            }
            else
            {
                AddPointToBot();
            }

            OnGoal(belongs);
        }
        private void AddPointToPlayer()
        {
            _playerScore++;
            if (_playerScore > winScore)
            {
                EndMatch(Belongs.Player);
            }
        }

        private void AddPointToBot()
        {
            _botScore++;
            if (_botScore > winScore)
            {
                EndMatch(Belongs.Enemy);
            }
        }

        private void EndMatch(Belongs winner)
        {
            OnEndMatch(winner);
        }
        
    }
}