using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    public GameObject Exams_Panel;
    public void StartButton(){
        SceneManager.LoadScene("Loading_bar");
    }
    public void ExitButton()
    {
        AudioManager.instance.StopAll();
        AudioManager.instance.Play("Beach");
        SceneManager.LoadScene("MainScene");
    }
    public void SettingsButton(){
        
    }

    /*Final game Func transform*/
    public void Final_Exam()
    {
        SceneManager.LoadScene("Final_Exam_Game");
    }
    
    /* open Exams Panel*/
    public void Open_Exams_Panel()
    {
        Exams_Panel.SetActive(true);
    }
    /* Close Exams Panel*/
    public void Close_Exams_Panel()
    {
        Exams_Panel.SetActive(false);
    }
    

}
