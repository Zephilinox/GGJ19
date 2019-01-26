using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfSection : MonoBehaviour
{
    private GameObject LevelGenerator;
    public GameObject NextSpawnPoint;

    private void Start()
    {
        LevelGenerator = GameObject.FindGameObjectWithTag("LevelGenerator");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wagon")
        {
            LevelGenerator.GetComponent<LevelGenerator>().OnSectionComplete(NextSpawnPoint);
        }
    }
}
