using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Text;
using System.Collections;
using System.Net;
using System.Net.Sockets;

public class Downloader : MonoBehaviour
{
    float timeBase;
    UnityWebRequest request;
    //Socket socket;

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
        /*UdpClient udpClient = new UdpClient(11000);
        try{
            udpClient.Connect("www.google.com", 80);
            Byte[] sendBytes = Encoding.ASCII.GetBytes("GET / HTTP/1.0\n\n");
            udpClient.Send(sendBytes, sendBytes.Length);
            udpClient.Close();
        }
       catch (Exception e ) {
            Console.WriteLine(e.ToString());
        }
        yield return null; */

        request = UnityWebRequest.Get("https://en.wikipedia.org/wiki/Special:Random");
        yield return request.SendWebRequest();
        if (request.isNetworkError)
            Debug.Log("Error: " + request.error);
        else
            Debug.Log(":\nReceived: " + request.downloadHandler.text);
        request = null;
    }
}
