using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    
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

    public void Final_Exam()
    {
        SceneManager.LoadScene("Final_Exam_Game");
    }


}
