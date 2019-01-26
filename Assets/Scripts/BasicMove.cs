using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{

    public float speed = 5;
    public float initialSpeed;

	// Use this for initialization
	void Start ()
    {
        initialSpeed = speed;
	}

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(0, 0, speed* Time.deltaTime);
    }
}
