using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{

    public void StartButton(){
        SceneManager.LoadScene("Game_Field");
    }
}
