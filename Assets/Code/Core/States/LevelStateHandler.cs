using System;
using UnityEngine;

namespace Code.Core
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

        public event Action<Belongs> OnGoal = delegate(Belongs belongs) { };
        public event Action<Belongs> OnFlexBit = delegate(Belongs belongs) { };

        public event Action<Belongs> OnEndMatch = delegate(Belongs belongs) { };
        public event Action<Belongs> OnBeforeEndMatch = delegate(Belongs belongs) { };
        public event Action OnReset = delegate { };
        public event Action OnStart = delegate { };

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

        private void Awake()
        {
            if (_instanceHandler is null)
            {
                _instanceHandler = this;
            }
        }

        public void StartLevel()
        {
            GameStateHandler instance = GameStateHandler.Instance;

            if (instance.State.Tournament.Stage >= 5)
            {
                instance.State.Tournament.Stage = 0;
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
            OnFlexBit.Invoke(Belongs.Player);
        }

        public void AddPoint(Belongs belongs)
        {
            if (_isScoreLocked) return;
            int points = _isBonusLevel ? 5 : 1;
            if (belongs == Belongs.Player)
            {
                AddPointToPlayer(points);
            }
            else
            {
                AddPointToBot(points);
            }

            OnGoal(belongs);
        }

        private void AddPointToPlayer(int count)
        {
            _playerScore += count;
            if (_playerScore >= _winScore && !_isBonusLevel)
            {
                StartMatchEnding(Belongs.Player);
            }
        }

        private void AddPointToBot(int count)
        {
            _botScore += count;
            if (_botScore >= _winScore && !_isBonusLevel)
            {
                StartMatchEnding(Belongs.Enemy);
            }
        }

        public void TimeExpired()
        {
            Belongs winner = _playerScore > _botScore ? Belongs.Player : Belongs.Enemy;
            StartMatchEnding(winner);
        }

        private void StartMatchEnding(Belongs winner)
        {
            if (!_isBonusLevel) GameStateHandler.Instance.State.Tournament.AddStage();
            _isScoreLocked = true;
            OnBeforeEndMatch(winner);
        }

        public void EndMatch(Belongs winner)
        {
            if (!_isBonusLevel)
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
            if (winner == Belongs.Enemy)
            {
                GameStateHandler.Instance.State.Tournament.Stage = 0;
            }
        }
    }
}