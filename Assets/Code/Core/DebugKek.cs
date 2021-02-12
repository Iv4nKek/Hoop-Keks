using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Code.Core
{
    public class DebugKek : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                LevelStateHandler.LevelState.AddPoint(Belongs.Player);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                LevelStateHandler.LevelState.AddPoint(Belongs.Enemy);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0f;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1f;
            }

        }
    }
}