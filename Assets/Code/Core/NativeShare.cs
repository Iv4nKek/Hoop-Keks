/*using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class NativeShare : MonoBehaviour {
	//имя скриншота
	public string ScreenshotName = "screenshot.png";
	//скриншот + текст
    public void ShareScreenshotWithText(string text)
    {
        Application.CaptureScreenshot(ScreenshotName);
		StartCoroutine(delayedShare(text));
    }
	//ожидание перед открытием окна share
    IEnumerator delayedShare(string text)
    {
        yield return new WaitForSeconds(0.25f);
        string screenShotPath = Application.persistentDataPath + "/" + ScreenshotName;
        Share(text, screenShotPath, "");
    }
	public void Share(string shareText, string imagePath, string url, string subject = "")
	{

		AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");

		intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
		AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
		AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + imagePath);
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
		intentObject.Call<AndroidJavaObject>("setType", "image/png");

		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareText);

		AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

		AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, subject);
		currentActivity.Call("startActivity", jChooser);
	}
}*/