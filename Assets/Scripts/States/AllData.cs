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
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        Title.text = states[0].GetTitle();
        image.sprite = states[0].GetImage();
        index = 0;
    }
    public void NextState(){
        if(index+1 >= states.Count){
            
            SceneManager.LoadScene("Endless_Runner");
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
                    Debug.Log("BrainSound Hit");
                    PlayerField.SetActive(false);
                    states = BrainStates;
                    Title.text = states[0].GetTitle();
                    image.sprite = states[0].GetImage();
                    index = 0;
                    StatesUI.SetActive(true);

                }
                if (raycastHit.collider.CompareTag("History")){
                    Debug.Log("History Hit");
                    PlayerField.SetActive(false);
                    states = HistoryStates;
                    Title.text = states[0].GetTitle();
                    image.sprite = states[0].GetImage();
                    index = 0;
                    StatesUI.SetActive(true);
                }
            }
        }
    }


}
