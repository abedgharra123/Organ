using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Proyecto26;


public class GameOverHandler : MonoBehaviour
{
    [SerializeField] Text score_txt;
    public GameObject[] Trophies;
    private float Score;

    public void PlayAgain() { SceneManager.LoadScene(2); }
    public void BackToLearning()
    {
        AudioManager.instance.StopAll();
        AudioManager.instance.Play("Main_Field");
        SceneManager.LoadScene(3);

    }

    public void Awake()
    {
        score_txt.text = PlayerPrefs.GetInt("Score", 0).ToString();
        Score = PlayerPrefs.GetInt("Score", 0);
        if (Score == 15)
        {
            Sign_in.p.sound_game_result.Add((int)(Score * (100f / 15f) + 1));
            PlayerPrefs.SetInt("Sound_Result" + (Sign_in.p.sound_game_result.Count), (int)(Score * (100f / 15f) + 1));

        }
        else
        {

            Sign_in.p.sound_game_result.Add((int)(Score * (100f / 15f)));
            PlayerPrefs.SetInt("Sound_Result" + (Sign_in.p.sound_game_result.Count), (int)(Score * (100f / 15f)));

        }
        PlayerPrefs.SetInt("count_Sound_times", Sign_in.p.sound_game_result.Count);

        Debug.Log(Sign_in.p.username);
        Debug.Log(Sign_in.p.sound_game_result.Count);
        RestClient.Put("https://pipe-organ-372bf-default-rtdb.firebaseio.com/" + Sign_in.p.username + ".json", Sign_in.p);
        if (Score > 12)
        {
            score_txt.color = Color.green;
            if (Score < 15)
            {
                score_txt.text = "" + ((int)(Score * (100f / 15f))) + "%";
            }
            else
            {
                score_txt.text = "" + ((int)(Score * (100f / 15f) + 1)) + "%";
            }
            Trophies[0].SetActive(true);
            Trophies[1].SetActive(false);
            Trophies[2].SetActive(false);
        }
        else if (Score > 9)
        {
            score_txt.color = Color.yellow;
            score_txt.text = "" + ((int)(Score * (100f / 15f))) + "%";
            Trophies[1].SetActive(true);
            Trophies[0].SetActive(false);
            Trophies[2].SetActive(false);
        }
        else
        {
            score_txt.color = Color.red;
            score_txt.text = "" + ((int)(Score * (100f / 15f))) + "%";
            Trophies[2].SetActive(true);
            Trophies[0].SetActive(false);
            Trophies[1].SetActive(false);

        }

        if (PlayerPrefs.GetInt("Score", 0) > PlayerPrefs.GetInt("Score_1", 0))
        {

            ScoreHandler.SetScore(1, PlayerPrefs.GetInt("Score", 0));
        }
        ScoreHandler.Score_1 = PlayerPrefs.GetInt("Score", 0);
    }
}
