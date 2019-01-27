using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseReset : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Horse")
        {
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            other.GetComponent<BasicMove>().speed = 0;
            other.GetComponent<HorseMovement>().moveSpeedY = other.GetComponent<HorseMovement>().moveSpeedY / 2;
            AudioManager.instance.Play("Neigh2");


            StartCoroutine(HorseResetTime(other));
        }
    }
    IEnumerator HorseResetTime(Collider other)
    {
        yield return new WaitForSeconds(3);
        other.GetComponent<HorseMovement>().StopCollision();
        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        other.transform.rotation = Quaternion.identity;
        other.GetComponent<BasicMove>().speed = other.GetComponent<BasicMove>().initialSpeed;
        other.transform.position = GameObject.FindGameObjectWithTag("Wagon").transform.position + new Vector3(0,0,5);
        other.GetComponent<HorseMovement>().moveSpeedY = other.GetComponent<HorseMovement>().initialMoveY;
        other.GetComponent<HorseMovement>().deathCount++;

    }
}
