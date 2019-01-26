using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse1Movement : MonoBehaviour
{
    public float leftJoyDeadZone = 0.1f;
    public float movementSpeed = 0.5f;

	void Update ()
    {
        if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One).x < -leftJoyDeadZone 
            || GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One).x > leftJoyDeadZone)
        {
            Vector3 tempMovement = this.transform.position;
            tempMovement.x += GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One).x * movementSpeed;
            this.transform.position = tempMovement;
        }
        if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One).y < -leftJoyDeadZone
            || GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One).y > leftJoyDeadZone)
        {
            Vector3 tempMovement = this.transform.position;
            tempMovement.z += GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One).y * movementSpeed;
            this.transform.position = tempMovement;
        }

    }
}
