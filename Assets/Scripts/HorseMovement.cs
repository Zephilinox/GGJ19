using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMovement : MonoBehaviour
{
    public float leftJoyDeadZone = 0.1f;
    public float moveSpeedX = 0.5f;
    public float moveSpeedY = 0.5f;

    public int playerNum;
    GamePad.Index Player;

    private void Start()
    {
        switch(playerNum)
        {
            case 1:
                Player = GamePad.Index.One;
                break;
            case 2:
                Player = GamePad.Index.Two;
                break;
            case 3:
                Player = GamePad.Index.Three;
                break;
            case 4:
                Player = GamePad.Index.Four;
                break;
        }
    }

    void Update()
    {
        if (GamePad.GetAxis(GamePad.Axis.LeftStick, Player).x < -leftJoyDeadZone
            || GamePad.GetAxis(GamePad.Axis.LeftStick, Player).x > leftJoyDeadZone)
        {
            //Vector3 tempMovement = this.transform.position;
            //tempMovement.x += GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Four).x * movementSpeed;
            //this.transform.position = tempMovement;
            GetComponent<Rigidbody>().AddForce(Vector3.right * GamePad.GetAxis(GamePad.Axis.LeftStick, Player).x * moveSpeedX);

        }
        if (GamePad.GetAxis(GamePad.Axis.LeftStick, Player).y < -leftJoyDeadZone
            || GamePad.GetAxis(GamePad.Axis.LeftStick, Player).y > leftJoyDeadZone)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * GamePad.GetAxis(GamePad.Axis.LeftStick, Player).y * moveSpeedY);

            //Vector3 tempMovement = this.transform.position;
            //tempMovement.z += GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Four).y * movementSpeed;
            //this.transform.position = tempMovement;
        }

    }
}
