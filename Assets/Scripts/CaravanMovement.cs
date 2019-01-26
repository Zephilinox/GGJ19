using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CaravanMovement : MonoBehaviour
{

    public List<GameObject> Horses = new List<GameObject>();

    [SerializeField]
    private float avg_x;
    public float speed;

    void Start ()
    {
        Horses = GameObject.FindGameObjectsWithTag("Horse").ToList();
	}
	
	// Update is called once per frame
	void Update ()
    {

        avg_x = 0;

		foreach(GameObject horse in Horses)
        {
            avg_x += horse.transform.position.x;
        }

        avg_x = avg_x / Horses.Count;


        Vector3 tempPos = new Vector3(avg_x, transform.position.y, transform.position.z);
        //transform.position = tempPos;

        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;

        position.x = Mathf.Lerp(this.transform.position.x, tempPos.x, interpolation);
        //position.y = Mathf.Lerp(this.transform.position.y, tempPos + offset.y, interpolation);
        //position.z = Mathf.Lerp(this.transform.position.z, tempPos.z, interpolation);


        this.transform.position = position;

    }
}
