using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningText : MonoBehaviour
{
	void LateUpdate()
    {
        GetComponent<TextMesh>().text = LevelGenerator.home;
	}
}