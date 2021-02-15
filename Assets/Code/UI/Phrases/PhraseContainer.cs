using System.Collections.Generic;
using UnityEngine;

namespace Code.UI.Phrases
{[CreateAssetMenu(fileName = "PhraseContainer",menuName = "HoopKeks/PhraseContainer")]
    public class PhraseContainer : ScriptableObject
    {
        [SerializeField]private List<string> _phrases;

        public List<string> Phrases => _phrases;
    }
}