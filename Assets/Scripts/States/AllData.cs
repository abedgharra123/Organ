using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AllData : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] GameObject StatesUI;
    [SerializeField] GameObject PlayerField;
    private List<State> states;
    [SerializeField] List<State> BrainStates;
    [SerializeField] List<State> HistoryStates;
    [SerializeField] List<State> MathStates;
    [SerializeField] List<State> JohannStates;
    [SerializeField] GameObject Boy;
    [SerializeField] GameObject Girl;
    [SerializeField] UnityEngine.Video.VideoPlayer Clip;
    private int index;
    [SerializeField] GameObject[] YouTube;

    enum StatesType{
        BrainStates,
        History,
        Math,
        Johann
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
        YouTubeHandler();
        image.sprite = states[index].GetImage();
    }
    public void PreviousState(){
        if (index <= 0) return;
        index--;
        YouTubeHandler();
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
                if (raycastHit.collider.CompareTag("Math")){
                    OnCharacterClick(StatesType.Math);
                }
                if (raycastHit.collider.CompareTag("Johann")){
                    OnCharacterClick(StatesType.Johann);
                }
            }
        }
    }

    private void OnCharacterClick(StatesType type){
        AudioManager.instance.Play("Click");
        YouTube[0].SetActive(false);
        YouTube[1].SetActive(false);
        YouTube[2].SetActive(false);
        switch(type){
            case StatesType.BrainStates:
            states = BrainStates;
            Debug.Log("Brain charachter");
            break;
            case StatesType.History:
            Debug.Log("History charachter");
            states = HistoryStates;
            break;
            case StatesType.Math:
            Debug.Log("Math charachter");
            states = MathStates;
            PlayerPrefs.SetInt("Pythagoras", 1);
            break;
            case StatesType.Johann:
            Debug.Log("Johann charachter");
            states = JohannStates;
            PlayerPrefs.SetInt("Johann", 1);
            break;
        }
        PlayerField.SetActive(false);
        image.sprite = states[0].GetImage();
        index = 0;
        StatesUI.SetActive(true);
        Clip.Pause();
    }

    private void YouTubeHandler(){
        YouTube[0].SetActive(false);
        YouTube[1].SetActive(false);
        YouTube[2].SetActive(false);
        if(states[index].GetURL() == null) return;
        if(states[index].GetURL().Length > 0){
            if( states[index].GetURL().Length == 3){
                YouTube[0].SetActive(true);
                YouTube[0].GetComponent<Button>().onClick.AddListener(delegate { HyperLink.OpenURL(states[index].GetURL()[0]); });

                YouTube[1].SetActive(true);
                YouTube[1].GetComponent<Button>().onClick.AddListener(delegate { HyperLink.OpenURL(states[index].GetURL()[1]); });

                YouTube[2].SetActive(true);
                YouTube[2].GetComponent<Button>().onClick.AddListener(delegate { HyperLink.OpenURL(states[index].GetURL()[2]); });
            }
            else if(states[index].GetURL().Length == 2){
                YouTube[0].SetActive(true);
                YouTube[0].GetComponent<Button>().onClick.AddListener(delegate { HyperLink.OpenURL(states[index].GetURL()[0]); });

                YouTube[2].SetActive(true);
                YouTube[2].GetComponent<Button>().onClick.AddListener(delegate { HyperLink.OpenURL(states[index].GetURL()[1]); });
            }
            else if(states[index].GetURL() != null && states[index].GetURL()[0] != "" && states[index].GetURL()[0] != string.Empty){
                YouTube[1].SetActive(true);
                YouTube[1].GetComponent<Button>().onClick.AddListener(delegate { HyperLink.OpenURL(states[index].GetURL()[0]); });
            } 
        }
    }
}

