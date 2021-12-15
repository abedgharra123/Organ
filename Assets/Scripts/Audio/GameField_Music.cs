using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField_Music : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        AudioManager.instance.StopAll();
        AudioManager.instance.Play("Learning");
    }

}
