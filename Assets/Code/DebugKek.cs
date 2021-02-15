using System.IO;
using Code.States;
using UnityEngine;

namespace Code
{
    public class DebugKek : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                LevelStateHandler.Instance.AddPoint(PlayerType.Player);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                LevelStateHandler.Instance.AddPoint(PlayerType.Enemy);
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