using UnityEngine;
using System.Collections;
using GamebenchLib.Runtime;

public class GameBenchAPITest : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;

        Gamebench.SetTag("APITest", "true");
        Gamebench.SetTag("foo", "bar");
        Gamebench.RemoveTag("foo");

        Invoke("StartSession", 5);
    }


    void StartSession()
    {
        Gamebench.Start("Script API Test");

        // Enable some metrics which aren't normally collected that frequently
        Gamebench.SetCaptureInterval(MetricType.POW, 5);
        Gamebench.SetCaptureInterval(MetricType.BAT, 5);
        Gamebench.SetCaptureInterval(MetricType.NET, 5);

        // Schedule some API calls and the end of the session
        Invoke("MarkLaunchComplete", 2);
        Invoke("MarkStart", 5);
        Invoke("MarkStop", 10);
        Invoke("CaptureScreenshot", 20);
        Invoke("StopSession", 30);
    }
    void MarkLaunchComplete() {
        Gamebench.MarkLaunchComplete();
    }
    void MarkStart() {
        Gamebench.MarkStart("API Test Marker 5s-10s");
    }
    void MarkStop() {
        Gamebench.MarkStop("API Test Marker 5s-10s");
    }
    void CaptureScreenshot() {
        Gamebench.CaptureNow(MetricType.SS0);
    }
    void StopSession()
    {
        Gamebench.Stop();
        Gamebench.Upload((int numUploaded, string errorMessage) => {
            Debug.Log("numUploaded = " + numUploaded);
            Debug.Log("errorMessage = " + errorMessage);
            Application.Quit();
        });
    }


}
