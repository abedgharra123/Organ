using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Q_Change : MonoBehaviour
{

    public GameObject[] Questions;
    public GameObject Player_Movement;
    public GameObject History_Map;
    protected int ques_num;
    public AudioSource[] sound;

    // Start is called before the first frame update
    void Start()
    {
        Player_Movement.SetActive(false);
        History_Map.SetActive(false);
        ques_num = 0;
        for (int i = 1; i <=4; i++)
        {
            Questions[i].SetActive(false);
        }
        
    }

    public void Correct_A()
    {
            sound[0].Play();
            Questions[ques_num].SetActive(false);
            ques_num++;
            Questions[ques_num].SetActive(true);
    }
    public void Wrong_A()
    {
        sound[1].Play();
    }

    /*transform to history game */
    public void History_Game()
    {
        for (int i = 0; i <= 5; i++)
        {
            Destroy(Questions[i]);
        }
        Player_Movement.SetActive(true);
        History_Map.SetActive(true);
    }
}
