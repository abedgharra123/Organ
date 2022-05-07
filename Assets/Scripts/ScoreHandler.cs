using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler
{
    public static int Score_1 {get; private set;} // first game, BrainSound game
    public static int Score_2 {get; private set;} // second game, History game
    public static int Score_3 {get; private set;} 
    public static int Score_4 {get; private set;}
    public static int Total_Score {get; private set;}

    void Start()
    {
        Score_1 = PlayerPrefs.GetInt("Score_1",0);
        Score_2 = PlayerPrefs.GetInt("Score_2",0);
        Score_3 = PlayerPrefs.GetInt("Score_3",0);
        Score_4 = PlayerPrefs.GetInt("Score_4",0);
        Total_Score = Score_1 + Score_2 + Score_3 + Score_4;
    }

    public static int GetTotalScore(){return Total_Score;}
    public static void SetScore(int index,int value){
        PlayerPrefs.SetInt($"Score_{index}",value);
    }
    public static void RecalculateTotalScore(){Total_Score = Score_1 + Score_2 + Score_3 + Score_4; }
}
