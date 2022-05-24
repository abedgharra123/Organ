using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class DBHandler : MonoBehaviour
{
    private string firebase_url = "https://pipe-organ-372bf-default-rtdb.firebaseio.com/";


    public void PostToDatabase(Player p)
    {
        RestClient.Post(firebase_url + p.username + ".json", p);
    }

}
