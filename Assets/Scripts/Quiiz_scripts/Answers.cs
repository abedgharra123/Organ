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
            StartCoroutine(Timedelay());
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            StartCoroutine(Timedelay());
            Debug.Log("Wrong Answer");
            quizManager.Wrong();

        }
    }

    IEnumerator Timedelay()
    {

        yield return new WaitForSeconds(0.6f);
        GetComponent<Image>().color = startColor;

    }
}
