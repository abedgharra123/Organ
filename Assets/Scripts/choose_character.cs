using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choose_character : MonoBehaviour
{
    public GameObject Movment_info;
    public GameObject Main_Canvas;
    public GameObject Character_Choose;
    public GameObject Girls_Player;
    public GameObject Boys_Player;
    public GameObject pipe;
    public GameObject Exams_Panel;

    public void Girl_choose()
    {
        pipe.SetActive(true);
        PlayerPrefs.SetInt("IsCharacterPicked",2);
        Character_Choose.SetActive(false);
        Girls_Player.SetActive(true);
        Movment_info.SetActive(true);
        Exams_Panel.SetActive(false);

    }
    public void Boy_choose()
    {
        pipe.SetActive(true);
        PlayerPrefs.SetInt("IsCharacterPicked",1);
        Character_Choose.SetActive(false);
        Boys_Player.SetActive(true);
        Movment_info.SetActive(true);
        Exams_Panel.SetActive(false);

    }

    public void start_game()
    {
        Movment_info.SetActive(false);
        Main_Canvas.SetActive(true);
        Exams_Panel.SetActive(false);

    }
}
