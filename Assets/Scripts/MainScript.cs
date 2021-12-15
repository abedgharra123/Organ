using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    
    public void StartButton(){
        SceneManager.LoadScene("Game_Field");
    }
    public void ExitButton()
    {
        AudioManager.instance.StopAll();
        AudioManager.instance.Play("Beach");
        AudioManager.instance.Play("Main_Music");
        SceneManager.LoadScene("MainScene");
    }
    public void SettingsButton(){
        
    }

    
}
