using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    public void PlayAgain(){ SceneManager.LoadScene(2); }
    public void BackToLearning(){ SceneManager.LoadScene(1); }

    public void Awake(){
        score.text =  "Score: " + PlayerPrefs.GetInt("Score", 0);
        if(PlayerPrefs.GetInt("Score", 0) > PlayerPrefs.GetInt("Score_1", 0)){
            ScoreHandler.SetScore(1,PlayerPrefs.GetInt("Score", 0));
            ScoreHandler.RecalculateTotalScore();
        }
    }
}
