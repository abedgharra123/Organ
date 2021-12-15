using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private string lastPart="";
    private string[] x = {"Human","Elephant","Bat"};
    private int score ;
    [SerializeField] TMP_Text tScore;  
    [SerializeField] GameObject gameOverHander;
    [SerializeField] GameObject touchScreen;
    void Start(){
        PlayerPrefs.SetInt("Score",0);
        score = PlayerPrefs.GetInt("Score",0);
        tScore.text = score.ToString();
    }
    public void LeftClick(){
        if(transform.position.x > -1.5f){
            gameObject.transform.position -= new Vector3( 3f,0,0);
            Debug.Log("Left Click");
        }
    }

    public void RightClick(){
        if(transform.position.x < 1.5f){
            gameObject.transform.position += new Vector3( 3f,0,0);
            Debug.Log("Right Click");
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == "1" || other.tag == "0" || other.tag == "2" ){
            lastPart = x[int.Parse(other.tag)];
            Debug.Log(lastPart);
        }
        if(other.tag == "Human" || other.tag == "Elephant" || other.tag == "Bat" ){
            if(lastPart == other.tag){
                Debug.Log("Correct!!: "+other.tag + " " + lastPart);
                lastPart = "";
                AudioManager.instance.Play("Correct");
                score+=1;
                PlayerPrefs.SetInt("Score",score);
                tScore.text = score.ToString();

            }
            else{
                Debug.Log("Wrong : "+other.tag + " " + lastPart);
                lastPart = "";
                AudioManager.instance.Play("Wrong");
            }
        }
        if(other.tag == "Finish"){
            AudioManager.instance.Play("Claps");
            AudioManager.instance.Play("Cheers");

            AudioManager.instance.Stop("Beach");
            AudioManager.instance.Stop("Endless_Runner");

            gameOverHander.SetActive(true);
            touchScreen.SetActive(false);

        }
        
    }
}
