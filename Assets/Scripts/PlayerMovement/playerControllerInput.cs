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
    protected float CameraPosSpeed = 0.005f;
    protected float CameraPosY;

    public AudioClip sound;
    public AudioClip sound2;
    public GameObject pipe;
    public GameObject Education_terrain;
    public GameObject Garden_Terrain;
    public GameObject Map;
   




    // Use this for initialization
    void Start()
    {
        Control = GetComponent<ThirdPersonUserControl>();
        Camera.main.transform.position = new Vector3(513,112,405);
        Education_terrain.SetActive(false);
        Garden_Terrain.SetActive(false);
        Map.SetActive(false);


    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Games_Gate")
        {
            Map.SetActive(false);
            Education_terrain.SetActive(false);
            Garden_Terrain.SetActive(true);
            transform.position = new Vector3(247.3617f, -0.0004883409f, 0.8558963f);
            
        }
        if (col.collider.tag == "Back_Gate")
        {
            Garden_Terrain.SetActive(false);
            Map.SetActive(true);
            Education_terrain.SetActive(true);
            transform.position = new Vector3(10.94437f, 2.686021f, 41.161f);

        }
        if (col.collider.tag == "pipe_end")
        {
            Map.SetActive(true);
            Education_terrain.SetActive(true);
            transform.position = new Vector3(10.73f, 2.686022f, -10.9f);
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
        CameraPosY = Mathf.Clamp(CameraPosY - TouchField.TouchDist.y * CameraPosSpeed, 0.5f, 5f);

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, CameraPosY, 4);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);

    }

    

   
}