using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllData : MonoBehaviour
{
    [SerializeField] Text Title;
    [SerializeField] Text TextData; 
    [SerializeField] List<State> states;
    [SerializeField] GameObject BrainScenes;
    [SerializeField] GameObject PlayerField;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        Title.text = states[0].GetTitle();
        TextData.text = states[0].GetDataText(); 
        index = 0;
    }
    public void NextState(){
        if(index+1 >= states.Count) return;
        index++;
        Title.text = states[index].GetTitle();
        TextData.text = states[index].GetDataText();
    }
    public void PreviousState(){
        if (index <= 0) return;
        index--;
        Title.text = states[index].GetTitle();
        TextData.text = states[index].GetDataText();
    }
    public void ExitBrainScenes(){
        BrainScenes.SetActive(false);
        PlayerField.SetActive(true);
    }


}
