using UnityEngine;

namespace Code.Core
{
    [System.Serializable]
    public class Tournament
    {
        [SerializeField]private int _stage;


        public void AddStage()
        {
            _stage++;
        }


        public int Stage
        {
            get => _stage;
            set => _stage = value;
        }
    }
}