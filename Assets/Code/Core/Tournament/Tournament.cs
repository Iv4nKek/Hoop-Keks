using UnityEngine;

namespace Code.Core
{
    [System.Serializable]
    public class Tournament
    {
        [SerializeField]private int _stage;
        [SerializeField]private bool[] results = new bool[4];

        public int Stage => _stage;

        public void AddStage()
        {
            _stage++;
        }

        public bool[] Results => results;
    }
}