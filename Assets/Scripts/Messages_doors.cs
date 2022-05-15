using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messages_doors : MonoBehaviour
{
   
    public GameObject[] messages;
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "History_door")
        {
            messages[0].SetActive(true);
        }
        if (col.collider.tag == "phy_door")
        {
            messages[1].SetActive(true);
        }
        if (col.collider.tag == "Johann_door")
        {
            messages[2].SetActive(true);
        }
        if (col.collider.tag == "Last_door")
        {
            messages[3].SetActive(true);
        }
    }

    public void close_History_door()
    {
            messages[0].SetActive(false);
    }
    public void close_phy_door()
    {
            messages[1].SetActive(false);
    }
    public void close_Johann_door()
    {
            messages[2].SetActive(false);
    }
    public void close_Last_door()
    {
            messages[3].SetActive(false);
    }
}

