using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Downloader : MonoBehaviour
{
    float timeBase;
    UnityWebRequest request;

    // Start is called before the first frame update
    void Start()
    {
        timeBase = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime - timeBase >= 5  && request==null) 
        {
            timeBase = Time.fixedTime;
            StartCoroutine("GetRandomWikiPage");
        }
    }


    IEnumerator GetRandomWikiPage()
    {
        request = UnityWebRequest.Get("https://en.wikipedia.org/wiki/Special:Random");
        yield return request.SendWebRequest();
        if (request.isNetworkError)
            Debug.Log("Error: " + request.error);
        else
            Debug.Log(":\nReceived: " + request.downloadHandler.text);
        request = null;
    }
}
