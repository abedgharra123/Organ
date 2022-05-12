using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsAndArrow : MonoBehaviour
{
    // [0]- Acoustics . [1]-History  . [2]- pythagoras  . [3]- Johann
    public GameObject[] Arrow;
    // [0]-History  . [1]- pythagoras  . [2]- Johann . [3]  Organ Parts Gate
    public GameObject[] Door;    
    


    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("Score_1", 0) > 0)
        {
            Arrow[0].SetActive(false);
            Door[0].SetActive(false);
            Arrow[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Score_2", 0) > 0)
        {
            Arrow[1].SetActive(false);
            Door[1].SetActive(false);
            Arrow[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Pythagoras", 0) == 1)
        {
            Arrow[2].SetActive(false);
            Door[2].SetActive(false);
            Arrow[3].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Johann", 0) == 1)
        {
            Arrow[3].SetActive(false);
            Door[3].SetActive(false);
        }
    }
}
