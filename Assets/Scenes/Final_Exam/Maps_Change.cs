using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Proyecto26;


public class Maps_Change : MonoBehaviour
{
    public GameObject History_Map;
    public GameObject Math_Map;
    public GameObject Brocken_Heart;
    public GameObject Heart_PickUp;
    public int count_mistakes;
    public GameObject Star;
    public AudioClip[] sound;
    public Material[] sky_Box;
    //3 hearts
    protected int heart_amount;
    public GameObject[] Hearts;
    protected int Count_question;
    public GameObject[] Questions;
    public GameObject Restart_Game_Panel;
    public GameObject Movenment_btns;
    public GameObject Game_Player;

    void Start()
    {
        count_mistakes = 0;
        for (int i = 1; i < Questions.Length; i++)
        {
            Questions[i].SetActive(false);
        }
        Restart_Game_Panel.SetActive(false);
        heart_amount = 3;
        Heart_PickUp.SetActive(false);
        Brocken_Heart.SetActive(false);
        Star.SetActive(false);
        Math_Map.SetActive(false);
        Count_question = 0;
    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.collider.tag == "History_Transform")
        {
            Invoke("History_Transform", 1);
        }
        if (col.collider.tag == "Math_Transform")
        {
            Invoke("Math_Transform", 1);

        }

        if (col.collider.tag == "Correct_Answer")
        {
            Star.SetActive(true);
            AudioSource.PlayClipAtPoint(sound[0], col.transform.position);
            Invoke("Correct_Answer", 1);
            Destroy(col.gameObject);


        }
        if (col.collider.tag == "Wrong_Answer")
        {
            Brocken_Heart.SetActive(true);
            AudioSource.PlayClipAtPoint(sound[1], col.transform.position);
            if (heart_amount > 0)
            {
                heart_amount--;
                Hearts[heart_amount].SetActive(false);
            }
            Invoke("Wrong_Answer", 1.5f);
            Destroy(col.gameObject);

        }
        if (col.collider.tag == "Destroy_Question")
        {
            Destroy(col.gameObject);
        }

        if (col.collider.tag == "Heart_PickUp_Kol" || col.collider.tag == "Heart_PickUp_History" || col.collider.tag == "Heart_PickUp_Math")
        {
            AudioSource.PlayClipAtPoint(sound[0], col.transform.position);
            if (heart_amount < 3)
            {
                heart_amount++;
                Hearts[heart_amount - 1].SetActive(true);
            }
            Heart_PickUp.SetActive(true);
            Invoke("Increase_Life", 1);
            Destroy(col.gameObject);
        }


        // if (col.collider.tag == "start_pipe")
        //  AudioSource.PlayClipAtPoint(sound, col.transform.position);

    }


    public void History_Transform()
    {
        Math_Map.SetActive(true);
        transform.position = new Vector3(3, 21, 102.32f);
        RenderSettings.skybox = sky_Box[1];
        History_Map.SetActive(false);

    }

    public void Math_Transform()
    {
        PlayerPrefs.SetInt("Red_Carpet", 1);
        PlayerPrefs.SetInt("Final_Exam", 1);
        PlayerPrefs.SetString("Final_Exam_Result", count_mistakes.ToString() + " Mistakes");


        Sign_in.p.final_game_result.Add(count_mistakes.ToString() + " Mistakes");

        PlayerPrefs.SetString("final_Result" + (Sign_in.p.final_game_result.Count), count_mistakes.ToString() + " Mistakes");

        PlayerPrefs.SetInt("count_final_times", Sign_in.p.final_game_result.Count);


        RestClient.Put("https://pipe-organ-372bf-default-rtdb.firebaseio.com/" + Sign_in.p.username + ".json", Sign_in.p);
        AudioManager.instance.Play("Main_Field");
        SceneManager.LoadScene("Loading_bar");

    }

    public void Correct_Answer()
    {
        Star.SetActive(false);
        Questions[++Count_question].SetActive(true);
    }
    public void Wrong_Answer()
    {
        count_mistakes++;
        Brocken_Heart.SetActive(false);

        if (Count_question + 1 != Questions.Length)
            Questions[++Count_question].SetActive(true);

        if (heart_amount == 0)
        {
            Movenment_btns.SetActive(false);
            Game_Player.SetActive(false);
            Sign_in.p.final_game_result.Add("Not Passed");

            PlayerPrefs.SetString("final_Result" + (Sign_in.p.final_game_result.Count), "Not Passed");

            PlayerPrefs.SetInt("count_final_times", Sign_in.p.final_game_result.Count);
            RestClient.Put("https://pipe-organ-372bf-default-rtdb.firebaseio.com/" + Sign_in.p.username + ".json", Sign_in.p);

            Restart_Game_Panel.SetActive(true);
        }
    }
    public void Increase_Life()
    {
        Heart_PickUp.SetActive(false);
    }


}
