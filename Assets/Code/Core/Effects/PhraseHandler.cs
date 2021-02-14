using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Core.Effects
{
    public class PhraseHandler: MonoBehaviour
    {
        [SerializeField] private PhraseContainer _phraseContainer;
        private List<string> _phrases = new List<string>();
        private static int currentPhrase = 0;
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
            if (currentPhrase < _phrases.Count)
            {
                if (currentPhrase == _phrases.Count)
                {
                    currentPhrase = 0;
                }
                return _phrases[currentPhrase++];
               
            }
            else
            {
                currentPhrase = 0;
                return GetPhrase();
            }
        }
       

        
    }
}