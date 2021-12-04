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

    void Update(){
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit)){
                Debug.Log("Something Hit");
                if (raycastHit.collider.CompareTag("BrainSound")){
                    Debug.Log("BrainSound Hit");
                    PlayerField.SetActive(false);
                    BrainScenes.SetActive(true);
                }
            }
        }
    }
}
