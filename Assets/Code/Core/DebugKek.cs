using System;
using System.IO;
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
                LevelStateHandler.Instance.AddPoint(Belongs.Player);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                LevelStateHandler.Instance.AddPoint(Belongs.Enemy);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0f;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1f;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                string filepath = Path.Combine(Application.temporaryCachePath, "screen.png");
                ScreenCapture.CaptureScreenshot(filepath);

                new NativeShare().AddFile(filepath).SetSubject("kekw").SetText("opa");
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                Time.timeScale = 0.5f;
            }

        }
    }
}