﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse2Movement : MonoBehaviour
{
    public float leftJoyDeadZone = 0.1f;
    public float moveSpeedX = 0.5f;
    public float moveSpeedY = 0.5f;

    void Update()
    {
        if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Two).x < -leftJoyDeadZone
            || GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Two).x > leftJoyDeadZone)
        {
            //Vector3 tempMovement = this.transform.position;
            //tempMovement.x += GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Four).x * movementSpeed;
            //this.transform.position = tempMovement;
            GetComponent<Rigidbody>().AddForce(Vector3.right * GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Two).x * moveSpeedX);

        }
        if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Two).y < -leftJoyDeadZone
            || GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Two).y > leftJoyDeadZone)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Two).y * moveSpeedY);

            //Vector3 tempMovement = this.transform.position;
            //tempMovement.z += GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Four).y * movementSpeed;
            //this.transform.position = tempMovement;
        }

    }
}

