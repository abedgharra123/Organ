using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AllData : MonoBehaviour
{
    [SerializeField] Text Title;
    [SerializeField] Image image;
    [SerializeField] GameObject StatesUI;
    [SerializeField] GameObject PlayerField;
    private List<State> states;
    [SerializeField] List<State> BrainStates;
    [SerializeField] List<State> HistoryStates;
    [SerializeField] List<State> MathStates;
    [SerializeField] GameObject Boy;
    [SerializeField] GameObject Girl;
    [SerializeField] UnityEngine.Video.VideoPlayer Clip;
    private int index;
    // Start is called before the first frame update

    enum StatesType{
        BrainStates,
        History,
    }
    void Start()
    {
        //Title.text = states[0].GetTitle();
        //image.sprite = states[0].GetImage();
        index = 0;
    }
    public void NextState(){
        if(index+1 >= states.Count){

            playerControllerInput.LastPosition = PlayerPrefs.GetInt("IsCharacterPicked",0) == 1 ?  Boy.transform.position : Girl.transform.position;
            if(states == BrainStates)
                SceneManager.LoadScene("Endless_Runner");
            if(states == HistoryStates)
                SceneManager.LoadScene(6);
            return;
        }
        index++;
        Title.text = states[index].GetTitle();
        image.sprite = states[index].GetImage();
    }
    public void PreviousState(){
        if (index <= 0) return;
        index--;
        Title.text = states[index].GetTitle();
        image.sprite = states[index].GetImage();
    }
    public void ExitScenes(){
        Clip.Play();
        StatesUI.SetActive(false);
        PlayerField.SetActive(true);
    }
    void Update(){
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit)){
                Debug.Log("Something Hit");
                if (raycastHit.collider.CompareTag("BrainSound")){
                    OnCharacterClick(StatesType.BrainStates);
                }
                if (raycastHit.collider.CompareTag("History")){
                    OnCharacterClick(StatesType.History);
                }
            }
        }
    }

    private void OnCharacterClick(StatesType type){
        AudioManager.instance.Play("Click");
        switch(type){
            case StatesType.BrainStates:
            states = BrainStates;
            Debug.Log("Brain charachter");
            break;
            case StatesType.History:
            Debug.Log("History charachter");
            states = HistoryStates;
            break;
        }
        PlayerField.SetActive(false);
        Title.text = states[0].GetTitle();
        image.sprite = states[0].GetImage();
        index = 0;
        StatesUI.SetActive(true);
        Clip.Pause();
    }




}
