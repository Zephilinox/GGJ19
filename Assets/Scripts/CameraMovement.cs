using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject caravanModel;
    public float speed = 2.0f;
    private Vector3 offset;


    private void Start()
    {
        offset = this.transform.position;
    }

    void Update ()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;

        position.x = Mathf.Lerp(this.transform.position.x, caravanModel.transform.position.x + offset.x, interpolation);
        position.y = Mathf.Lerp(this.transform.position.y, caravanModel.transform.position.y + offset.y, interpolation);
        position.z = Mathf.Lerp(this.transform.position.z, caravanModel.transform.position.z + offset.z, interpolation);


        this.transform.position = position;
    }
}

