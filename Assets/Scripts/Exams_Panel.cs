using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    void Update()
    {
        Final_exam_panel();
    }

    public void Acoustics_result()
    {
        int score = ScoreHandler.GetScore(1);
        if (score > 12)
        {
            acoustics_exam[3].SetActive(true);
            acoustics_exam[1].SetActive(false);
            acoustics_exam[2].SetActive(false);
            acoustics_exam[0].SetActive(false);
        }
        else if (score > 9)
        {
            acoustics_exam[2].SetActive(true);
            acoustics_exam[1].SetActive(false);
            acoustics_exam[0].SetActive(false);
            acoustics_exam[3].SetActive(false);
        }
        else if (score > 0)
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
    }
    public void History_result()
    {
        int score = ScoreHandler.GetScore(2);
        if (score > 85)
        {
            history_exam[3].SetActive(true);
            history_exam[1].SetActive(false);
            history_exam[2].SetActive(false);
            history_exam[0].SetActive(false);
        }
        else if (score > 70)
        {
            history_exam[2].SetActive(true);
            history_exam[1].SetActive(false);
            history_exam[0].SetActive(false);
            history_exam[3].SetActive(false);
        }
        else if (score > 0)
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
        if (ScoreHandler.GetScore(1) > 12 && ScoreHandler.GetScore(2) > 85 && PlayerPrefs.GetInt("Pythagoras", 0) != 0 && PlayerPrefs.GetInt("Johann", 0) != 0)
        {
            Final_exam.SetActive(true);
        }
        else
        {
            Final_exam.SetActive(false);

        }
    }

    public void Acoustics_Game()
    {
        AudioManager.instance.Pause("Main_Field");
        SceneManager.LoadScene(2);

    }
    public void history_Game()
    {
        AudioManager.instance.Pause("Main_Field");
        SceneManager.LoadScene(6);
    }
}
