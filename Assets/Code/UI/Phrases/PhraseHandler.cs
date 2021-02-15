using System.Collections.Generic;
using UnityEngine;

namespace Code.UI.Phrases
{
    public class PhraseHandler: MonoBehaviour
    {
        [SerializeField] private PhraseContainer _phraseContainer;
        private List<string> _phrases = new List<string>();
        private static int _currentPhrase = 0;
        private void Awake()
        {
            LoadPhrases();
        }

        private void LoadPhrases()
        {
            if (_phraseContainer != null)
            {
                _phrases = _phraseContainer.Phrases;
            }
        }

        public string GetPhrase()
        {
            if (_phrases.Count == 0)
                return "PEPEGA";
            if (_currentPhrase < _phrases.Count)
            {
                if (_currentPhrase == _phrases.Count)
                {
                    _currentPhrase = 0;
                }
                return _phrases[_currentPhrase++];
               
            }
            else
            {
                _currentPhrase = 0;
                return GetPhrase();
            }
        }
       

        
    }
}