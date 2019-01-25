using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadTest : MonoBehaviour
{
    public Vector2 dpad;
    public Vector2 leftstick;
    public Vector2 rightstick;

    public bool A = false;
    public bool B = false;
    public bool X = false;
    public bool Y = false;
    public bool Start = false;
    public bool Back = false;
    public bool Left = false;
    public bool Right = false;
    public bool Up = false;
    public bool Down = false;
    public bool LeftStick = false;
    public bool RightStick = false;
    public bool RightShoulder = false;
    public bool LeftShoulder = false;

    public float lefttrigger;
    public float righttrigger;

    private void Update()
    {
        dpad = GamePad.GetAxis(GamePad.Axis.Dpad, GamePad.Index.Any);
        leftstick = GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Any);
        rightstick = GamePad.GetAxis(GamePad.Axis.RightStick, GamePad.Index.Any);

        lefttrigger = GamePad.GetTrigger(GamePad.Trigger.LeftTrigger, GamePad.Index.Any);
        righttrigger = GamePad.GetTrigger(GamePad.Trigger.RightTrigger, GamePad.Index.Any);

        A = GamePad.GetButton(GamePad.Button.A, GamePad.Index.Any);
        B = GamePad.GetButton(GamePad.Button.B, GamePad.Index.Any);
        X = GamePad.GetButton(GamePad.Button.X, GamePad.Index.Any);
        Y = GamePad.GetButton(GamePad.Button.Y, GamePad.Index.Any);
        Start = GamePad.GetButton(GamePad.Button.Start, GamePad.Index.Any);
        Back = GamePad.GetButton(GamePad.Button.Back, GamePad.Index.Any);
        LeftStick = GamePad.GetButton(GamePad.Button.LeftStick, GamePad.Index.Any);
        RightStick = GamePad.GetButton(GamePad.Button.RightStick, GamePad.Index.Any);
        RightShoulder = GamePad.GetButton(GamePad.Button.RightShoulder, GamePad.Index.Any);
        LeftShoulder = GamePad.GetButton(GamePad.Button.LeftShoulder, GamePad.Index.Any);
    }
}