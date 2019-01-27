using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tombstone : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody>().mass *= Random.Range(0.5f, 2.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("Camera2").GetComponent<Camera2>().Shake();
    }
}
