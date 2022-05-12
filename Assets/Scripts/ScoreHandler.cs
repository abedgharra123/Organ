using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler
{
    public static int Score_1 { get; set; } // first game, BrainSound game
    public static int Score_2 { get; set; } // second game, History game
    public static int Score_3 { get; private set; }
    public static int Score_4 { get; private set; }
    public static int Total_Score { get; private set; }

    // 1 - if Opened __ 0 - Not opened
    public static int Pythagoras ;
    // 1 - if Opened __ 0 - Not opened
    public static int Johann ;

    void Start()
    {
        Score_1 = PlayerPrefs.GetInt("Score_1", 0);
        Score_2 = PlayerPrefs.GetInt("Score_2", 0);
        Score_3 = PlayerPrefs.GetInt("Score_3", 0);
        Score_4 = PlayerPrefs.GetInt("Score_4", 0);
        Pythagoras = PlayerPrefs.GetInt("Pythagoras", 0);
        Johann = PlayerPrefs.GetInt("Johann", 0);
        Total_Score = Score_1 + Score_2 + Score_3 + Score_4;
    }

    public static int GetTotalScore() { return Total_Score; }
    public static void SetScore(int index, int value)
    {
        PlayerPrefs.SetInt($"Score_{index}", value);
    }
    public static int GetScore(int index)
    {
        return PlayerPrefs.GetInt($"Score_{index}", 0);
    }

    public static void RecalculateTotalScore() { Total_Score = Score_1 + Score_2 + Score_3 + Score_4; }
}