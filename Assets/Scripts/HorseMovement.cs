using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMovement : MonoBehaviour
{
    public float leftJoyDeadZone = 0.1f;
    public float moveSpeedX = 30f;
    public float moveSpeedY = 30f;
    public float maxDistFromWagon = 15;
    public int playerNum;
    [HideInInspector] public float initialMoveY;
    private bool canMoveForward;

    GamePad.Index Player;
    GameObject wagon;
    [SerializeField] GameObject horseModel;


    private void Start()
    {
        wagon = GameObject.FindGameObjectWithTag("Wagon");

        initialMoveY = moveSpeedY;

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

    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Horse")
        {
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<BasicMove>().speed = 0;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Horse")
        {
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<BasicMove>().speed = GetComponent<BasicMove>().initialSpeed;
            ;
        }
    }

    private void FixedUpdate()
    {
        JoystickMovement();
    }


    void JoystickMovement()
    {

        if(Vector3.Distance(wagon.transform.position, transform.position) >= maxDistFromWagon)
        {
            canMoveForward = false;
        }
        else
        {
            canMoveForward = true;
        }

        float angle;

        if (GamePad.GetAxis(GamePad.Axis.LeftStick, Player).x < -leftJoyDeadZone
        || GamePad.GetAxis(GamePad.Axis.LeftStick, Player).x > leftJoyDeadZone)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * GamePad.GetAxis(GamePad.Axis.LeftStick, Player).x * moveSpeedX);
            angle = GamePad.GetAxis(GamePad.Axis.LeftStick, Player).x * 10;
        }
        else
        {
            angle = 0;
        }

        horseModel.transform.localRotation = Quaternion.Euler(0, angle, 0);

        //Debug.Log(angle);

        if (GamePad.GetAxis(GamePad.Axis.LeftStick, Player).y < -leftJoyDeadZone)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * GamePad.GetAxis(GamePad.Axis.LeftStick, Player).y * moveSpeedY);
        }
        if(GamePad.GetAxis(GamePad.Axis.LeftStick, Player).y > leftJoyDeadZone && canMoveForward)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * GamePad.GetAxis(GamePad.Axis.LeftStick, Player).y * moveSpeedY);
        }
    }


}
