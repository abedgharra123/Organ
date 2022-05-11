using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    public GameObject Exams_Panel;
    public GameObject Clear_Data_panel;
    public GameObject Setting_Panel;
    public GameObject Exit_Panel;
    public void StartButton(){
        SceneManager.LoadScene("Loading_bar");
    }

    public void Open_exit_Panel()
    {
        Exit_Panel.SetActive(true);
    }public void Close_exit_Panel()
    {
        Exit_Panel.SetActive(false);
    }
    public void ExitButton()
    {
        AudioManager.instance.StopAll();
        AudioManager.instance.Play("Beach");
        SceneManager.LoadScene("MainScene");
    }

    public void Delete_Data_Button(){
        PlayerPrefs.DeleteAll();
        close_delete_data_panel();
    }
    public void close_delete_data_panel(){
        Clear_Data_panel.SetActive(false);
    }
    public void open_delete_data_panel(){
        Clear_Data_panel.SetActive(true);
    }
    public void open_Setting_panel(){
        Setting_Panel.SetActive(true);
    }
    public void Close_Setting_panel(){
        Setting_Panel.SetActive(false);
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
