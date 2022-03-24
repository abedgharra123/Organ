using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine;

public class OwnThirdPersonController : MonoBehaviour
{
    public FixedJoystick LeftJoystick;
    public FixedButton Button;
    public FixedTouchField TouchField;
    protected ThirdPersonUserControl Control;

    protected float CameraAngle;
    protected float CameraAngleSpeed = 0.2f;
    protected float CameraPosSpeed = 0.004f;
    protected float CameraPosY;


    void Start()
    {
        Control = GetComponent<ThirdPersonUserControl>();
        Camera.main.transform.position = new Vector3(513, 112, 405);
        
    }

    // Update is called once per frame
        void FixedUpdate()
        {
            Control.m_Jump = Button.Pressed;
            Control.Hinput = LeftJoystick.Horizontal;
            Control.Vinput = LeftJoystick.Vertical;

            CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;
            CameraPosY = Mathf.Clamp(CameraPosY - TouchField.TouchDist.y * CameraPosSpeed, 0, 5f);

            Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, CameraPosY, 4);
            Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);

        }
    }
