using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] horses;
    GameObject wagon;

    [SerializeField]
    
    // Use this for initialization
    void Start()
    {
        //horses = GameObject.FindGameObjectsWithTag("Horse");
        wagon = GameObject.FindGameObjectWithTag("Wagon");
    }

    public void IncrementBaseSpeed(float speedIncrement)
    {
        foreach (GameObject horse in horses)
        {
            horse.GetComponent<BasicMove>().speed += speedIncrement;
            horse.GetComponent<BasicMove>().initialSpeed = horse.GetComponent<BasicMove>().speed;
        }

        wagon.GetComponent<BasicMove>().speed += speedIncrement;
    }

}

