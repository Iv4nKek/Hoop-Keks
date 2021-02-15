using System;
using Code.CentralBall;
using UnityEngine;

namespace Code.States
{
    public class LevelStateHandler : MonoBehaviour
    {
        [SerializeField] private int _winScore;
        [SerializeField] private int _levelTime;

        private static LevelStateHandler _instanceHandler;
        private int _playerScore;
        private int _botScore;
        private Ball _ball;
        private bool _isScoreLocked;
        private bool _isBonusLevel;

        #region Events

        public event Action<PlayerType> OnGoal = delegate(PlayerType belongs) { };
        public event Action<PlayerType> OnFlexBit = delegate(PlayerType belongs) { };

        public event Action<PlayerType> OnEndMatch = delegate(PlayerType belongs) { };
        public event Action<PlayerType> OnBeforeEndMatch = delegate(PlayerType belongs) { };
        public event Action OnReset = delegate { };
        public event Action OnStart = delegate { };

        #endregion

        #region Properties
        public static LevelStateHandler Instance => _instanceHandler;

        public int BotScore => _botScore;

        public int PlayerScore => _playerScore;

        public int WinScore => _winScore;

        public int LevelTime => _levelTime;
        
        public Ball Ball
        {
            get => _ball;
            set => _ball = value;
        }

        public bool IsBonusLevel
        {
            get => _isBonusLevel;
            set => _isBonusLevel = value;
        }
        #endregion
        
        #region PublicMethods

        public void StartLevel()
        {
            GameStateHandler instance = GameStateHandler.Instance;

            if (instance.State.TrophiesWon >= 4)
            {
                instance.State.TrophiesWon = 0;
            }

            if (instance.State.BonusValue >= 1f)
            {
                _isBonusLevel = true;
                instance.State.BonusValue = 0f;
            }

            OnStart();
        }
        public void Reset()
        {
            _playerScore = 0;
            _botScore = 0;
            OnReset();
        }

        public void MakeFlexBit()
        {
            AddPointToPlayer(1);
            OnFlexBit.Invoke(PlayerType.Player);
        }

        public void AddPoint(PlayerType playerType)
        {
            if (_isScoreLocked) return;
            int points = _isBonusLevel ? 5 : 1;
            if (playerType == PlayerType.Player)
            {
                AddPointToPlayer(points);
            }
            else
            {
                AddPointToBot(points);
            }

            OnGoal(playerType);
        }
        public void TimeExpired()
        {
            PlayerType winner = _playerScore > _botScore ? PlayerType.Player : PlayerType.Enemy;
            StartMatchEnding(winner);
        }
        public void EndMatch(PlayerType winner)
        {
            if (!_isBonusLevel && winner == PlayerType.Player)
            {
                GameStateHandler.Instance.AddToBonusLevel();
            }
            else
            {
                _isBonusLevel = false;
            }

            Time.timeScale = 0f;
            _isScoreLocked = false;
            OnEndMatch(winner);
            if (winner == PlayerType.Enemy)
            {
                GameStateHandler.Instance.State.TrophiesWon = 0;
            }
            GameStateHandler.Instance.SaveGameState();
        }
        #endregion

        #region PrivateMethods

        private void Awake()
        {
            if (_instanceHandler is null)
            {
                _instanceHandler = this;
            }
        }

       

       

        private void AddPointToPlayer(int count)
        {
            _playerScore += count;
            if (_playerScore >= _winScore && !_isBonusLevel)
            {
                StartMatchEnding(PlayerType.Player);
            }
        }

        private void AddPointToBot(int count)
        {
            _botScore += count;
            if (_botScore >= _winScore && !_isBonusLevel)
            {
                StartMatchEnding(PlayerType.Enemy);
            }
        }

       

        private void StartMatchEnding(PlayerType winner)
        {
            if (!_isBonusLevel) GameStateHandler.Instance.State.TrophiesWon++;
            _isScoreLocked = true;
            OnBeforeEndMatch(winner);
        }

        #endregion
        

    }
}