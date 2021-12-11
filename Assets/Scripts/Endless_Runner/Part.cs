using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    private Vector3 Direction;
    [SerializeField] public float Speed = -1f;

    
    void Start()
    {
        Direction = new Vector3(0f,0f,Speed);
        Destroy(gameObject,40f);
    }
    public void Awake(){
        Debug.Log(gameObject.name);
        if (gameObject.name == "RoadPart1(Clone)" || gameObject.name == "RoadPartFinal(Clone)") return;

        int rnd = Random.Range(0,3);


        TextMesh LeftText = transform.Find("LeftText").GetComponent<TextMesh>();
        TextMesh RightText = transform.Find("RightText").GetComponent<TextMesh>();
        TextMesh CenterText = transform.Find("CenterText").GetComponent<TextMesh>();

        if(rnd == 0){
            LeftText.tag = "Elephant";
            LeftText.text = Random.Range(0,21) + "Hz" ;

            CenterText.tag = "Human";
            CenterText.text = Random.Range(21,20001) + "Hz" ;

            RightText.tag = "Bat";
            RightText.text = Random.Range(20001,30001) + "Hz";
        }
        if(rnd == 1){
            RightText.tag = "Elephant";
            RightText.text = Random.Range(0,21) + "Hz" ;

            LeftText.tag = "Human";
            LeftText.text = Random.Range(21,20001) + "Hz" ;

            CenterText.tag = "Bat";
            CenterText.text = Random.Range(20001,30001) + "Hz";
        }
        if(rnd == 2){
            CenterText.tag = "Elephant";
            CenterText.text = Random.Range(0,21) + "Hz" ;

            RightText.tag = "Human";
            RightText.text = Random.Range(21,20001) + "Hz" ;

            LeftText.tag = "Bat";
            LeftText.text = Random.Range(20001,30001) + "Hz";
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction;
    }

}