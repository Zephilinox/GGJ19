using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanWobble : MonoBehaviour
{
    [SerializeField]
    private float wobble_z_amout;
    [SerializeField]
    private float wobble_z_interval;
    private bool flip_z = false;
    private float z_time = 0;
    private bool z_initial = true;

    [SerializeField]
    private float wobble_y_amout;
    [SerializeField]
    private float wobble_y_interval;
    private bool flip_y = false;
    private float y_time = 0;



    void Update()
    {
        z_time += Time.deltaTime;
        y_time += Time.deltaTime;

        //z wobble
        if (z_time > wobble_z_interval)
        {
            flip_z = !flip_z;
            z_time = 0;
            if (z_initial)
            {
                z_initial = false;
                wobble_z_amout *= 2;
            }
        }

        if (flip_z)
        {
            transform.Rotate(Vector3.right, wobble_z_amout * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.right, -wobble_z_amout * Time.deltaTime);
        }


        if (y_time > wobble_y_interval)
        {
            y_time = 0;
        }


    }
}
