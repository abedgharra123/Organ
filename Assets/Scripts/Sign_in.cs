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
            p.sound_game_result = new List<int>();
            p.history_game_result = new List<int>();
            p.final_game_result = new List<string>();
            for (int i = 1; i <= PlayerPrefs.GetInt("count_Sound_times", 0); i++)
            {
                p.sound_game_result.Add(PlayerPrefs.GetInt("Sound_Result" + i, 0));
            }
            for (int i = 1; i <= PlayerPrefs.GetInt("count_his_times", 0); i++)
            {
                p.history_game_result.Add(PlayerPrefs.GetInt("History_Result" + i, 0));
            }
            for (int i = 1; i <= PlayerPrefs.GetInt("count_final_times", 0); i++)
            {
                p.final_game_result.Add(PlayerPrefs.GetString("final_Result" + i, "not passed yet"));
            }
            Debug.Log(p.username);
        }
    }
    public void OnSubmit()
    {
        if (username.text.ToString().Length > 4)
        {
            p.username = username.text;
            PlayerPrefs.SetString("P_username", p.username.ToString());
            PlayerPrefs.SetInt("P_username_check", 1);
            p.sound_game_result = new List<int>();
            p.history_game_result = new List<int>();
            p.final_game_result = new List<string>();
            FindObjectOfType<DBHandler>().PostToDatabase(p);
            sign_panel.SetActive(false);
        }

    }
    public void open_SignIn_panel()
    {
        sign_panel.SetActive(true);

    }
}
