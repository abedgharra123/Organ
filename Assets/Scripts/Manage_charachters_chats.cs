using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage_charachters_chats : MonoBehaviour
{
    public GameObject sound_chat1;
    public GameObject history_chat2;
    public GameObject phytagoras_chat3;
    public GameObject johann_chat4;
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "sound_chat")
        {
            sound_chat1.SetActive(true);
        }
        else if (col.collider.tag == "history_chat" || col.collider.tag == "phytagoras_chat" || col.collider.tag == "johann_chat")
        {
            sound_chat1.SetActive(false);

        }

        if (col.collider.tag == "history_chat")
        {
            history_chat2.SetActive(true);
        }
        else if (col.collider.tag == "sound_chat" || col.collider.tag == "phytagoras_chat" || col.collider.tag == "johann_chat")
        {
            history_chat2.SetActive(false);

        }



        if (col.collider.tag == "phytagoras_chat")
        {
            phytagoras_chat3.SetActive(true);
        }
        else if (col.collider.tag == "history_chat" || col.collider.tag == "sound_chat" || col.collider.tag == "johann_chat")
        {
            phytagoras_chat3.SetActive(false);
        }

        if (col.collider.tag == "johann_chat")
        {
            johann_chat4.SetActive(true);
        }
        else if (col.collider.tag == "sound_chat" || col.collider.tag == "phytagoras_chat" || col.collider.tag == "history_chat")
        {
            johann_chat4.SetActive(false);
        }
    }

}
