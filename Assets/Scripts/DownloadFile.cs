using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DownloadFile : MonoBehaviour
{
    /*[SerializeField] private Image imageIndicator;
    void Start()
    {
        StartCoroutine(Download("https://inkmeo.app/2023/assetbundleandroid/StoryCard.unity3d"));
    }

    public IEnumerator Download(string url){
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Accept-Encoding", "");
        www.SendWebRequest();
        while(!www.isDone){
            Debug.Log("Progress: " + (int)(www.downloadProgress * 100f) + "%");
            imageIndicator.fillAmount = www.downloadProgress;
            yield return null;
        }
        imageIndicator.fillAmount = 1.0f;
        if(www.result != UnityWebRequest.Result.Success){
            Debug.Log(www.error);
        }
        else
        {
            // Print out the response headers
            foreach (string key in www.GetResponseHeaders().Keys)
            {
                Debug.Log(key + ": " + www.GetResponseHeaders()[key]);
            }

            // Print the response body (if needed)
            Debug.Log("Response: " + www.downloadHandler.text);
        }
        www.Dispose();
    }*/
    private string url1 = "https://inkmeo.app/2023/assetbundleandroid/StoryCard.unity3d";
    private string url2 = "https://inkmeo.app/2023/assetbundleandroid/StoryCard.unity3d";
    private string url3 = "https://inkmeo.app/2023/assetbundleandroid/StoryCard.unity3d";

    public void Start()
    {
        download();
    }

    public void download()
    {
        StartCoroutine(MakeAllWebRequests());
    }

    IEnumerator MakeAllWebRequests()
    {
        yield return StartCoroutine(MakeWebRequest(url1));
        Debug.Log("One completed");
        yield return StartCoroutine(MakeWebRequest(url2));
        Debug.Log("Two completed");
        yield return StartCoroutine(MakeWebRequest(url3));
        Debug.Log("Three completed");
        Debug.Log("All web requests completed!");
    }

    IEnumerator MakeWebRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            webRequest.SetRequestHeader("Accept-Encoding", "");

            // Start the web request
            var operation = webRequest.SendWebRequest();
            while (!operation.isDone)
            {
                // Display download progress
                float progress = Mathf.Clamp01(webRequest.downloadProgress);
                Debug.Log($"Downloading {url}: {progress * 100}%");

                yield return null; // Wait for the next frame
            }

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Request successful!");
                Debug.Log("Result: " + webRequest.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Request failed: " + webRequest.error);
            }
        }
    }
}
