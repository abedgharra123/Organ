using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Maps_Change : MonoBehaviour
{
    public GameObject Torat_Kol_Map;
    public GameObject History_Map;
    public GameObject Math_Map;
    public GameObject Physics_Map;
    public GameObject Brocken_Heart;
    public GameObject Star;

    protected int final_kol_score;
    public Text score_txt;

    void Start()
    {
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
            History_Map.SetActive(true);
            transform.position = new Vector3(3, 10.92f, 52.75f);
            Torat_Kol_Map.SetActive(false);
        }
        if (col.collider.tag == "History_Transform")
        {
            Math_Map.SetActive(true);
            transform.position = new Vector3(3, 21, 102.32f);
            History_Map.SetActive(false);
        }
        if (col.collider.tag == "Math_Transform")
        {
            Physics_Map.SetActive(true);
            transform.position = new Vector3(3, 30.947f, 152.468f);
            Math_Map.SetActive(false);

        }
        if (col.collider.tag == "Correct_Answer")
        {
            Star.SetActive(true);
            final_kol_score++;
            score_txt.text = "" + final_kol_score;
        }
        if (col.collider.tag == "Wrong_Answer")
        {
            Brocken_Heart.SetActive(true);


        }


        // if (col.collider.tag == "start_pipe")
        //  AudioSource.PlayClipAtPoint(sound, col.transform.position);

    }




}
