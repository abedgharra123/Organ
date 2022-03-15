using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public Quizmanager quizManager;

    public Color startColor;




    private void Start()
    {

        startColor = GetComponent<Image>().color;
    }
    
    public void Answer()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Task.Delay(1000);
            GetComponent<Image>().color = startColor;
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Task.Delay(1000);
            GetComponent<Image>().color = startColor;
            Debug.Log("Wrong Answer");
            quizManager.Wrong();

        }
    }
}
