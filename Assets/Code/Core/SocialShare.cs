using System;
using System.IO;
using UnityEngine;

namespace Code.Core
{
    public class SocialShare : MonoBehaviour
    {
        [SerializeField]
        string _title;

        [SerializeField]
        [Multiline]
        string _text;

        [SerializeField]
        Texture2D[] _images;


        public void Share()
        {
            Share(null);
        }

        public void ShareWithScreenshot()
        {
            Share(ScreenCapture.CaptureScreenshotAsTexture());
        }

        void Share(Texture2D screenshot)
        {
            var ns = new NativeShare();

            if (string.IsNullOrEmpty(_title))
            {
                ns.SetTitle(_text);
                ns.SetSubject(_text);
            }
            else
            {
                ns.SetTitle(_title);
                ns.SetSubject(_title);
            }

            ns.SetText(_text);

            if (screenshot != null)
                ns.AddFile(GetFilePath(screenshot));

            foreach (var img in _images)
            {
                ns.AddFile(GetFilePath(img));
            }

            ns.Share();
        }

        private string GetFilePath(Texture2D texture)
        {
            var filePath = Path.Combine(Application.temporaryCachePath, $"{Guid.NewGuid()}.png");
            File.WriteAllBytes(filePath, texture.EncodeToPNG());

            return filePath;
        }
    }
}