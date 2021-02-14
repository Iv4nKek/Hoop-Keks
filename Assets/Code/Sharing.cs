using System.IO;
using UnityEngine;

namespace Code
{
    public class Sharing : MonoBehaviour
    {
        public void Share()
        {
            string filepath = Path.Combine(Application.temporaryCachePath, "screen.png");
            ScreenCapture.CaptureScreenshot(filepath);

            new NativeShare().AddFile(filepath).Share();
        }
    }
}