using System.Collections.Generic;
using UnityEngine;

namespace Code.Eco
{
    [CreateAssetMenu(fileName = "SkinContainer",menuName = "HoopKeks/SkinContainer")]
    public class SkinContainer : ScriptableObject
    {
        [SerializeField] private List<Skin> _skins;

        public List<Skin> Skins => _skins;
    }
}