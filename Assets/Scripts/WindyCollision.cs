using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindyCollision : MonoBehaviour
{
    float windPower = 0;
    float windSpeed = 0;
    float noiseSize = 0;
    bool colliding = false;

    private void Update()
    {
        GetComponent<MeshRenderer>().material.SetFloat("_Wind_Power", windPower);
        GetComponent<MeshRenderer>().material.SetFloat("_Wind_Speed", windSpeed);
        GetComponent<MeshRenderer>().material.SetFloat("_Noise_Size", noiseSize);

        if (!colliding)
        {
            windPower *= 0.90f;
            windSpeed *= 0.90f;
            noiseSize *= 0.90f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        colliding = true;
        windPower += 0.2f;
        windSpeed += 0.2f;
        noiseSize += 0.2f;
    }

    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        colliding = true;
        windPower += 0.005f;
        windSpeed += 0.005f;
        noiseSize += 0.005f;
    }
}