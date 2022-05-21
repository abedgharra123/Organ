using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Proyecto26;

public class History_Game : MonoBehaviour
{

    public GameObject Transform_Shadow;
    public GameObject Smily_Effect;
    private int Correct_Count;
    public GameObject[] History_Levels;
    private int level_num;
    public int history_score;
    public Text score_txt;
    public GameObject Game_end_Panel;
    /*[0]-gold_cup [1]-silver_cup [2]-red_cup*/
    public GameObject[] Trophies;
    public GameObject Playey_Movenment;

    // Start is called before the first frame update
    void Start()
    {
        history_score = 100;
        level_num = 0;
        for (int i = 1; i < History_Levels.Length; i++)
        {
            History_Levels[i].SetActive(false);
        }
        Correct_Count = 0;
        Transform_Shadow.SetActive(false);
        Smily_Effect.SetActive(false);
        Game_end_Panel.SetActive(false);

    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Correct_Answer" && col.gameObject.GetComponent<Renderer>().material.color != Color.green)
        {
            Smily_Effect.SetActive(true);
            col.gameObject.GetComponent<Renderer>().material.color = Color.green;
            Invoke("Delay_Smile", 1f);
            Correct_Count++;
            switch (Correct_Count)
            {
                case 2:
                    Transform_Shadow.SetActive(true);
                    Invoke("Next_Level", 1f);
                    break;
                case 4:
                    Transform_Shadow.SetActive(true);
                    Invoke("Next_Level", 1f);
                    break;
                case 7:
                    Transform_Shadow.SetActive(true);
                    Invoke("Next_Level", 1f);
                    break;
                case 10:
                    Transform_Shadow.SetActive(true);
                    Invoke("Next_Level", 1f);
                    break;
                case 12:
                    Transform_Shadow.SetActive(true);
                    Invoke("Next_Level", 1f);
                    break;
                case 15:
                    Transform_Shadow.SetActive(true);
                    Invoke("Next_Level", 1f);
                    break;
                case 17:
                    Transform_Shadow.SetActive(true);
                    Invoke("Game_End_Panel", 1f);
                    break;

            }
        }
        if (col.collider.tag == "Wrong_Answer" && col.gameObject.GetComponent<Renderer>().material.color != Color.red)
        {
            history_score -= 2;
            col.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

    }

    public void Next_Level()
    {
        History_Levels[level_num].SetActive(false);
        transform.position = new Vector3(5.13f, 0.06f, 5.26f);
        History_Levels[++level_num].SetActive(true);
        Invoke("Delay", 2f);
    }

    public void Game_End_Panel()
    {
        if (history_score > PlayerPrefs.GetInt("Score_2", 0))
            PlayerPrefs.SetInt("Score_2", history_score);
        Sign_in.p.history_game_result = history_score;
        RestClient.Put("https://pipe-organ-372bf-default-rtdb.firebaseio.com/" + Sign_in.p.username + ".json", Sign_in.p);
        History_Levels[level_num].SetActive(false);
        Playey_Movenment.SetActive(false);
        if (history_score > 85)
        {
            score_txt.color = Color.green;
            score_txt.text = "" + history_score + "%";
            Trophies[0].SetActive(true);
            Trophies[1].SetActive(false);
            Trophies[2].SetActive(false);
        }
        else if (history_score > 70)
        {
            score_txt.color = Color.yellow;
            score_txt.text = "" + history_score + "%";
            Trophies[1].SetActive(true);
            Trophies[0].SetActive(false);
            Trophies[2].SetActive(false);
        }
        else
        {
            score_txt.color = Color.red;
            score_txt.text = "" + history_score + "%";
            Trophies[2].SetActive(true);
            Trophies[0].SetActive(false);
            Trophies[1].SetActive(false);

        }
        Game_end_Panel.SetActive(true);
    }
    public void Delay()
    {
        Transform_Shadow.SetActive(false);
    }
    public void Delay_Smile()
    {
        Smily_Effect.SetActive(false);

    }

    public void Game_retry()
    {
        SceneManager.LoadScene("History_Questions");

    }
    public void Back_Home()
    {
        AudioManager.instance.StopAll();
        AudioManager.instance.Play("Main_Field");
        SceneManager.LoadScene("Loading_bar");

    }

}
