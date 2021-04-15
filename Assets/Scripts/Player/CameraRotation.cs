using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] Joystick joystickRight;

    // Start is called before the first frame update
    void Start()
    {
        CinemachineCore.GetInputAxis = JoystickAxisInput;
    }

    private float JoystickAxisInput(string axisName)
    {
        switch (axisName)
        {
            case "Mouse X":
                return joystickRight.Horizontal;
            case "Mouse Y":
                return joystickRight.Vertical;
            default:
                Debug.LogError($"Input {axisName} is not recognized", this);
                break;
        }

        return 0;
    }
}
