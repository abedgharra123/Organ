using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperLink : MonoBehaviour
{
    public static void OpenURL(string url){
        if (url == "" || url == null || url == string.Empty) return;
        Application.OpenURL(url);
    }
}
