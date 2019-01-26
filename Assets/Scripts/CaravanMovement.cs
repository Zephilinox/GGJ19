using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CaravanMovement : MonoBehaviour
{

    public List<GameObject> Horses = new List<GameObject>();

    public GameObject model;

    [SerializeField]
    private float avg_x;

    private float avg_z;

    private Vector3 previousPosition;

    public float speed;

    void Start ()
    {
        Horses = GameObject.FindGameObjectsWithTag("Horse").ToList();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Horses.Count == 0) {return;}

        avg_x = 0;
        avg_z = 0;


		foreach(GameObject horse in Horses)
        {
            avg_x += horse.transform.position.x;
            avg_z += horse.transform.position.z;
        }

        avg_x = avg_x / Horses.Count;
        avg_z = avg_z / Horses.Count;


        //Wagon Movement!
        Vector3 tempPos = new Vector3(avg_x, transform.position.y, transform.position.z);
        //transform.position = tempPos;

        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;

        position.x = Mathf.Lerp(this.transform.position.x, tempPos.x, interpolation);

        this.transform.position = position;
    }

    private void LateUpdate()
    {
        //Wagon Look At!
        Vector3 direction = this.transform.position - previousPosition;
        Vector3 lookAtDirection = transform.InverseTransformDirection(direction);

        previousPosition = this.transform.position;

        model.transform.localRotation = Quaternion.LookRotation(new Vector3(lookAtDirection.x, 0f, lookAtDirection.z));
    }
}
