using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AllData : MonoBehaviour
{
    [SerializeField] Text Title;
    [SerializeField] Text TextData; 
    [SerializeField] Image image;
    [SerializeField] List<State> states;
    [SerializeField] GameObject BrainScenes;
    [SerializeField] GameObject PlayerField;


    private int index;
    // Start is called before the first frame update
    void Start()
    {
        Title.text = states[0].GetTitle();
        TextData.text = states[0].GetDataText(); 
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
        TextData.text = states[index].GetDataText();
        image.sprite = states[index].GetImage();
    }
    public void PreviousState(){
        if (index <= 0) return;
        index--;
        Title.text = states[index].GetTitle();
        TextData.text = states[index].GetDataText();
        image.sprite = states[index].GetImage();
    }
    public void ExitBrainScenes(){
        BrainScenes.SetActive(false);
        PlayerField.SetActive(true);
    }


}
