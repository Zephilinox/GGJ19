using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSection : MonoBehaviour
{
    private GameObject LevelGenerator;
    public bool isRight;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wagon")
        {
            //Delete section once wagon has passed
            Destroy(transform.parent.gameObject);
            Debug.Log("Destroying");
        }
    }
}
