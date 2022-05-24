using System.Collections.Generic;

[System.Serializable]

public class Player
{
    public string username;
    public string Id;

    public List<int> sound_game_result;
    public List<int> history_game_result;
    public List<string> final_game_result;


    //constructor
    public Player()
    {
        this.username = username;
        this.Id = Id;
        this.sound_game_result = sound_game_result;
        this.history_game_result = history_game_result;
        this.final_game_result = final_game_result;
    }




}
