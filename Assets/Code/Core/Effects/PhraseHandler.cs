using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Core.Effects
{
    public class PhraseHandler: MonoBehaviour
    {
        private List<string> _phrases;
        private static int currentPhrase = 0;
        private void Start()
        {
            LoadPhrases();
        }

        private void LoadPhrases()
        {
            PhraseContainer container = Resources.Load<PhraseContainer>("Resources/Phrases/PhraseContainer");
            if (container != null)
            {
                _phrases = container.Phrases;
            }
        }

        public string GetPhrase()
        {
            if (_phrases.Count == 0)
                return "kekw";
            if (currentPhrase < _phrases.Count)
            {
                if (++currentPhrase == _phrases.Count)
                {
                    currentPhrase = 0;
                }
                return _phrases[currentPhrase];
               
            }
            else
            {
                currentPhrase = 0;
                return GetPhrase();
            }
        }
        
    }
}