using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSignText : MonoBehaviour
{
    public void SetRoadSignText(string place_name)
    {
        GetComponent<TextMesh>().text = place_name;
    }
}
