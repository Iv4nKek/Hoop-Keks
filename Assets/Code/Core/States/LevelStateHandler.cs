using System;
using UnityEngine;

namespace Code.Core
{
    public class LevelStateHandler : MonoBehaviour
    {
        [SerializeField] private int _winScore;
        [SerializeField] private int _levelTime;
        
        
        private static LevelStateHandler _levelStateHandler;
        private int _playerScore;
        private int _botScore;
        private Ball _ball;
        private bool _isScoreLocked;


        public event Action<Belongs> OnGoal = delegate(Belongs belongs) {  };
        public event Action<Belongs> OnEndMatch = delegate(Belongs belongs) {  };
        public event Action<Belongs> OnBeforeEndMatch = delegate(Belongs belongs) {  };
        public event Action OnReset = delegate {  };
        public event Action OnStart = delegate {  };
        
        
        public static LevelStateHandler LevelState=> _levelStateHandler;
        
        public int BotScore => _botScore;

        public int PlayerScore => _playerScore;

        public int WinScore => _winScore;

        public int LevelTime => _levelTime;

        public Ball Ball
        {
            get => _ball;
            set => _ball = value;
        }

        private void Awake()
        {
            if (_levelStateHandler is null)
            {
                _levelStateHandler = this;
            }
        }

        public void StartLevel()
        {
            OnStart();
        }
        private void Start()
        {
          //  OnStart();
        }

        public void Reset()
        {
            _playerScore = 0;
            _botScore = 0;
            OnReset();
        }

        public void AddPoint(Belongs belongs)
        {
            if(_isScoreLocked)
                return;
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
            if (_playerScore > _winScore)
            {
                StartMatchEnding(Belongs.Player);
            }
        }

        private void AddPointToBot()
        {
            _botScore++;
            if (_botScore > _winScore)
            {
                StartMatchEnding(Belongs.Enemy);
            }
        }

        private void StartMatchEnding(Belongs winner)
        {
            GameStateHandler.StateHandler.State.Tournament.AddStage();;
            _isScoreLocked = true;
            OnBeforeEndMatch(winner);
        }
        public void EndMatch(Belongs winner)
        {
            Time.timeScale = 0f;
            _isScoreLocked = false;
            OnEndMatch(winner);

        }
        
    }
}