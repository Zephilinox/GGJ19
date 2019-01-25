using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GamepadInput
{
    public class AxisKeyCode
    {
        public KeyCode PositiveX;
        public KeyCode NegativeX;
        public KeyCode PositiveY;
        public KeyCode NegativeY;
    }

    public static class GamePad
    {
        public enum Button { A, B, Y, X, RightShoulder, LeftShoulder, RightStick, LeftStick, Back, Start }
        public enum Trigger { LeftTrigger, RightTrigger }
        public enum Axis { LeftStick, RightStick, Dpad }
        public enum Index { Any, One, Two, Three, Four }

        public static Dictionary<Index, Dictionary<Axis, AxisKeyCode>> AxisKeycodes = new Dictionary<Index, Dictionary<Axis, AxisKeyCode>>
        {
            {
                Index.Any,
                new Dictionary<Axis, AxisKeyCode>
                {
                    {Axis.LeftStick, new AxisKeyCode { PositiveX = KeyCode.D, NegativeX = KeyCode.A, PositiveY = KeyCode.W, NegativeY = KeyCode.S} },
                    {Axis.RightStick, new AxisKeyCode { PositiveX = KeyCode.D, NegativeX = KeyCode.A, PositiveY = KeyCode.W, NegativeY = KeyCode.S} },
                    {Axis.Dpad, new AxisKeyCode { PositiveX = KeyCode.D, NegativeX = KeyCode.A, PositiveY = KeyCode.W, NegativeY = KeyCode.S} },
                }
            },
            {
                Index.One,
                new Dictionary<Axis, AxisKeyCode>
                {
                    {Axis.LeftStick, new AxisKeyCode { PositiveX = KeyCode.D, NegativeX = KeyCode.A, PositiveY = KeyCode.W, NegativeY = KeyCode.S} },
                    {Axis.RightStick, new AxisKeyCode { PositiveX = KeyCode.D, NegativeX = KeyCode.A, PositiveY = KeyCode.W, NegativeY = KeyCode.S} },
                    {Axis.Dpad, new AxisKeyCode { PositiveX = KeyCode.D, NegativeX = KeyCode.A, PositiveY = KeyCode.W, NegativeY = KeyCode.S} },
                }
            },
            {
                Index.Two,
                new Dictionary<Axis, AxisKeyCode>
                {
                    {Axis.LeftStick, new AxisKeyCode { PositiveX = KeyCode.RightArrow, NegativeX = KeyCode.LeftArrow, PositiveY = KeyCode.UpArrow, NegativeY = KeyCode.DownArrow} },
                    {Axis.RightStick, new AxisKeyCode { PositiveX = KeyCode.RightArrow, NegativeX = KeyCode.LeftArrow, PositiveY = KeyCode.UpArrow, NegativeY = KeyCode.DownArrow} },
                    {Axis.Dpad, new AxisKeyCode { PositiveX = KeyCode.RightArrow, NegativeX = KeyCode.LeftArrow, PositiveY = KeyCode.UpArrow, NegativeY = KeyCode.DownArrow} },
                }
            },
            {
                Index.Three,
                new Dictionary<Axis, AxisKeyCode>
                {
                    {Axis.LeftStick, new AxisKeyCode { PositiveX = KeyCode.None, NegativeX = KeyCode.None, PositiveY = KeyCode.None, NegativeY = KeyCode.None} },
                    {Axis.RightStick, new AxisKeyCode { PositiveX = KeyCode.None, NegativeX = KeyCode.None, PositiveY = KeyCode.None, NegativeY = KeyCode.None} },
                    {Axis.Dpad, new AxisKeyCode { PositiveX = KeyCode.None, NegativeX = KeyCode.None, PositiveY = KeyCode.None, NegativeY = KeyCode.None} },
                }
            },
            {
                Index.Four,
                new Dictionary<Axis, AxisKeyCode>
                {
                    {Axis.LeftStick, new AxisKeyCode { PositiveX = KeyCode.None, NegativeX = KeyCode.None, PositiveY = KeyCode.None, NegativeY = KeyCode.None} },
                    {Axis.RightStick, new AxisKeyCode { PositiveX = KeyCode.None, NegativeX = KeyCode.None, PositiveY = KeyCode.None, NegativeY = KeyCode.None} },
                    {Axis.Dpad, new AxisKeyCode { PositiveX = KeyCode.None, NegativeX = KeyCode.None, PositiveY = KeyCode.None, NegativeY = KeyCode.None} },
                }
            }
        };

        public static Dictionary<Index, Dictionary<Button, KeyCode>> ButtonKeycodes = new Dictionary<Index, Dictionary<Button, KeyCode>>
        {
            {
                Index.Any,
                new Dictionary<Button, KeyCode>
                {
                    {Button.A, KeyCode.A },
                    {Button.B, KeyCode.Mouse1},
                    {Button.Y, KeyCode.Mouse2},
                    {Button.X, KeyCode.Mouse0},
                    {Button.RightShoulder, KeyCode.None},
                    {Button.LeftShoulder, KeyCode.None},
                    {Button.RightStick, KeyCode.None},
                    {Button.LeftStick, KeyCode.None},
                    {Button.Back, KeyCode.P},
                    {Button.Start, KeyCode.P}
                }
            },
            {
                Index.One,
                new Dictionary<Button, KeyCode>
                {
                    {Button.A, KeyCode.A },
                    {Button.B, KeyCode.Mouse1},
                    {Button.Y, KeyCode.Mouse2},
                    {Button.X, KeyCode.Mouse0},
                    {Button.RightShoulder, KeyCode.None},
                    {Button.LeftShoulder, KeyCode.None},
                    {Button.RightStick, KeyCode.None},
                    {Button.LeftStick, KeyCode.None},
                    {Button.Back, KeyCode.P},
                    {Button.Start, KeyCode.P}
                }
            },
            {
                Index.Two,
                new Dictionary<Button, KeyCode>
                {
                    {Button.A, KeyCode.J },
                    {Button.B, KeyCode.K},
                    {Button.Y, KeyCode.L},
                    {Button.X, KeyCode.M},
                    {Button.RightShoulder, KeyCode.None},
                    {Button.LeftShoulder, KeyCode.None},
                    {Button.RightStick, KeyCode.None},
                    {Button.LeftStick, KeyCode.None},
                    {Button.Back, KeyCode.None},
                    {Button.Start, KeyCode.None}
                }
            },
            {
                Index.Three,
                new Dictionary<Button, KeyCode>
                {
                    {Button.A, KeyCode.T },
                    {Button.B, KeyCode.None},
                    {Button.Y, KeyCode.None},
                    {Button.X, KeyCode.None},
                    {Button.RightShoulder, KeyCode.None},
                    {Button.LeftShoulder, KeyCode.None},
                    {Button.RightStick, KeyCode.None},
                    {Button.LeftStick, KeyCode.None},
                    {Button.Back, KeyCode.None},
                    {Button.Start, KeyCode.None}
                }
            },
            {
                Index.Four,
                new Dictionary<Button, KeyCode>
                {
                    {Button.A, KeyCode.Y },
                    {Button.B, KeyCode.None},
                    {Button.Y, KeyCode.None},
                    {Button.X, KeyCode.None},
                    {Button.RightShoulder, KeyCode.None},
                    {Button.LeftShoulder, KeyCode.None},
                    {Button.RightStick, KeyCode.None},
                    {Button.LeftStick, KeyCode.None},
                    {Button.Back, KeyCode.None},
                    {Button.Start, KeyCode.None}
                }
            },
        };

        public static Dictionary<Index, Dictionary<Trigger, KeyCode>> TriggerKeycodes = new Dictionary<Index, Dictionary<Trigger, KeyCode>>
        {
            {
                Index.Any,
                new Dictionary<Trigger, KeyCode>
                {
                    {Trigger.LeftTrigger, KeyCode.None},
                    {Trigger.RightTrigger, KeyCode.None},
                }
            },
            {
                Index.One,
                new Dictionary<Trigger, KeyCode>
                {
                    {Trigger.LeftTrigger, KeyCode.None},
                    {Trigger.RightTrigger, KeyCode.None},
                }
            },
            {
                Index.Two,
                new Dictionary<Trigger, KeyCode>
                {
                    {Trigger.LeftTrigger, KeyCode.None},
                    {Trigger.RightTrigger, KeyCode.None},
                }
            },
            {
                Index.Three,
                new Dictionary<Trigger, KeyCode>
                {
                    {Trigger.LeftTrigger, KeyCode.None},
                    {Trigger.RightTrigger, KeyCode.None},
                }
            },
            {
                Index.Four,
                new Dictionary<Trigger, KeyCode>
                {
                    {Trigger.LeftTrigger, KeyCode.None},
                    {Trigger.RightTrigger, KeyCode.None},
                }
            }
        };

        public static bool GetButtonDown(Button button, Index controlIndex)
        {
            KeyCode code = GetKeycode(button, controlIndex);
            bool gamePadButton = Input.GetKeyDown(code);
            bool keyboardButton = Input.GetKeyDown(ButtonKeycodes[controlIndex][button]);

            return gamePadButton || keyboardButton;
        }

        public static bool GetButtonUp(Button button, Index controlIndex)
        {
            KeyCode code = GetKeycode(button, controlIndex);
            bool gamePadButton = Input.GetKeyUp(code);
            bool keyboardButton = Input.GetKeyUp(ButtonKeycodes[controlIndex][button]);

            return gamePadButton || keyboardButton;
        }

        public static bool GetButton(Button button, Index controlIndex)
        {
            KeyCode code = GetKeycode(button, controlIndex);
            bool gamePadButton = Input.GetKey(code);
            bool keyboardButton = Input.GetKey(ButtonKeycodes[controlIndex][button]);

            return gamePadButton || keyboardButton;
        }

        public static Vector2 GetAxis(Axis axis, Index controlIndex, bool raw = false)
        {
            string xName = "", yName = "";
            switch (axis)
            {
                case Axis.Dpad:
                    xName = "DPad_XAxis_" + (int)controlIndex;
                    yName = "DPad_YAxis_" + (int)controlIndex;
                    break;
                case Axis.LeftStick:
                    xName = "L_XAxis_" + (int)controlIndex;
                    yName = "L_YAxis_" + (int)controlIndex;
                    break;
                case Axis.RightStick:
                    xName = "R_XAxis_" + (int)controlIndex;
                    yName = "R_YAxis_" + (int)controlIndex;
                    break;
            }

            Vector2 axisXY = Vector3.zero;

            try
            {
                if (raw)
                {
                    axisXY.x = Input.GetAxisRaw(xName);
                    axisXY.y = -Input.GetAxisRaw(yName);
                }
                else
                {
                    //Will have deadspot
                    axisXY.x = Input.GetAxis(xName);
                    axisXY.y = -Input.GetAxis(yName);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                Debug.LogWarning("Have you set up all axes correctly? \nThe easiest solution is to replace the InputManager.asset with version located in the GamepadInput package. \nWarning: do so will overwrite any existing input");
            }

            if (axisXY == Vector2.zero)
            {
                if (Input.GetKey(AxisKeycodes[controlIndex][axis].NegativeX))
                {
                    axisXY.x -= 1;
                }

                if (Input.GetKey(AxisKeycodes[controlIndex][axis].PositiveX))
                {
                    axisXY.x += 1;
                }

                if (Input.GetKey(AxisKeycodes[controlIndex][axis].NegativeY))
                {
                    axisXY.y -= 1;
                }

                if (Input.GetKey(AxisKeycodes[controlIndex][axis].PositiveY))
                {
                    axisXY.y += 1;
                }
            }

            return axisXY;
        }

        public static float GetTrigger(Trigger trigger, Index controlIndex, bool raw = false)
        {
            string name = "";
            if (trigger == Trigger.LeftTrigger)
                name = "TriggersL_" + (int)controlIndex;
            else if (trigger == Trigger.RightTrigger)
                name = "TriggersR_" + (int)controlIndex;

            float axis = 0;
            try
            {
                if (raw)
                    axis = Input.GetAxisRaw(name);
                else
                    axis = Input.GetAxis(name);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                Debug.LogWarning("Have you set up all axes correctly? \nThe easiest solution is to replace the InputManager.asset with version located in the GamepadInput package. \nWarning: do so will overwrite any existing input");
            }

            if (axis == 0)
            {
                if (Input.GetKey(TriggerKeycodes[controlIndex][trigger]))
                {
                    axis = 1;
                }
            }

            return axis;
        }


        static KeyCode GetKeycode(Button button, Index controlIndex)
        {
            switch (controlIndex)
            {
                case Index.One:
                    switch (button)
                    {
                        case Button.A: return KeyCode.Joystick1Button0;
                        case Button.B: return KeyCode.Joystick1Button1;
                        case Button.X: return KeyCode.Joystick1Button2;
                        case Button.Y: return KeyCode.Joystick1Button3;
                        case Button.RightShoulder: return KeyCode.Joystick1Button5;
                        case Button.LeftShoulder: return KeyCode.Joystick1Button4;
                        case Button.Back: return KeyCode.Joystick1Button6;
                        case Button.Start: return KeyCode.Joystick1Button7;
                        case Button.LeftStick: return KeyCode.Joystick1Button8;
                        case Button.RightStick: return KeyCode.Joystick1Button9;
                    }
                    break;
                case Index.Two:
                    switch (button)
                    {
                        case Button.A: return KeyCode.Joystick2Button0;
                        case Button.B: return KeyCode.Joystick2Button1;
                        case Button.X: return KeyCode.Joystick2Button2;
                        case Button.Y: return KeyCode.Joystick2Button3;
                        case Button.RightShoulder: return KeyCode.Joystick2Button5;
                        case Button.LeftShoulder: return KeyCode.Joystick2Button4;
                        case Button.Back: return KeyCode.Joystick2Button6;
                        case Button.Start: return KeyCode.Joystick2Button7;
                        case Button.LeftStick: return KeyCode.Joystick2Button8;
                        case Button.RightStick: return KeyCode.Joystick2Button9;
                    }
                    break;
                case Index.Three:
                    switch (button)
                    {
                        case Button.A: return KeyCode.Joystick3Button0;
                        case Button.B: return KeyCode.Joystick3Button1;
                        case Button.X: return KeyCode.Joystick3Button2;
                        case Button.Y: return KeyCode.Joystick3Button3;
                        case Button.RightShoulder: return KeyCode.Joystick3Button5;
                        case Button.LeftShoulder: return KeyCode.Joystick3Button4;
                        case Button.Back: return KeyCode.Joystick3Button6;
                        case Button.Start: return KeyCode.Joystick3Button7;
                        case Button.LeftStick: return KeyCode.Joystick3Button8;
                        case Button.RightStick: return KeyCode.Joystick3Button9;
                    }
                    break;
                case Index.Four:

                    switch (button)
                    {
                        case Button.A: return KeyCode.Joystick4Button0;
                        case Button.B: return KeyCode.Joystick4Button1;
                        case Button.X: return KeyCode.Joystick4Button2;
                        case Button.Y: return KeyCode.Joystick4Button3;
                        case Button.RightShoulder: return KeyCode.Joystick4Button5;
                        case Button.LeftShoulder: return KeyCode.Joystick4Button4;
                        case Button.Back: return KeyCode.Joystick4Button6;
                        case Button.Start: return KeyCode.Joystick4Button7;
                        case Button.LeftStick: return KeyCode.Joystick4Button8;
                        case Button.RightStick: return KeyCode.Joystick4Button9;
                    }

                    break;
                case Index.Any:
                    switch (button)
                    {
                        case Button.A: return KeyCode.JoystickButton0;
                        case Button.B: return KeyCode.JoystickButton1;
                        case Button.X: return KeyCode.JoystickButton2;
                        case Button.Y: return KeyCode.JoystickButton3;
                        case Button.RightShoulder: return KeyCode.JoystickButton5;
                        case Button.LeftShoulder: return KeyCode.JoystickButton4;
                        case Button.Back: return KeyCode.JoystickButton6;
                        case Button.Start: return KeyCode.JoystickButton7;
                        case Button.LeftStick: return KeyCode.JoystickButton8;
                        case Button.RightStick: return KeyCode.JoystickButton9;
                    }
                    break;
            }
            return KeyCode.None;
        }

        public static GamepadState GetState(Index controlIndex, bool raw = false)
        {
            GamepadState state = new GamepadState();

            state.A = GetButton(Button.A, controlIndex);
            state.B = GetButton(Button.B, controlIndex);
            state.Y = GetButton(Button.Y, controlIndex);
            state.X = GetButton(Button.X, controlIndex);

            state.RightShoulder = GetButton(Button.RightShoulder, controlIndex);
            state.LeftShoulder = GetButton(Button.LeftShoulder, controlIndex);
            state.RightStick = GetButton(Button.RightStick, controlIndex);
            state.LeftStick = GetButton(Button.LeftStick, controlIndex);

            state.Start = GetButton(Button.Start, controlIndex);
            state.Back = GetButton(Button.Back, controlIndex);

            state.LeftStickAxis = GetAxis(Axis.LeftStick, controlIndex, raw);
            state.rightStickAxis = GetAxis(Axis.RightStick, controlIndex, raw);
            state.dPadAxis = GetAxis(Axis.Dpad, controlIndex, raw);

            state.Left = (state.dPadAxis.x < 0);
            state.Right = (state.dPadAxis.x > 0);
            state.Up = (state.dPadAxis.y > 0);
            state.Down = (state.dPadAxis.y < 0);

            state.LeftTrigger = GetTrigger(Trigger.LeftTrigger, controlIndex, raw);
            state.RightTrigger = GetTrigger(Trigger.RightTrigger, controlIndex, raw);

            return state;
        }
    }

    public class GamepadState
    {
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

        public Vector2 LeftStickAxis = Vector2.zero;
        public Vector2 rightStickAxis = Vector2.zero;
        public Vector2 dPadAxis = Vector2.zero;

        public float LeftTrigger = 0;
        public float RightTrigger = 0;

    }
}