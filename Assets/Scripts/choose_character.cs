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
    void Start()
    {
        Girls_Player.SetActive(false);
        Boys_Player.SetActive(false);
        Main_Canvas.SetActive(false);
        Movment_info.SetActive(false);

    }

    public void Girl_choose()
    {
        Character_Choose.SetActive(false);
        Girls_Player.SetActive(true);
        Movment_info.SetActive(true);
    }
    public void Boy_choose()
    {
        Character_Choose.SetActive(false);
        Boys_Player.SetActive(true);
        Movment_info.SetActive(true);
    }

    public void start_game()
    {
        Movment_info.SetActive(false);
        Main_Canvas.SetActive(true);

    }
}
