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
    private GameObject pipe;

    // Use this for initialization
    void Start()
    {
        Control = GetComponent<ThirdPersonUserControl>();
        Camera.main.transform.position = new Vector3(513,112,405);


    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Games_Gate")
            transform.position = new Vector3(213.65f, 0, 180.07f);
        if (col.collider.tag == "Back_Gate")
            transform.position = new Vector3(2.33f, 0, 54.37f);
        if (col.collider.tag == "pipe_end")
        {
            transform.position = new Vector3(2.26555f, 0, 3.683381f);
            Destroy(pipe);
        }
        // if (col.collider.tag == "start_pipe")
        //  AudioSource.PlayClipAtPoint(sound, col.transform.position);




    }
    // Update is called once per frame
    void Update()
    {
        pipe = GameObject.FindGameObjectWithTag("pipe_end_2");
        Control.m_Jump = Button.Pressed;
        Control.Hinput = LeftJoystick.Horizontal;
        Control.Vinput = LeftJoystick.Vertical;

        CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 3, 4);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);

    }
}