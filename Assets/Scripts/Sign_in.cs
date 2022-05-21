using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign_in : MonoBehaviour
{
    public GameObject sign_panel;

    public TMP_InputField username;

    public static Player p = new Player();

    private void Start()
    {
        if (PlayerPrefs.GetInt("P_username_check", 0) == 1)
        {
            sign_panel.SetActive(false);
            p.username = PlayerPrefs.GetString("P_username", "none");
            p.sound_game_result = (int)(PlayerPrefs.GetInt("Score_1", 0) * (100f / 15f));
            p.history_game_result = PlayerPrefs.GetInt("Score_2", 0);
            p.final_game_result = PlayerPrefs.GetString("Final_Exam_Result", "none");

            Debug.Log(p.username);
            Debug.Log(p.sound_game_result);
            Debug.Log(p.history_game_result);
            Debug.Log(p.final_game_result);

        }
    }
    public void OnSubmit()
    {
        if (username.text.ToString().Length > 4)
        {
            p.username = username.text;
            PlayerPrefs.SetString("P_username", p.username.ToString());
            PlayerPrefs.SetInt("P_username_check", 1);
            FindObjectOfType<DBHandler>().PostToDatabase(p);
            sign_panel.SetActive(false);
        }

    }
    public void open_SignIn_panel()
    {
        sign_panel.SetActive(true);

    }
}
