using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSection : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wagon"&& other.isTrigger == false)
        {
            //Delete section once wagon has passed
            Destroy(transform.parent.gameObject);
        }
    }
}
