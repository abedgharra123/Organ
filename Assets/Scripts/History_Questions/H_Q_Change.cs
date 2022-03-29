using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Q_Change : MonoBehaviour
{

    public GameObject[] Questions;
    protected int ques_num;
    public AudioSource[] sound;
    // Start is called before the first frame update
    void Start()
    {
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

    /*transform to history game that abed will do*/
    public void History_Game()
    { 

    }
}
