using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfSection : MonoBehaviour
{
    private GameObject LevelGenerator;
    public GameObject NextSpawnPoint;
    public bool isRight;

    private void Start()
    {
        LevelGenerator = GameObject.FindGameObjectWithTag("LevelGenerator");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wagon" && other.isTrigger == false)
        { 
            LevelGenerator.GetComponent<LevelGenerator>().OnSectionComplete(NextSpawnPoint, isRight);
        }
    }
}
