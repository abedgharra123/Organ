using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exams_Panel : MonoBehaviour
{
    /*[0]-shadow_cup  [1]-bronze_cup [2]-silver_cup  [3]-Gold_cup*/
    public GameObject[] acoustics_exam;

    /*[0]-shadow_cup  [1]-bronze_cup [2]-silver_cup  [3]-Gold_cup*/
    public GameObject[] history_exam;

    public GameObject Final_exam;
    void Start()
    {
        Acoustics_result();
        History_result();
        Final_exam_panel();
    }

    public void Acoustics_result()
    {
        if (ScoreHandler.Score_1 > 12)
        {
            acoustics_exam[3].SetActive(true);
            acoustics_exam[1].SetActive(false);
            acoustics_exam[2].SetActive(false);
            acoustics_exam[0].SetActive(false);
        }
        else if (ScoreHandler.Score_1 > 9 )
        {
            acoustics_exam[2].SetActive(true);
            acoustics_exam[1].SetActive(false);
            acoustics_exam[0].SetActive(false);
            acoustics_exam[3].SetActive(false);
        }
        else if (ScoreHandler.Score_1 > 0)
        {
            acoustics_exam[1].SetActive(true);
            acoustics_exam[0].SetActive(false);
            acoustics_exam[2].SetActive(false);
            acoustics_exam[3].SetActive(false);

        }
        else
        {
            acoustics_exam[0].SetActive(true);
            acoustics_exam[1].SetActive(false);
            acoustics_exam[2].SetActive(false);
            acoustics_exam[3].SetActive(false);
        }
    }public void History_result()
    {
        if (ScoreHandler.Score_2 > 85)
        {
            history_exam[3].SetActive(true);
            history_exam[1].SetActive(false);
            history_exam[2].SetActive(false);
            history_exam[0].SetActive(false);
        }
        else if (ScoreHandler.Score_2 > 70)
        {
            history_exam[2].SetActive(true);
            history_exam[1].SetActive(false);
            history_exam[0].SetActive(false);
            history_exam[3].SetActive(false);
        }
        else if (ScoreHandler.Score_2 > 0)
        {
            history_exam[1].SetActive(true);
            history_exam[0].SetActive(false);
            history_exam[2].SetActive(false);
            history_exam[3].SetActive(false);

        }
        else
        {
            history_exam[0].SetActive(true);
            history_exam[1].SetActive(false);
            history_exam[2].SetActive(false);
            history_exam[3].SetActive(false);
        }
    }

    public void Final_exam_panel()
    {
        if (ScoreHandler.Score_1 > 12 && ScoreHandler.Score_2 > 85)
        {
            Final_exam.SetActive(true);
        }
        else
        {
            Final_exam.SetActive(false);

        }
    }
}
