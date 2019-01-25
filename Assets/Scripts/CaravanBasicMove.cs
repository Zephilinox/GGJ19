using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanBasicMove : MonoBehaviour
{

    public float speed = 1;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(0, 0, speed* Time.deltaTime);
    }
}
