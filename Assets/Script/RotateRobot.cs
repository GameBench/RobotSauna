using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRobot : MonoBehaviour
{
    void Update()
    {
        this.gameObject.transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.Self);
    }
}
