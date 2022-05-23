using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    //phyzical objects
    [SerializeField] private GameObject Education_terrain;
    [SerializeField] private GameObject Garden_Terrain;
    [SerializeField] private GameObject Map;
    [SerializeField] private GameObject pipe;
    //UI
    [SerializeField] private GameObject Movment_info;
    [SerializeField] private GameObject Character_Choose;
    [SerializeField] private GameObject Main_Canvas;
    [SerializeField] private GameObject Boy;
    [SerializeField] private GameObject Girl;
    void Start()
    {
        int index = PlayerPrefs.GetInt("IsCharacterPicked", 0);
        if (index == 1)
        { // boy
            Main_Canvas.SetActive(true);
            Camera.main.transform.rotation = new Quaternion(0, 0, 0, 0);
            Boy.SetActive(true);
            Map.SetActive(true);
            if (PlayerPrefs.GetInt("Red_Carpet", 0) == 0)
                Boy.transform.position = playerControllerInput.LastPosition;
            else
                Boy.transform.position = new Vector3(11.3094f, 2.69f, 44.726f);
            Destroy(pipe);
        }
        else if (index == 2)
        { // girl
            Main_Canvas.SetActive(true);
            Camera.main.transform.rotation = new Quaternion(0, 0, 0, 0);
            Girl.SetActive(true);
            Map.SetActive(true);
            if (PlayerPrefs.GetInt("Red_Carpet", 0) == 0)
                Girl.transform.position = playerControllerInput.LastPosition;
            else
                Girl.transform.position = new Vector3(11.3094f, 2.69f, 44.726f);
            Destroy(pipe);
        }
        else
        { // first game openning
            Camera.main.transform.position = new Vector3(513, 112, 405);
            pipe.SetActive(true);
            Character_Choose.SetActive(true);
        }
    }
}
