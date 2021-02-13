using System;
using UnityEngine;
using UnityEngine.Events;

namespace Code.Core.UI
{
    public class TapToStart : MonoBehaviour
    {
        [SerializeField]public UnityEvent OnTap = new UnityEvent();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnTap.Invoke();
                
            }
            
        }
    }
}