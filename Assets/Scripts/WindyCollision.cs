using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindyCollision : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision");
        GetComponent<MeshRenderer>().material.SetFloat("_Wind_Power", 0.5f);
        GetComponent<MeshRenderer>().material.SetFloat("_Wind_Speed", 2.5f);
        GetComponent<MeshRenderer>().material.SetFloat("_Noise_Size", 0.5f);
    }
}