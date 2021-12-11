using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
        Debug.Log(gameObject.tag);
        Debug.Log(other.tag);
    }
}
