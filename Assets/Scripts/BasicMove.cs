using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{

    public float speed = 5;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(0, 0, speed* Time.deltaTime);
    }
}
