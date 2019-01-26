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
        //position.y = Mathf.Lerp(this.transform.position.y, tempPos + offset.y, interpolation);
        //position.z = Mathf.Lerp(this.transform.position.z, tempPos.z, interpolation);

        this.transform.position = position;

        Vector3 lookAtPosition = new Vector3(avg_x, 0, avg_z);
        Vector3 direction = lookAtPosition - position;
        Vector3 lookAtDirection = transform.InverseTransformDirection(direction);

        model.transform.localRotation = Quaternion.LookRotation(new Vector3(lookAtDirection.x, 0f, lookAtDirection.z));

        Debug.Log(transform.rotation);
    }
}
