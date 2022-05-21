using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript2 : MonoBehaviour
{
    public GameObject Exams_Panel;
    public GameObject Clear_Data_panel;
    public GameObject Setting_Panel;
    public GameObject Exit_Panel;
    public void StartButton()
    {
        AudioManager.instance.StopAll();
        AudioManager.instance.Play("Main_Field");
        SceneManager.LoadScene("Loading_bar");
    }

    public void Open_exit_Panel()
    {
        //  Exit_Panel.SetActive(true);
        Exit_Panel.transform.LeanScale(Vector2.one, 0.8f);
    }
    public void Close_exit_Panel()
    {
        // Exit_Panel.SetActive(false);
        Exit_Panel.transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }
    public void ExitButton()
    {
        AudioManager.instance.StopAll();
        AudioManager.instance.Play("Beach");
        SceneManager.LoadScene("MainScene");
    }

    public void Delete_Data_Button()
    {
        PlayerPrefs.DeleteAll();
        close_delete_data_panel();
    }
    public void close_delete_data_panel()
    {
        //Clear_Data_panel.SetActive(false);
        Clear_Data_panel.transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }
    public void open_delete_data_panel()
    {
        //Clear_Data_panel.SetActive(true);
        Clear_Data_panel.transform.LeanScale(Vector2.one, 0.8f);
    }
    public void open_Setting_panel()
    {
        Setting_Panel.transform.LeanScale(Vector2.one, 0.8f);
        // Setting_Panel.SetActive(true);
    }
    public void Close_Setting_panel()
    {
        Setting_Panel.transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
        // Setting_Panel.SetActive(false);
    }

    /*Final game Func transform*/
    public void Final_Exam()
    {

        AudioManager.instance.StopAll();
        SceneManager.LoadScene("Final_Exam_Game");
    }

    /* open Exams Panel*/
    public void Open_Exams_Panel()
    {
        Exams_Panel.transform.LeanScale(Vector2.one, 0.8f);
        // Exams_Panel.SetActive(true);
    }
    /* Close Exams Panel*/
    public void Close_Exams_Panel()
    {
        Exams_Panel.transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
        //  Exams_Panel.SetActive(false);
    }


}
