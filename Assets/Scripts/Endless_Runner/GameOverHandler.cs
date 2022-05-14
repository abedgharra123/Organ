using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverHandler : MonoBehaviour
{
    [SerializeField] Text score_txt;
    public GameObject[] Trophies;
    private int Score;

    public void PlayAgain(){ SceneManager.LoadScene(2); }
    public void BackToLearning(){ SceneManager.LoadScene(3); }

    public void Awake(){
        score_txt.text =  PlayerPrefs.GetInt("Score", 0).ToString();
        Score = PlayerPrefs.GetInt("Score", 0);
         if (Score > 12)
        {
            score_txt.color = Color.green;
            score_txt.text = "" + Score * (100/15) + "%";
            Trophies[0].SetActive(true);
            Trophies[1].SetActive(false);
            Trophies[2].SetActive(false);
        }
        else if (Score > 9)
        {
            score_txt.color = Color.yellow;
            score_txt.text = "" + Score * (100/15) + "%";
            Trophies[1].SetActive(true);
            Trophies[0].SetActive(false);
            Trophies[2].SetActive(false);
        }
        else
        {
            score_txt.color = Color.red;
            score_txt.text = "" + Score * (100/15) + "%";
            Trophies[2].SetActive(true);
            Trophies[0].SetActive(false);
            Trophies[1].SetActive(false);

        }

        if(PlayerPrefs.GetInt("Score", 0) > PlayerPrefs.GetInt("Score_1", 0)){
            
            ScoreHandler.SetScore(1,PlayerPrefs.GetInt("Score", 0));
        }
        ScoreHandler.Score_1 = PlayerPrefs.GetInt("Score", 0);
    }
}
