using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour
{
    [SerializeField] GameObject PlayerField;
    [SerializeField] GameObject BrainScenes;

    public void BrainCharacter(){
        PlayerField.SetActive(false);
        BrainScenes.SetActive(true);
    }
}
