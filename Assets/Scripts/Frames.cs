using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frames : MonoBehaviour
{
    float timer = 0;
    float delay = 0.2f;
    int frame = 0;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > delay)
        {
            SetFrame(frame++);
            timer = 0;
        }
    }

    private void SetFrame(int frame)
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(i == frame);
            i++;
        }
    }
}
