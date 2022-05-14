using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler
{
    public static int Score_1 { get; set; } // first game, BrainSound game
    public static int Score_2 { get; set; } // second game, History game

    // 1 - if Opened __ 0 - Not opened
    public static int Pythagoras ;
    // 1 - if Opened __ 0 - Not opened
    public static int Johann ;
    public static int Final ;

    void Start()
    {
        Score_1 = PlayerPrefs.GetInt("Score_1", 0);
        Score_2 = PlayerPrefs.GetInt("Score_2", 0);
        Pythagoras = PlayerPrefs.GetInt("Pythagoras", 0);
        Johann = PlayerPrefs.GetInt("Johann", 0);
        Final = PlayerPrefs.GetInt("Final_Exam", 0);
    }

    public static void SetScore(int index, int value)
    {
        PlayerPrefs.SetInt($"Score_{index}", value);
    }
    public static int GetScore(int index)
    {
        return PlayerPrefs.GetInt($"Score_{index}", 0);
    }

}