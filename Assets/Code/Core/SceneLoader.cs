using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.Core
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private int _index;
        [SerializeField] private Image _slider;
      private void Start()
      {
          Application.backgroundLoadingPriority = ThreadPriority.Low;
          LoadScene();
      }

      private void LoadScene()
        {
            StartCoroutine(LoadYourAsyncScene());
            
        }
        IEnumerator LoadYourAsyncScene()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_index);
            while (!asyncLoad.isDone)
            {
                _slider.fillAmount = asyncLoad.progress/0.9f;
                yield return null;
            }
        }
        private void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadScene();
            }
        }
    }
}