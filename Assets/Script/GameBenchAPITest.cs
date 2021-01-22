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

        Invoke("StartSession", 5);
    }


    void StartSession()
    {

        Gamebench.Start();

        // Enable power metrics which aren't normally collected that frequently
        Gamebench.MetricEnable(MetricType.POW, 5);
        Gamebench.MetricEnable(MetricType.BAT, 5);

        // Schedule some API calls and the end of the session
        Invoke("MarkLaunchComplete", 2);
        Invoke("MarkStart", 5);
        Invoke("MarkStop", 10);
        Invoke("StopSession", 15);
    }
    void MarkLaunchComplete() {
        Gamebench.MarkLaunchComplete();
    }
    void MarkStart() {
        Gamebench.MarkStart("API Test Session");
    }
    void MarkStop() {
        Gamebench.MarkStop("API Test Session");
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
