using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leantween : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = Vector2.zero;
    }
    public void open()
    {
        transform.LeanScale(Vector2.one, 0.8f);
    }
    public void close()
    {
        transform.LeanScale(Vector2.one, 1f).setEaseInBack();
    }

}
