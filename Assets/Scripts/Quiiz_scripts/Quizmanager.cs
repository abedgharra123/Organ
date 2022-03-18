using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quizmanager : MonoBehaviour
{
    public List<QuestionAndAnswers> Q_A;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuestionPanel;
    public GameObject ScorePanel;

    public GameObject QuestionImg;
    public int Count_Score=0;
    public Text ScoreTxt;
    int Total_Score;


    private void Start()
    {
        Total_Score = Q_A.Count;
        ScorePanel.SetActive(false);
        generateQuestion();
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void GameOver()
    {
        QuestionPanel.SetActive(false);
        ScorePanel.SetActive(true);
        ScoreTxt.text = Count_Score + " / " + Total_Score;
    }
    
    public void correct()
    {
        Count_Score++;
        Q_A.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void Wrong()
    {
        //answer is wrong
        Q_A.RemoveAt(currentQuestion);
        generateQuestion();
    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect=false;
            options[i].transform.GetChild(0).GetComponent<Text>().text=Q_A[currentQuestion].Answers[i];

            if (Q_A[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<Answers>().isCorrect=true;
            }
        }

        
    }
     void generateQuestion()
    {

        if (Q_A.Count > 0)
        {
            currentQuestion = Random.Range(0, Q_A.Count);

            QuestionImg.GetComponent<Image>().sprite = Q_A[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of questions");
            GameOver();
        }
        

    }

    

}
