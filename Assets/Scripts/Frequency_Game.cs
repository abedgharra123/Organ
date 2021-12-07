using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frequency_Game : MonoBehaviour
{
    private float move=3.41f;
    private int Right_Left = 25;
 
    void Update()
    {
        move += 0.1f;
     transform.position = new Vector3(Right_Left, 0, move);

    }
    public void Go_Left()
    {
        if (Right_Left > 15)
        {
            Right_Left -= 10;
            transform.position = new Vector3(Right_Left, 0, move);
        }
    }
    public void Go_Right()
    {
        if (Right_Left < 35)
        {
            Right_Left += 10;
            transform.position = new Vector3(Right_Left, 0, move);

        }
    }

}
