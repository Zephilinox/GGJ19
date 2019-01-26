using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> m_obstacles;

    public List<GameObject> m_lanes;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void SpawnItem()
    {
        int spawnLane = Random.Range(0, m_lanes.Capacity - 1);

        GameObject temp = Instantiate(m_obstacles[Random.Range(0, m_lanes.Capacity - 1)]);

        temp.transform.position = m_lanes[spawnLane].transform.position;
    }
}