using UnityEngine;
using UnityEngine.Events;

namespace Code.UI
{
    public class TapToStart : MonoBehaviour
    {
        [SerializeField]public UnityEvent _onTap = new UnityEvent();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _onTap.Invoke();
                
            }
            
        }
    }
}