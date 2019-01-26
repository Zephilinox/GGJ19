using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> sections;
	

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnSectionComplete(GameObject nextSpawnPoint)
    {
        //cycle through all stored levels that are available
        //first one thats unused, move to target pos

        

        GameObject temp = Instantiate(sections[Random.Range(0, sections.Count - 1)]);
        temp.transform.position = nextSpawnPoint.transform.position;
    }
}
