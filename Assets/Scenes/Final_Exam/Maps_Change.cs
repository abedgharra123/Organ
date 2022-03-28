using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Maps_Change : MonoBehaviour
{
    public GameObject Torat_Kol_Map;
    public GameObject History_Map;
    public GameObject Math_Map;
    public GameObject Physics_Map;
    public GameObject Brocken_Heart;
    public GameObject Heart_PickUp;
    public GameObject Star;
    public AudioClip[] sound;
    public Material[] sky_Box;
    //3 hearts
    protected int heart_amount;
    public GameObject[] Hearts;
    protected int final_kol_score;
    public Text score_txt;

    void Start()
    {
        heart_amount = 3;
        Heart_PickUp.SetActive(false);
        Brocken_Heart.SetActive(false);
        Star.SetActive(false);
        History_Map.SetActive(false);
        Math_Map.SetActive(false);
        Physics_Map.SetActive(false);
        final_kol_score = 0;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Kol_Transform")
        {
            Invoke("Kol_Transform", 1);
        }
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
            AudioSource.PlayClipAtPoint(sound[0],col.transform.position);
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
                Hearts[heart_amount-1].SetActive(true);
            }
            Heart_PickUp.SetActive(true);
            Invoke("Increase_Life", 1);
            Destroy(col.gameObject);    
        }


        // if (col.collider.tag == "start_pipe")
        //  AudioSource.PlayClipAtPoint(sound, col.transform.position);

    }

    public void Kol_Transform()
    {
        History_Map.SetActive(true);
        transform.position = new Vector3(3, 10.92f, 52.75f);
        RenderSettings.skybox = sky_Box[0];
        Torat_Kol_Map.SetActive(false);
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
        Physics_Map.SetActive(true);
        transform.position = new Vector3(3, 30.947f, 152.468f);
        RenderSettings.skybox = sky_Box[2];
        Math_Map.SetActive(false);
    }

    public void Correct_Answer()
    {
        Star.SetActive(false);
        final_kol_score++;
        score_txt.text = "" + final_kol_score;
    }
    public void Wrong_Answer()
    {
            Brocken_Heart.SetActive(false);
    }
    public void Increase_Life()
    {
            Heart_PickUp.SetActive(false);
    }

}
