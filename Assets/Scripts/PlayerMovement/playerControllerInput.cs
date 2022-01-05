using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

public class playerControllerInput : MonoBehaviour
{

    public FixedJoystick LeftJoystick;
    public FixedButton Button;
    public FixedTouchField TouchField;
    protected ThirdPersonUserControl Control;

    protected float CameraAngle ;
    protected float CameraAngleSpeed = 0.2f;
    public AudioClip sound;
    public AudioClip sound2;
    // Use this for initialization
    void Start()
    {
        Control = GetComponent<ThirdPersonUserControl>();
        Camera.main.transform.position = new Vector3(513,112,405);
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Games_Gate")
            transform.position = new Vector3(362, 0, -82);
        if (col.collider.tag == "Back_Gate")
            transform.position = new Vector3(3 , 1.11f, 4);
       // if (col.collider.tag == "start_pipe")
          //  AudioSource.PlayClipAtPoint(sound, col.transform.position);




    }
    // Update is called once per frame
    void Update()
    {
        Control.m_Jump = Button.Pressed;
        Control.Hinput = LeftJoystick.Horizontal;
        Control.Vinput = LeftJoystick.Vertical;

        CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 3, 4);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);

    }
}